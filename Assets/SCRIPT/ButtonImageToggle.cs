using UnityEngine;
using UnityEngine.UI;

public class ButtonImageToggle : MonoBehaviour
{
    [SerializeField] private Sprite initialImage; // Gambar awal
    [SerializeField] private Sprite toggledImage; // Gambar ketika tombol diklik
    [SerializeField] private AudioClip clickSound; // Suara klik
    private Image buttonImage; // Komponen Image dari button
    private AudioSource audioSource; // Komponen AudioSource
    private bool isToggled = false; // Status toggle

    void Start()
    {
        // Mendapatkan komponen Image dari button
        buttonImage = GetComponent<Image>();
        // Mendapatkan komponen AudioSource dari button
        audioSource = GetComponent<AudioSource>();
        // Set gambar awal button jika gambar awal diatur
        if (initialImage != null)
        {
            buttonImage.sprite = initialImage;
        }
    }

    // Fungsi yang dipanggil ketika button diklik
    public void ToggleButtonImage()
    {
        // Mengubah gambar berdasarkan status toggle
        if (isToggled)
        {
            buttonImage.sprite = initialImage;
        }
        else
        {
            buttonImage.sprite = toggledImage;
        }

        // Memainkan suara klik jika ada
        if (clickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSound);
        }

        // Mengubah status toggle
        isToggled = !isToggled;
    }
}
