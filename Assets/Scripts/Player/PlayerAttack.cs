using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TNRD;

// Makes the player attack
public class PlayerAttack : MonoBehaviour, IAttack
{
    [Space(10)]
    [SerializeField] private SerializableInterface<IAttackWeapon>[] m_weapons;

    private int m_currentWeaponIndex = 0;

    public void Attack()
    {
        m_weapons[m_currentWeaponIndex].Value.Attack();
    }

    public void ChangeWeapon()
    {
        m_currentWeaponIndex = (m_currentWeaponIndex + 1) % 2;
    }
}
