using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class UnityInputManager : AbstractInputManager
    {
        public CursorLockMode cursorLockMode = CursorLockMode.None;
        public float mouseSensitivity = 100;

        [Tooltip("X = Change in mouse position.\nY = Multiplicative factor for camera rotation.")]
        public AnimationCurve mouseLookSensitivityCurve = new AnimationCurve(new Keyframe(0f, 0.1f, 0f, 0f), new Keyframe(1f, 1f, 0f, 0f));
        
        private const string MouseHorizontalAxisName = "Mouse X";
        private const string MouseVerticalAxisName = "Mouse Y";

        void Start()
        {
            Cursor.lockState = cursorLockMode;
        }

        void OnDestroy()
        {
            Cursor.lockState = CursorLockMode.None;
        }

        public override Vector2 GetLookMovement()
        {
            float x = Input.GetAxis(MouseHorizontalAxisName) * mouseSensitivity * Time.deltaTime;
        
            float y = Input.GetAxis(MouseVerticalAxisName) * mouseSensitivity * Time.deltaTime;

            var mouseMovement = new Vector2(x, y);
            var mouseSensitivityFactor = mouseLookSensitivityCurve.Evaluate(mouseMovement.magnitude);

            return mouseMovement * mouseSensitivityFactor;

            //m_TargetCameraState.pitch += mouseMovement.y * mouseSensitivityFactor;
            //var rotationLerpPct = 1f - Mathf.Exp((Mathf.Log(1f - 0.99f) / rotationLerpTime) * Time.deltaTime);
            //pitch = Mathf.Lerp(pitch, target.pitch, rotationLerpPct);
        }

        public override bool FireButtonDown()
        {
            return Input.GetMouseButtonDown(0);
        }

        public override bool FireButtonUp()
        {
            return Input.GetMouseButtonUp(0);
        }
    }
}