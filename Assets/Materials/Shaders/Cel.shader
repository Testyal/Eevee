Shader "Unlit/Cel"
{
    Properties
    {
        _Color ("Color", Color) = (1.0, 1.0, 1.0, 1.0)
        _RimColor ("Rim Color", Color) = (0.0, 0.0, 0.0, 1.0)
        _ShadowColor ("Shadow Color", Color) = (0.5, 0.5, 0.5, 1.0)
        _OutlineColor ("Outline color", Color) = (0.0, 0.0, 0.0, 1.0)
        // _MaxRimIntensity ("Maximum rim intensity", float) = 0.5
    }
    SubShader
    {
        Tags 
        {
            "PassFlags" = "OnlyDirectional"
            "LightMode" = "ForwardBase"
        }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work

            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 normal : NORMAL;
                float3 lightDir : TEXCOORD1;
                float3 viewDir : TEXCOORD2;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = UnityObjectToWorldNormal(v.normal);
                o.lightDir = - WorldSpaceLightDir(v.vertex); // For some reason WorldSpaceLightDir returns the opposite direction to where the light is actually pointing
                o.viewDir = normalize(_WorldSpaceCameraPos - mul(unity_ObjectToWorld, v.vertex));

                return o;
            }

            float4 _Color;
            float4 _RimColor;
            float4 _ShadowColor;
            float4 _OutlineColor;

            float _MaxRimIntensity;

            float4 frag (v2f i) : SV_Target
            {
                float4 o = _Color;

                float lightDotNormal = dot(i.lightDir, i.normal);
                float shadowIntensity = 0.3 * smoothstep(-0.02, 0.02, lightDotNormal);
                o = lerp(o, _ShadowColor, shadowIntensity);

                float viewDotNormal = dot(i.viewDir, i.normal);
                /*float lightIntensity = 1 - (0.5 * (1 + lightDotNormal));
                float rimIntensity = 0.6 * (1 - smoothstep(0.5 * lightIntensity - 0.1, 0.5 * lightIntensity - 0.05, viewDotNormal));
                o = lerp(o, _RimColor, rimIntensity);
                */

                return o;
            }
            ENDCG
        }
    }
}
