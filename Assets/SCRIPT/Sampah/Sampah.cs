using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sampah : MonoBehaviour
{
    public float playerSpeed;    // Kecepatan pemain
    private Rigidbody2D rb;      // Komponen Rigidbody2D
    private Vector2 playerDirection; // Arah gerakan pemain
    private bool moveRight;      // Apakah pemain bergerak ke kanan
    private bool moveLeft;       // Apakah pemain bergerak ke kiri

    // Start dipanggil sebelum frame pertama update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update dipanggil sekali setiap frame
    void Update()
    {
        if (moveRight)
        {
            playerDirection = Vector2.right;
        }
        else if (moveLeft)
        {
            playerDirection = Vector2.left;
        }
        else
        {
            playerDirection = Vector2.zero;
        }
    }

    // FixedUpdate dipanggil setiap frame, cocok untuk fisika
    void FixedUpdate()
    {
        // Mengatur kecepatan Rigidbody2D berdasarkan arah yang ditentukan
        rb.velocity = playerDirection * playerSpeed;
    }

    // Fungsi untuk menangani event tekan tombol UI untuk bergerak ke kanan
    public void OnPressMoveRight()
    {
        moveRight = true;
    }

    // Fungsi untuk menangani event lepas tombol UI dari bergerak ke kanan
    public void OnReleaseMoveRight()
    {
        moveRight = false;
    }

    // Fungsi untuk menangani event tekan tombol UI untuk bergerak ke kiri
    public void OnPressMoveLeft()
    {
        moveLeft = true;
    }

    // Fungsi untuk menangani event lepas tombol UI dari bergerak ke kiri
    public void OnReleaseMoveLeft()
    {
        moveLeft = false;
    }
}
