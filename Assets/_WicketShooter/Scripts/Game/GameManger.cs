using UnityEngine;

namespace _WicketShooter.Scripts.Game
{
    public class GameManger : MonoBehaviour
    {
        #region Singleton

        private static GameManger instance;

        public static GameManger Instance
        {
            get
            {
                if ( instance == null )
                {
                    instance = FindObjectOfType<GameManger>();
                }

                return instance;
            }
        }

        private void Awake()
        {
            if ( instance == null )
            {
                instance = this;
                Initialize();
                return;
            }
            Destroy(this);
        }

        #endregion

        [SerializeField]
        private GameStates currentGameState;

        private void Initialize()
        {
            currentGameState = GameStates.Play;
        }

        public GameStates GetCurrentGameState()
        {
            return currentGameState;
        }


    }
}