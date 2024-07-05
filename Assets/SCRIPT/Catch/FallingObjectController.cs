using UnityEngine;

public class FallingObjectController : MonoBehaviour
{
    public float fallSpeed = 2f;

    void Update()
    {
        // Gerakkan objek ke bawah setiap frame
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Temukan GameController dan tambahkan skor
            GameController gameController = FindObjectOfType<GameController>();
            if (gameController != null)
            {
                gameController.AddScore(10); // Tambahkan poin (sesuaikan dengan kebutuhan)
            }
            Destroy(gameObject); // Hancurkan objek setelah tertangkap
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject); // Hancurkan objek jika mencapai tanah
        }
    }
}
