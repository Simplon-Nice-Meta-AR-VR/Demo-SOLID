using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private float m_damage = 10f;

    public float Damage => m_damage;

    public void Repair()
    {

    }
}
