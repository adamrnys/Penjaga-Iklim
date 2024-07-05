using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Drag the Game Over panel here in the inspector
    public GameObject gameOverPanel;

    // This function is called when another collider enters the trigger collider attached to this object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object we collided with has the tag "Acid"
        if (collision.CompareTag("Acid"))
        {
            // Show the Game Over panel
            gameOverPanel.SetActive(true);

            // Optionally, you can add other game over logic here, like stopping the player movement
            // Example:
            // GetComponent<PlayerMovement>().enabled = false;
        }
    }
}
