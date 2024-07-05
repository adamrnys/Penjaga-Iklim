using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public PlayerMovement playerMovement;

    // Assign PlayerMovement reference in Unity Editor
    public void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void MoveRight()
    {
        playerMovement.Move(1f); // Gerakkan ke kanan dengan input positif
    }

    public void MoveLeft()
    {
        playerMovement.Move(-1f); // Gerakkan ke kiri dengan input negatif
    }

    public void Jump()
    {
        playerMovement.Jump(); // Panggil fungsi Jump dari PlayerMovement
    }
}
