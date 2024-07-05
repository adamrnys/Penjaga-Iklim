using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    private bool moveUp;
    private bool moveDown;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveUp)
        {
            playerDirection = Vector2.up;
        }
        else if (moveDown)
        {
            playerDirection = Vector2.down;
        }
        else
        {
            playerDirection = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        // Mengatur kecepatan Rigidbody2D berdasarkan arah yang ditentukan
        rb.velocity = playerDirection * playerSpeed;
    }

    // Fungsi untuk menangani event tekan tombol UI
    public void OnPressMoveUp()
    {
        moveUp = true;
    }

    public void OnReleaseMoveUp()
    {
        moveUp = false;
    }

    public void OnPressMoveDown()
    {
        moveDown = true;
    }

    public void OnReleaseMoveDown()
    {
        moveDown = false;
    }
}
