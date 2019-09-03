using UnityEngine;
using _WicketShooter.Scripts.Movement;

namespace _WicketShooter.Scripts.Actors
{
    public class BaseActor
    {
        public float SpeedMultiplier;
        public int Life;
        
        private MovementSystem movementSystem;

        public BaseActor(float speedMultiplier, int life, MovementSystem movementSystem)
        {
            SpeedMultiplier = speedMultiplier;
            Life = life;
            this.movementSystem = movementSystem;
            this.movementSystem.SetMultiplier(speedMultiplier);
        }

        public void UpdateMovement(Vector2 direction)
        {
            movementSystem.UpdateMovement(direction);
        }
    }
}