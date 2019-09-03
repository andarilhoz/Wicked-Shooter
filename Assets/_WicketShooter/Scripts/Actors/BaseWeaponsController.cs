using System;
using System.Collections.Generic;
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

        private RangeWeaponType currentWeapon;

        private List<RangeWeaponType> weaponWheel = new List<RangeWeaponType>{ RangeWeaponType.Pistol, RangeWeaponType.Rifle }; 

        public BaseWeaponsController(MeleeWeapons melee, RangeWeaponType range, GameObject gameObject, AimManager playerAim)
        {
            aimManager = playerAim;
            ChangeWeapon(range, gameObject);
            ChangeMeleeWeapon(melee, gameObject);
        }

        public void ChangeWeapon(RangeWeaponType rangeWeaponType, GameObject gameObject)
        {
            if ( rangeWeaponType.Equals(currentWeapon) )
            {
                return;
            }

            iRangeWeapon?.Destroy();

            switch (rangeWeaponType)
            {
                case RangeWeaponType.Pistol:
                    iRangeWeapon = gameObject.AddComponent<PistolBullet>();
                    aimManager.ChangeRange(1.8f);
                    aimManager.ChangeAim(AimType.Line);
                    break;
                case RangeWeaponType.Rifle:
                    iRangeWeapon = gameObject.AddComponent<RifleBullet>();
                    aimManager.ChangeRange(1.8f);
                    aimManager.ChangeAim(AimType.Line);
                    break;
                case RangeWeaponType.Shotgun:
                    iRangeWeapon = gameObject.AddComponent<ShotgunBullet>();
                    aimManager.ChangeRange(1f);
                    aimManager.ChangeAim(AimType.Cone);
                    break;
                case RangeWeaponType.Granade:
                    aimManager.ChangeAim(AimType.CircleRange);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            currentWeapon = rangeWeaponType;
            iRangeWeapon?.Initialize(aimManager);
        }
        
        public void RotateRangeWeapon(GameObject gameObject)
        {
            var currentIndex = weaponWheel.IndexOf(currentWeapon);;
            var nextWeapon = weaponWheel[(currentIndex + 1) % weaponWheel.Count];
            ChangeWeapon(nextWeapon,gameObject);
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