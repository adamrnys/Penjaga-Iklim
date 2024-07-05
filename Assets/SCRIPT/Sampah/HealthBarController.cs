using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Image healthBarFill; // Image untuk mengisi health bar
    public int maxLives = 3; // Maksimum nyawa yang dimiliki pemain
    private int currentLives; // Nyawa saat ini
    public Text scoreText;

    private Animator scoreTextAnimator;

    void Start()
    {
        currentLives = maxLives; // Inisialisasi nyawa saat mulai
        UpdateHealthBar(); // Perbarui tampilan health bar

        scoreTextAnimator = scoreText.GetComponent<Animator>();
        
        if (scoreTextAnimator != null)
        {
            scoreTextAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
        }
    }

    // Mengurangi nyawa pemain
    public void ReduceLives()
    {
        if (currentLives > 0)
        {
            currentLives--;
            UpdateHealthBar(); // Perbarui tampilan health bar

            if (currentLives <= 0)
            {
                Debug.Log("Game Over");
                AnimateScoreText();
            }
        }
    }

    // Mendapatkan nilai nyawa saat ini
    public int GetCurrentLives()
    {
        return currentLives;
    }

    // Memperbarui tampilan health bar berdasarkan nyawa saat ini
    private void UpdateHealthBar()
    {
        float fillAmount = (float)currentLives / maxLives;
        healthBarFill.fillAmount = fillAmount;
    }

    void AnimateScoreText()
    {
        // Mengatur trigger 'isGameOver' di Animator untuk memulai animasi scoreText
        scoreTextAnimator.SetTrigger("isGameOver");
    }
}
