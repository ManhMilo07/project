using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider; // Slider của thanh máu
    public GameObject deathPanel; // Gán panel trong Inspector

    void Start()
    {
        if (healthSlider == null)
        {
            Debug.LogError("Health Slider is not assigned in the inspector.");
        }

        if (deathPanel != null)
        {
            deathPanel.SetActive(false); // Đảm bảo panel bắt đầu không hoạt động
        }
        else
        {
            Debug.LogError("Death panel is not assigned in the inspector.");
        }
    }

    public void UpdateHealth(int value)
    {
        if (healthSlider != null)
        {
            healthSlider.value = value;

            if (healthSlider.value <= 0)
            {
                ShowDeathPanel();
            }
        }
    }

    void ShowDeathPanel()
    {
        if (deathPanel != null)
        {
            deathPanel.SetActive(true); // Hiển thị panel khi giá trị thanh máu về 0
            Time.timeScale = 0f; // Dừng game
        }
        else
        {
            Debug.LogError("Death panel is not assigned in the inspector.");
        }
    }

}
