﻿using UnityEngine;

namespace _WicketShooter.Scripts.Camera
{
    //will support different devices resolution. (landscape)
    [RequireComponent(typeof(UnityEngine.Camera))]
    public class CameraAdjust : MonoBehaviour
    {
        private UnityEngine.Camera cameraComponent;

        private const float SCENE_WIDTH = 5.5f;

        private void Awake()
        {
            cameraComponent = GetComponent<UnityEngine.Camera>();
        }

        private void Start()
        {
            var unitsPerPixel = SCENE_WIDTH / Screen.width;
            var desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;
            cameraComponent.orthographicSize = desiredHalfHeight;
        }
    }
}