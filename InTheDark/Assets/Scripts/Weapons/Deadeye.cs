using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Deadeye : MonoBehaviour
    {
        public Camera eye;
        public Transform arm;

        public float maxDistance = 100;
        
        void Update()
        {
            Ray ray = new Ray(eye.transform.position, eye.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, maxDistance))
            {
                arm.transform.LookAt(raycastHit.point);
            }
            else
            {
                arm.transform.LookAt(arm.transform.position + eye.transform.forward);
            }
        }
    }
}