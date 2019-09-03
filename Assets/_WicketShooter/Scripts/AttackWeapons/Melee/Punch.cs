using UnityEngine;

namespace _WicketShooter.Scripts.AttackWeapons.Melee
{
    public class Punch : MonoBehaviour, IMelee
    {
        public void Attack()
        {
            Debug.Log("Melee punch attack");
        }

        public void Destroy()
        {
            Object.Destroy(this);
        }
    }
}