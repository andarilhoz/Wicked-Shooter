using UnityEngine;
using _WicketShooter.Scripts.Aim;

namespace _WicketShooter.Scripts.AttackWeapons.Weapons
{
    public class PistolBullet : MonoBehaviour, IWeapon
    {
        public AimManager AimManager { get; private set; }
        
        private const float SHOT_COOLDOWN = .6f;
        private float coolDownTimer = 0;
        private const float DAMAGE = 3;
        private const float PROJECTILE_SPEED = 3f;
        
        public void Shoot()
        {
            if ( coolDownTimer > 0 )
            {
                return;
            }
            
            coolDownTimer = SHOT_COOLDOWN;
            var initialPosition = new Vector3(this.transform.position.x, this.transform.position.y, 0);
            Debug.Log("Instantiate Bullet");
            var bullet =  Instantiate(Resources.Load("BulletPrefab",typeof(GameObject))) as GameObject;    
            bullet.transform.position = initialPosition;
            bullet.GetComponent<Rigidbody2D>().velocity = AimManager.MousePositionInRelationToPlayer() * PROJECTILE_SPEED;
        }

        private void Update()
        {
            if ( coolDownTimer > 0 )
            {
                coolDownTimer -= Time.deltaTime;
            }
        }

        public void Destroy()
        {
            Object.Destroy(this);
        }

        public void Initialize(AimManager aimManager)
        {
            AimManager = aimManager;
        }
    }
}