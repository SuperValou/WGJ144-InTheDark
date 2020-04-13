using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Controllers;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class WeaponManager : MonoBehaviour
    {
        public AbstractInputManager inputManager;

        private ICollection<AbstractWeapon> _weapons = new List<AbstractWeapon>();

        private AbstractWeapon _mainWeapon;

        void Start()
        {
            _weapons = this.GetComponentsInChildren<AbstractWeapon>()?.ToList() ?? new List<AbstractWeapon>();
            _mainWeapon = _weapons.First();
        }

        void Update()
        {
            if (inputManager.FireButtonDown())
            {
                _mainWeapon.Fire();
            }

            //RELEASE
            if (inputManager.FireButtonUp())
            {
                _mainWeapon.ReleaseFire();
            }
        }
    }
}