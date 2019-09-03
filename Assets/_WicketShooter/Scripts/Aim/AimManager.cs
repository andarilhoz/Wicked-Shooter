using System;
using UnityEngine;
using _WicketShooter.Scripts.Actors;

namespace _WicketShooter.Scripts.Aim
{
    [RequireComponent(typeof(LineRenderer))]
    [RequireComponent(typeof(Player))]
    public class AimManager : MonoBehaviour
    {
        private LineRenderer lineRenderer;

        public AnimationCurve ThinLine;
        public AnimationCurve ConeLine;

        private Player player;
        private float currentRange;
        private UnityEngine.Camera mainCamera;
        
        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
            player = GetComponent<Player>();
            mainCamera = UnityEngine.Camera.main;
        }

        public void ChangeAimRange(float range)
        {
            
        }

        private void Update()
        {
            var linePos = GetAimMaxRangePosition();
            lineRenderer.SetPosition(0, player.transform.position);
            lineRenderer.SetPosition(1, linePos);
        }

        public Vector2 GetAimMaxRangePosition()
        {
            return player.transform.position + MousePositionInRelationToPlayer() * currentRange; 
        }

        public Vector3 MousePositionInRelationToPlayer()
        {
            return (GetMouseWorldPosition() - player.transform.position).normalized;
        }

        public Vector3 GetMouseWorldPosition()
        {
            var mousePosition = Input.mousePosition;
            var mousePositionWorld = mainCamera.ScreenToWorldPoint(mousePosition);
            mousePositionWorld.z = 0f;
            return mousePositionWorld;
        }

        public void ChangeRange(float range)
        {
            currentRange = range;
        }

        public void ChangeAim(AimType changeAimType)
        {
            switch (changeAimType)
            {
                case AimType.Line:
                    lineRenderer.widthCurve = ThinLine;
                    break;
                case AimType.Cone:
                    lineRenderer.widthCurve = ConeLine;
                    break;
                case AimType.CircleRange:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(changeAimType), changeAimType, null);
            }
        }
    }
}