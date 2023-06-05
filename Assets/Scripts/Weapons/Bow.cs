using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField] private float m_damage = 5f;

    public float Damage => m_damage;

    public void Repair()
    {

    }
}
