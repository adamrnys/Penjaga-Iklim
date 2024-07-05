using UnityEngine;

public class NyawaSampah : MonoBehaviour
{
    public int maxHealth = 100;  // Kesehatan maksimal
    private int currentHealth;   // Kesehatan saat ini

    private void Start()
    {
        currentHealth = maxHealth;  // Inisialisasi kesehatan awal
    }

    // Method untuk mengurangi kesehatan
    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Pastikan tidak melebihi kesehatan maksimal
    }

    // Method untuk mendapatkan kesehatan saat ini dalam bentuk yang normalisasi (0 sampai 1)
    public float GetCurrentHealthNormalized()
    {
        return (float)currentHealth / maxHealth;
    }
}
