using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : EnemyDamage
{
    public GameObject player;    // Referensi ke objek pemain
    public float speed;          // Kecepatan gerak musuh
    public float chaseRange;     // Jarak maksimum di mana musuh akan mulai mengejar
    private float distance;      // Jarak antara musuh dan pemain

    // Start is called before the first frame update
    void Start()
    {
        // Inisialisasi dapat dilakukan di sini jika diperlukan
    }

    // Update is called once per frame
    void Update()
    {
        // Hitung jarak antara musuh dan pemain
        distance = Vector2.Distance(transform.position, player.transform.position);

        // Jika jarak kurang dari atau sama dengan chaseRange, musuh akan mengejar pemain
        if(distance <= chaseRange)
        {
            // Hitung arah dari musuh ke pemain
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();

            // Pindahkan musuh menuju pemain
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
