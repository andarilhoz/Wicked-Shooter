using _WicketShooter.Scripts.Aim;

namespace _WicketShooter.Scripts.AttackWeapons.Weapons
{
    public interface IWeapon
    {
        void Shoot();
        void Destroy();
        void Initialize(AimManager aimManager);
        AimManager AimManager { get;}
    }
}