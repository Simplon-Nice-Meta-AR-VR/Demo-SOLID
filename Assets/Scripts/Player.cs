using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody m_rigidbody;
    [SerializeField] private float m_speed = 3.5f;

    [Space(10)]
    [SerializeField] Sword m_sword;
    [SerializeField] Bow m_bow;

    [Space(10)]
    [SerializeField] Animator m_playerAnimator;
    [SerializeField] Animator m_swordAnimator;

    [Space(10)]
    [SerializeField] GameObject m_projectilePrefab;

    private int m_currentWeaponIndex = 0;

    private void Update()
    {
        // Input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Move the player
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        m_rigidbody.velocity = direction * m_speed + m_rigidbody.velocity.y * Vector3.up;

        // Rotate the player
        if (direction != Vector3.zero)
        {
            m_rigidbody.rotation = Quaternion.LookRotation(direction);
        }

        // Animate the player
        m_playerAnimator.SetFloat("Speed", direction.magnitude);

        // Attack with the current weapon
        if (Input.GetButtonDown("Fire1"))
        {
            if (m_currentWeaponIndex == 0)
            {
                m_swordAnimator.SetTrigger("Attack");
                // Catches enemy in front of the player and kill them
                if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 2f))
                {
                    if (hit.collider.CompareTag("Enemy"))
                    {
                        hit.collider.GetComponent<Enemy>().TakeDamage(10f);
                    }
                }
            }
            else
            {
                StartCoroutine(ProjectileCoroutine());
            }
        }

        // Switch weapons
        if (Input.GetButtonDown("Fire2"))
        {
            m_currentWeaponIndex = (m_currentWeaponIndex + 1) % 2;
        }
    }
    
    private IEnumerator ProjectileCoroutine()
    {
        GameObject projectile = Instantiate(m_projectilePrefab, transform.position + transform.forward, Quaternion.identity);

        Vector3 direction = transform.forward;
        float distance = 0f;

        // Move the projectile forward until it hits an enemy or reaches max distance
        while (distance < 10f)
        {
            float advancement = 10f * Time.deltaTime;
            projectile.transform.position += direction * advancement;
            distance += advancement;

            if (Physics.Raycast(projectile.transform.position, direction, out RaycastHit hit, 0.5f))
            {
                // Hitting enemy
                if (hit.collider.CompareTag("Enemy"))
                {
                    hit.collider.GetComponent<Enemy>().TakeDamage(5f);
                }

                // if hitting anything, destroy projectile
                break;
            }

            yield return null;
        }

        Destroy(projectile);
    }
}
