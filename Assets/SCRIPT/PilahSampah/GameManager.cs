using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int maxHealth = 10;  // Nyawa maksimal
    private int currentHealth;  // Nyawa saat ini
    private int score;          // Skor saat ini

    public Text scoreText;      // UI Text untuk skor
    public Image healthBar;     // UI Image untuk bar nyawa

    private void Start()
    {
        currentHealth = maxHealth;
        score = 0;
        UpdateUI();
    }

    // Fungsi untuk mengurangi nyawa
    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateUI();

        if (currentHealth <= 0)
        {
            // Tampilkan panel game over atau tindakan lainnya
            Debug.Log("Game Over");
        }
    }

    // Fungsi untuk menambah skor
    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    // Fungsi untuk memperbarui UI
    private void UpdateUI()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)currentHealth / maxHealth;
        }

        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    // Fungsi untuk mendapatkan nyawa saat ini
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    // Fungsi untuk mendapatkan skor saat ini
    public int GetCurrentScore()
    {
        return score;
    }
}
