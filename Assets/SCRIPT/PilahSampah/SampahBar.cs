using UnityEngine;
using UnityEngine.UI;

public class SampahBar : MonoBehaviour
{
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;
    private NyawaSampah playerNyawa;

    // Method untuk mengatur gambar HealthBar
    public void SetHealthBarImages(Image totalBar, Image currentBar)
    {
        totalhealthBar = totalBar;
        currenthealthBar = currentBar;
    }

    private void Start()
    {
        // Pastikan referensi playerNyawa diatur ke karakter aktif.
        playerNyawa = FindObjectOfType<CharacterManager>().GetActivePlayerNyawa();
        UpdateHealthBar();
    }

    private void Update()
    {
        if (playerNyawa != null)
        {
            UpdateHealthBar();
        }
    }

    // Method untuk mengatur playerNyawa
    public void SetPlayerNyawa(NyawaSampah nyawa)
    {
        playerNyawa = nyawa;
        UpdateHealthBar();
    }

    // Method untuk mengupdate tampilan bar kesehatan
    private void UpdateHealthBar()
    {
        if (playerNyawa != null)
        {
            float normalizedHealth = playerNyawa.GetCurrentHealthNormalized();
            totalhealthBar.fillAmount = normalizedHealth;
            currenthealthBar.fillAmount = normalizedHealth;
        }
    }
}
