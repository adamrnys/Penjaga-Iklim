using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;  // Diperlukan untuk menggunakan Coroutine

public class Portal : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "NextScene";  // Nama scene dapat diubah melalui Inspector
    [SerializeField] private float delay = 2.0f;  // Waktu delay dalam detik, dapat diubah melalui Inspector

    // Fungsi ini dipanggil ketika collider dengan `IsTrigger` menyentuh collider lain
    void OnTriggerEnter2D(Collider2D other)
    {
        // Periksa apakah objek yang menyentuh portal adalah pemain
        if (other.CompareTag("Player"))
        {
            // Mulai coroutine untuk menyelesaikan permainan dengan delay
            StartCoroutine(FinishGameWithDelay());
        }
    }

    // Coroutine untuk menunda pergantian scene
    IEnumerator FinishGameWithDelay()
    {
        Debug.Log("Player reached the portal. Finishing game...");
        
        // Tambahkan efek tambahan di sini jika diperlukan, misalnya animasi atau suara

        // Tunggu selama 'delay' detik
        yield return new WaitForSeconds(delay);
        
        // Setelah delay, pindahkan ke scene berikutnya
        SceneManager.LoadScene(nextSceneName);
    }
}
