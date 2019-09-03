using System.Collections.Generic;
using UnityEngine;
using _WicketShooter.Scripts.Aim;
using _WicketShooter.Scripts.AttackWeapons.Melee;
using _WicketShooter.Scripts.AttackWeapons.Weapons;
using _WicketShooter.Scripts.InputSystem;
using _WicketShooter.Scripts.Movement;

namespace _WicketShooter.Scripts.Actors
{
    [RequireComponent(typeof(MovementSystem))]
    [RequireComponent(typeof(AimManager))]
    public class Player : MonoBehaviour, IActor
    {
        public float SpeedMultiplier;
        public int life;

        public RangeWeaponType StartingRangeWeapon;

        public MeleeWeapons StartingMeleeWeapon;

        [SerializeField]
        public BaseWeaponsController BaseWeaponsController { get; set; }

        private MovementSystem movementSystem;
        private AimManager aimManager;

        private void Awake()
        {
            aimManager = GetComponent<AimManager>();
            movementSystem = GetComponent<MovementSystem>();
            movementSystem.SetMultiplier(SpeedMultiplier);

            BaseWeaponsController = new BaseWeaponsController(StartingMeleeWeapon, StartingRangeWeapon, gameObject, aimManager);

            IInputControll inputSystem = KeyboardInput.Instance;
            inputSystem.OnInput += ManageInput;
        }

        private void ManageInput(Dictionary<InputType, InputData> inputs)
        {
            HandleMovement(inputs);
            HandleAttack(inputs);
        }
        
        private void HandleMovement(Dictionary<InputType, InputData> inputs)
        {
            inputs.TryGetValue(InputType.Movement, out var movement);
            if ( movement == null )
            {
                movementSystem.UpdateMovement(Vector2.zero);
                return;
            }

            movementSystem.UpdateMovement(movement.Vector2Value);
        }
        
        private void HandleAttack(Dictionary<InputType, InputData> inputs)
        {
            var melee = inputs.ContainsKey(InputType.Melee);
            if ( melee )
            {
                BaseWeaponsController.Attack();
            }

            var fire = inputs.ContainsKey(InputType.Shoot);
            if ( fire )
            {
                BaseWeaponsController.Fire();
            }
        }
    }
}