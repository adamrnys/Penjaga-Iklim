using UnityEngine;
using UnityEngine.UI;

public class ScorePilahSampah : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trash"))
        {
            gameManager.IncreaseScore(1);
            Destroy(collision.gameObject);
        }
    }
}
