using System.ComponentModel;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class FirstPersonController : MonoBehaviour
    {
        [Header("Player")]
        public Transform head;
        public Transform body;

        [Tooltip("How far up can you look?")]
        public float maxUpPitchAngle = 80;

        [Tooltip("How far down can you look?")]
        public float maxDownPitchAngle = -80;

        

        [Header("External")]
        public AbstractInputManager inputManager;

        private float _headPitch = 0; // rotation to look up or down
        
        void Update()
        {
            Vector2 lookMovement = inputManager.GetLookMovement();
            body.transform.Rotate(Vector3.up, lookMovement.x);

            // vertical look
            _headPitch = Mathf.Clamp(_headPitch - lookMovement.y, maxDownPitchAngle, maxUpPitchAngle);
            head.transform.localRotation = Quaternion.Euler(_headPitch, 0, 0);
        }
    }
}