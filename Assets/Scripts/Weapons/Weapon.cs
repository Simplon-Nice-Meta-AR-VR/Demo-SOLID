using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IAttackWeapon
{
    [SerializeField] private float m_damage = 5f;

    public abstract void Attack();
}
