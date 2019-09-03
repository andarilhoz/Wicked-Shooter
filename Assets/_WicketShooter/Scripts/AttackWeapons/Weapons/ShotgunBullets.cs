using UnityEngine;
using _WicketShooter.Scripts.Aim;

namespace _WicketShooter.Scripts.AttackWeapons.Weapons
{
    public class ShotgunBullet : MonoBehaviour, IWeapon
    {
        
        public AimManager AimManager { get; private set; }
        
        public void Shoot()
        {
            var initialPosition = new Vector3(this.transform.position.x, this.transform.position.y + 1f, 0);
            Debug.Log("Instantiate Shotgun Bullets");
            /*var bullet =  Instantiate(Resources.Load("BulletPrefab",typeof(GameObject))) as GameObject;    
            bullet.transform.position = initialPosition;
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,3f);*/
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