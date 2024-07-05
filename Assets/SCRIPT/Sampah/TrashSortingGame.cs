using UnityEngine;
using UnityEngine.UI;

public class TrashSortingGame : MonoBehaviour
{
    public Button buttonA; // Button untuk tong sampah A
    public Button buttonB; // Button untuk tong sampah B
    public Button buttonC; // Button untuk tong sampah C

    public Text scoreText; // Teks untuk menampilkan skor
    public HealthBarController healthBarController; // Kontroler health bar
    public GameOverController gameOverController; // Kontroler game over
    public Animator scoreTextAnimator; // Animator untuk animasi scoreText

    private int score = 0; // Skor pemain
    private GameObject currentTrash; // Sampah yang sedang aktif

    void Start()
    {
        // Menambahkan listener ke setiap button
        buttonA.onClick.AddListener(() => OnBinClicked("A"));
        buttonB.onClick.AddListener(() => OnBinClicked("B"));
        buttonC.onClick.AddListener(() => OnBinClicked("C"));

        UpdateUI(); // Memperbarui UI awal

        // Mengambil komponen Animator dari scoreText
        scoreTextAnimator = scoreText.GetComponent<Animator>();
    }

    // Memperbarui tampilan skor pada UI
    void UpdateUI()
    {
        scoreText.text = score.ToString(); // Menampilkan hanya angka skor
    }

    // Mengatur sampah yang saat ini jatuh
    public void SetCurrentTrash(GameObject trash)
    {
        currentTrash = trash;
    }

    // Fungsi yang dipanggil ketika button tong sampah diklik
    void OnBinClicked(string binType)
    {
        if (currentTrash != null)
        {
            string trashType = currentTrash.tag;
            if (trashType == binType)
            {
                score += 10;
                Destroy(currentTrash);
            }
            else
            {
                if (healthBarController != null)
                {
                    healthBarController.ReduceLives();
                    // Periksa jika nyawa habis
                    if (healthBarController.GetCurrentLives() <= 0)
                    {
                        gameOverController.ShowGameOver();
                        // Memicu animasi game over pada scoreText
                        if (scoreTextAnimator != null)
                        {
                            scoreTextAnimator.SetTrigger("isGameOver");
                        }
                    }
                }
                else
                {
                    Debug.LogError("HealthBarController is not assigned.");
                }
            }

            UpdateUI(); // Perbarui UI setelah perubahan
        }
        else
        {
            Debug.LogError("CurrentTrash is not set.");
        }
    }
}
