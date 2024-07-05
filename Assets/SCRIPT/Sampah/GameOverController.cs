using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public GameObject gameOverPanel; // Panel Game Over
    public Button restartButton; // Tombol untuk me-restart game
    public TrashSortingGame trashSortingGame; // Referensi ke game utama untuk menghentikan permainan

    void Start()
    {
        // Pastikan panel tidak aktif saat permainan dimulai
        gameOverPanel.SetActive(false);

        // Tambahkan listener untuk tombol restart jika ada
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }
    }

    public void ShowGameOver()
    {
        // Aktifkan panel game over
        gameOverPanel.SetActive(true);

        // Hentikan permainan
        Time.timeScale = 0; // Menghentikan waktu permainan
    }

    public void RestartGame()
    {
        // Reset waktu permainan ke normal
        Time.timeScale = 1;

        // Muat ulang scene saat ini untuk me-restart permainan
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
