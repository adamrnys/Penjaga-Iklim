using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Referensi ke transform pemain
    public Vector3 offset;    // Offset dari pemain

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player not assigned to the camera.");
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 newPosition = player.position + offset;
            newPosition.z = transform.position.z;  // Menjaga posisi z kamera
            transform.position = newPosition;
        }
    }
}