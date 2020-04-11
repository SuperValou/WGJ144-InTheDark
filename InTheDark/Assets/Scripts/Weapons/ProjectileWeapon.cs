using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class ProjectileWeapon : AbstractWeapon
    {
        [Header("Self")]
        public bool canCharge = true;
        [Tooltip("Time in second to fully charge")]
        public float timeToCharge = 3;

        [Tooltip("Minimum charge to shoot a charged projectile")]
        public float chargeThreshold = 0.5f;

        [Header("Parts")]
        public Projectile projectilePrefab;
        public Projectile chargedProjectilePrefab;
        
        // ---
        private float _holdTime;
        private bool _isCharging;

        public float Charge { get; private set; } = 0;
        
        public override void Fire()
        {
            ShootProjectile();

            // begin charge
            if (!canCharge)
            {
                return;
            }

            _holdTime = Time.time;
            _isCharging = true;

            //chargingParticle.Play();
            //lineParticles.Play();
            //cannonModel.DOLocalMoveZ(cannonLocalPos.z - .22f, chargeTime);
            //cannonModel.GetComponentInChildren<Renderer>().material.DOColor(finalEmissionColor, "_EmissionColor", chargeTime);
        }

        public override void ReleaseFire()
        {
            _isCharging = false;
            if (Charge > chargeThreshold)
            {
                ShootChargedProjectile();
            }

            Charge = 0;
        }

        private void ShootProjectile()
        {
            Instantiate(projectilePrefab, this.transform.position, this.transform.rotation);
        }

        private void ShootChargedProjectile()
        {
            var projectile = Instantiate(projectilePrefab, this.transform.position, this.transform.rotation);
            projectile.transform.localScale *= 1 + Charge * 5;

            //chargedCannonParticle.Play();
            //chargedParticle.transform.DOScale(0, .05f).OnComplete(() => chargedParticle.Clear());
            //lineParticles.Stop();

            //Sequence s = DOTween.Sequence();
            //s.Append(cannonModel.DOPunchPosition(new Vector3(0, 0, -punchStrenght), punchDuration, punchVibrato, punchElasticity));
            //s.Join(cannonModel.GetComponentInChildren<Renderer>().material.DOColor(normalEmissionColor, "_EmissionColor", punchDuration));
            //s.Join(cannonModel.DOLocalMove(cannonLocalPos, punchDuration).SetDelay(punchDuration));
        }

        void Update()
        {
            // Charging up
            if (_isCharging && timeToCharge > 0)
            {
                Charge = Mathf.Clamp01((Time.time - _holdTime) / timeToCharge);
            }

            // Charged
            if (Charge >= 1)
            {
                //chargedParticle.Play();
                //chargedParticle.transform.localScale = Vector3.zero;
                //chargedParticle.transform.DOScale(1, .4f).SetEase(Ease.OutBack);
                //chargedEmission.Play();
            }
        }
    }
}