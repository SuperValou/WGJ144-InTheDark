using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public abstract class AbstractInputManager : MonoBehaviour
    {
        public abstract Vector2 GetLookMovement();

        public abstract bool FireButtonDown();
        public abstract bool FireButtonUp();
    }
}