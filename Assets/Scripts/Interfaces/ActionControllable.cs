using System.Collections.Generic;
using UnityEngine;

public interface IActionControllable
{ 
    Dictionary<KeyCode, IActionCommand> ActionCommands { get; }
}
