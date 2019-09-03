using UnityEngine;
using _WicketShooter.Scripts.Game;

namespace _WicketShooter.Scripts.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementSystem : MonoBehaviour
    {
        public float BaseSpeed;
        private float currentSpeed;
        
        public Vector2 CurrentDirection = Vector2.zero;
        public Animator Animator;

        private Rigidbody2D rb2D;
        private float mp;

        public void SetMultiplier(float multiplier)
        {
            mp = multiplier;
        }

        private void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            currentSpeed = BaseSpeed;
        }

        public void UpdateMovement(Vector2 direction)
        {
            CurrentDirection = direction;
        }

        protected virtual void FixedUpdate()
        {
            if ( GameManger.Instance.GetCurrentGameState().Equals(GameStates.Pause) )
            {
                return;
            }

            Move();
        }

        private void Move()
        {
            rb2D.velocity = new Vector2(CurrentDirection.x * currentSpeed * mp, CurrentDirection.y * currentSpeed * mp);   
        }
    }
}
