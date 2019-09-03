using System;
using UnityEngine;
using _WicketShooter.Scripts.Aim;
using _WicketShooter.Scripts.AttackWeapons;
using _WicketShooter.Scripts.AttackWeapons.Melee;
using _WicketShooter.Scripts.AttackWeapons.Weapons;

namespace _WicketShooter.Scripts.Actors
{
    public class BaseWeaponsController
    {
        private IWeapon iRangeWeapon;

        private IMelee iMeleeWeapon;

        private AimManager aimManager;

        public BaseWeaponsController(MeleeWeapons melee, RangeWeaponType range, GameObject gameObject, AimManager playerAim)
        {
            aimManager = playerAim;
            ChangeWeapon(range, gameObject);
            ChangeMeleeWeapon(melee, gameObject);
        }

        public void ChangeWeapon(RangeWeaponType rangeWeaponType, GameObject gameObject)
        {
            iRangeWeapon?.Destroy();

            switch (rangeWeaponType)
            {
                case RangeWeaponType.Pistol:
                    iRangeWeapon = gameObject.AddComponent<PistolBullet>();
                    aimManager.ChangeRange(5f);
                    aimManager.ChangeAim(AimType.Line);
                    break;
                case RangeWeaponType.Rifle:
                    iRangeWeapon = gameObject.AddComponent<RifleBullet>();
                    aimManager.ChangeRange(5f);
                    aimManager.ChangeAim(AimType.Line);
                    break;
                case RangeWeaponType.Shotgun:
                    iRangeWeapon = gameObject.AddComponent<ShotgunBullet>();
                    aimManager.ChangeRange(2f);
                    aimManager.ChangeAim(AimType.Cone);
                    break;
                case RangeWeaponType.Granade:
                    aimManager.ChangeAim(AimType.CircleRange);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            iRangeWeapon?.Initialize(aimManager);
        }

        public void ChangeMeleeWeapon(MeleeWeapons weaponType, GameObject gameObject)
        {
            iMeleeWeapon?.Destroy();

            switch (weaponType)
            {
                case MeleeWeapons.Punch:
                    iMeleeWeapon = gameObject.AddComponent<Punch>();
                    break;
                case MeleeWeapons.Knife:
                    break;
                case MeleeWeapons.Katana:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(weaponType), weaponType, null);
            }
        }

        public void Fire()
        {
            iRangeWeapon.Shoot();
        }

        public void Attack()
        {
            iMeleeWeapon.Attack();
        }
    }
}