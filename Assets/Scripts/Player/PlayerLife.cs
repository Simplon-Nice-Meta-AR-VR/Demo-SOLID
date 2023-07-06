using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLife : MonoBehaviour, IDamageable
{
    [SerializeField] private float m_maxHealth = 10f;
    [SerializeField] private GameObject m_playerGameObject;

    // Événement configuré depuis l'éditeur
    //[SerializeField] UnityEvent<float> m_onHealthChanged;

    // Événement configuré par code (delegates)
    private event Action<float> m_onHealthChanged;

    private float m_currentHealth;

    private void Start()
    {
        m_currentHealth = m_maxHealth;
        m_onHealthChanged?.Invoke(m_currentHealth);
    }

    public void TakeDamage(float damage)
    {
        m_currentHealth -= damage;
        m_onHealthChanged?.Invoke(m_currentHealth);

        if (m_currentHealth <= 0)
        {
            m_playerGameObject.SetActive(false);
        }
    }

    public void Subscribe(Action<float> listener)
    {
        m_onHealthChanged += listener;
    }

    public void Unsubscribe(Action<float> listener)
    {
        m_onHealthChanged -= listener;
    }
}
