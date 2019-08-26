using UnityEngine;
using System.Collections.Generic;

public interface IAxisControllable
{
    Dictionary<KeyCode, IAxisCommand> axisCommands { get; }
    void ResetMovementControls();
    void ApplyMovementControls();
}