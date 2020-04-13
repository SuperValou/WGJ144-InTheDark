using Assets.Scripts.Utilities;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Deadeye : MonoBehaviour
    {
        public Camera eye;
        public Transform arm;

        public float maxDistance = 100;

        private Vector3 _rayVector = new Vector3(0.5f, 0.5f, 0);

        void Update()
        {
            Ray ray = eye.ViewportPointToRay(_rayVector);
            var layers = LayerMask.GetMask("Default", "FoeLayer", "Ground&Walls");
            if (Physics.Raycast(ray, out RaycastHit raycastHit, maxDistance, layers))
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