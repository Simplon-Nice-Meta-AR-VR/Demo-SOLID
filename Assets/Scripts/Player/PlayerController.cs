using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TNRD;

// Handles player input
public class PlayerController : MonoBehaviour
{
    [SerializeField] private SerializableInterface<IMove> m_playerMovementInterface;
    [SerializeField] private SerializableInterface<IAttack> m_playerAttackInterface;
    [SerializeField] private SerializableInterface<IDamageable> m_playerDamageableInterface;

    private IMove m_playerMovement => m_playerMovementInterface.Value;
    private IAttack m_playerAttack => m_playerAttackInterface.Value;
    private IDamageable m_playerDamageable => m_playerDamageableInterface.Value;

    void Update()
    {
        // Move input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        m_playerMovement.Move(new Vector2(horizontalInput, verticalInput));

        bool attackInput = Input.GetButtonDown("Fire1");
        if (attackInput)
        {
            m_playerAttack.Attack();
        }

        bool switchWeaponInput = Input.GetButtonDown("Fire2");
        if (switchWeaponInput)
        {
            m_playerAttack.ChangeWeapon();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_playerDamageable.TakeDamage(1f);
        }
    }
}
