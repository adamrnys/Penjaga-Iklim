using UnityEngine;
using UnityEngine.UI;

public class ScoreSampah : MonoBehaviour
{
    public Text scoreText;
    private int score; // Gunakan tipe data int untuk skor jika ingin menampilkannya sebagai bilangan bulat

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trash"))
        {
            score += 1; // Tambahkan skor sebanyak 1 setiap kali player menyentuh objek dengan tag "Trash"
            scoreText.text = score.ToString(); // Ubah cara mengubah skor menjadi string sesuai tipe data yang digunakan
            
            Destroy(collision.gameObject); // Hapus objek "Trash" setelah disentuh (opsional)
        }
    }

}
