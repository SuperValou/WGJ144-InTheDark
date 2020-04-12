using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public abstract class AbstractWeapon : MonoBehaviour
    {
        public WeaponName weaponName;
        
        public abstract void Fire();
        public abstract void ReleaseFire();
    }
}