using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Nyawa : MonoBehaviour
{
    public int maxHealth = 3; // Jumlah nyawa maksimal, misalnya 10
    public int health;         // Jumlah nyawa saat ini
    public GameObject gameOverPanel;
    public Text scoreText;

    private Animator scoreTextAnimator;
    private void Start()
    {
        // Inisialisasi nyawa saat ini dengan nyawa maksimal saat permainan dimulai
        health = maxHealth;
        scoreTextAnimator = scoreText.GetComponent<Animator>();
        
        if (scoreTextAnimator != null)
        {
            scoreTextAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
        }
    }

    // Fungsi ini dipanggil ketika objek bertabrakan dengan collider lain
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Memeriksa apakah objek yang bertabrakan memiliki tag "obstacle"
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Kurangi nyawa pemain
            health--;

            // Cek jika nyawa pemain sudah habis
            if (health <= 0)
            {
                gameOverPanel.SetActive(true);
            
                // Memanggil fungsi untuk memulai animasi scoreText
                AnimateScoreText();
                Time.timeScale = 0;
            }
        }
    }

    // Fungsi ini dipanggil ketika objek memasuki trigger collider lain
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Memeriksa apakah objek yang memasuki trigger memiliki tag "obstacle"
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Kurangi nyawa pemain
            health--;

            // Cek jika nyawa pemain sudah habis
            if (health <= 0)
            {
                gameOverPanel.SetActive(true);
            
                // Memanggil fungsi untuk memulai animasi scoreText
                AnimateScoreText();
                Time.timeScale = 0;
                
            }
        }
    }

    // Properti untuk mendapatkan nyawa saat ini
    public float currentNyawa
    {
        get { return (float)health / maxHealth; } // Mengembalikan nilai antara 0 dan 1
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void AnimateScoreText()
    {
        // Mengatur trigger 'isGameOver' di Animator untuk memulai animasi scoreText
        scoreTextAnimator.SetTrigger("isGameOver");
    }
}
