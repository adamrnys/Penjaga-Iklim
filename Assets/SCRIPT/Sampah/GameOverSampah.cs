using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverSampah : MonoBehaviour
{

    public GameObject gameOverPanel;
    public Text scoreText;
    public int health;

    private Animator scoreTextAnimator; // Animator untuk mengatur animasi scoreText

    void Start()
    {
        scoreTextAnimator = scoreText.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            gameOverPanel.SetActive(true);
            
            // Memanggil fungsi untuk memulai animasi scoreText
            AnimateScoreText();
        }
       
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
