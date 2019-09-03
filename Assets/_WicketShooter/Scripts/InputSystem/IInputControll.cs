using System;
using System.Collections.Generic;

namespace _WicketShooter.Scripts.InputSystem
{
    public interface IInputControll
    {
        event Action<Dictionary<InputType, InputData>> OnInput;
    }
}