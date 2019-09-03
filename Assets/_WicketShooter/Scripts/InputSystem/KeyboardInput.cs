using System;
using System.Collections.Generic;
using UnityEngine;

namespace _WicketShooter.Scripts.InputSystem
{
    public class KeyboardInput : MonoBehaviour, IInputControll
    {

        public float InputThroughput;
        
        public event Action<Dictionary<InputType, InputData>> OnInput;

        #region Singleton

        private static KeyboardInput instance;

        public static KeyboardInput Instance
        {
            get
            {
                if ( instance == null )
                {
                    instance = FindObjectOfType<KeyboardInput>();
                }

                return instance;
            }
        }

        private void Awake()
        {
            if ( instance == null )
            {
                instance = this;
            }
        }

        #endregion

        private void Update()
        {
            ListenInput();
        }

        public void ListenInput()
        {
            var horizontalMovement = Input.GetAxisRaw("Horizontal");
            var verticalMovement = Input.GetAxisRaw("Vertical");
            var mouseWheel = Input.GetAxis("Mouse ScrollWheel");
            
            var hadMovement = Math.Abs(horizontalMovement) > InputThroughput || Math.Abs(verticalMovement) > InputThroughput;
            
            var shoot = Input.GetButton("Fire1") ? InputType.Shoot : InputType.None;
            var dodge = Input.GetButton("Jump") ? InputType.Dodge : InputType.None;
            var melee = Input.GetButton("Fire2") ? InputType.Melee : InputType.None;
            
            var movement = hadMovement ? InputType.Movement : InputType.None;
            var changeGun =  mouseWheel > 0 ? InputType.ChangeGun : InputType.None;
            
            var changeGunValue = new InputData(){FloatValue = mouseWheel};
            var movementValue = new InputData(){Vector2Value = new Vector2(horizontalMovement, verticalMovement)};

            var actionsList = BuildActionList(changeGunValue, movementValue, shoot, dodge, melee, movement, changeGun);
            OnInput?.Invoke(actionsList);
        }

        private static Dictionary<InputType, InputData> BuildActionList(InputData changeGunValue, InputData movementValue, params InputType[] inputTypes )
        {
            var actionsList = new Dictionary<InputType, InputData>();
            for (var i = 0; i < inputTypes.Length; i++)
            {
                if ( inputTypes[i].Equals(InputType.None) ) continue;
                
                InputData inputData = null; 
                if ( inputTypes[i].Equals(InputType.Movement) )
                {
                    inputData = movementValue;
                }

                if ( inputTypes[i].Equals(InputType.ChangeGun) )
                {
                    inputData = changeGunValue;
                }
                actionsList.Add(inputTypes[i], inputData);
            }

            return actionsList;
        }

    }
}