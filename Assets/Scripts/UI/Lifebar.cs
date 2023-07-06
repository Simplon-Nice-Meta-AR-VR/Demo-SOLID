using UnityEngine;
using UnityEngine.UI;

public class Lifebar : MonoBehaviour
{
    [SerializeField] private Slider m_lifebar;
    [SerializeField] private float m_maxLife = 10f;
    [SerializeField] private PlayerLife m_playerLife;

    private void OnEnable() {
        m_playerLife.Subscribe(UpdateLifebar);
    }

    private void OnDisable() {
        m_playerLife.Unsubscribe(UpdateLifebar);
    }

    public void UpdateLifebar(float currentLife)
    {
        m_lifebar.value = currentLife / m_maxLife;
    }
}
