using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int score = 0;
    public Text scoreText; // UI Text untuk menampilkan skor

    // Memanggil metode untuk menambahkan skor
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
