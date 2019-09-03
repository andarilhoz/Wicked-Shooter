using System.Collections.Generic;
using UnityEngine;
using _WicketShooter.Scripts.InputSystem;
using _WicketShooter.Scripts.Movement;

namespace _WicketShooter.Scripts.Actors
{
    [RequireComponent(typeof(MovementSystem))]
    public class Player : MonoBehaviour, IActor
    {
        public float speedMultiplier;
        public int life;
            
        public BaseActor BaseActor { get; set; }
        
        private void Awake()
        {
            var movementSystem = GetComponent<MovementSystem>();
            BaseActor = new BaseActor(speedMultiplier, life, movementSystem);
            IInputControll inputSystem = KeyboardInput.Instance;
            inputSystem.OnInput += ManageInput;
        }

        private void ManageInput(Dictionary<InputType, InputData> inputs)
        {
            InputData movement;
            inputs.TryGetValue(InputType.Movement, out movement);
            if ( movement == null )
            {
                BaseActor.UpdateMovement(Vector2.zero);
                return;
            }

            BaseActor.UpdateMovement(movement.Vector2Value);
        }

    }
}