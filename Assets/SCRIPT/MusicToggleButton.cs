using UnityEngine;
using UnityEngine.UI;

public class MusicToggleButton : MonoBehaviour
{
    public Sprite musicOnSprite; // Sprite untuk status musik On
    public Sprite musicOffSprite; // Sprite untuk status musik Off

    private Button toggleButton;
    private Image buttonImage;

    void Start()
    {
        // Temukan komponen Button dan Image pada tombol ini
        toggleButton = GetComponent<Button>();
        buttonImage = toggleButton.GetComponent<Image>();

        // Set listener untuk tombol
        toggleButton.onClick.AddListener(ToggleMusic);

        // Set gambar tombol berdasarkan status musik saat ini
        UpdateButtonImage();
    }

    void ToggleMusic()
    {
        // Memastikan instance BackgroundMusic ada sebelum mengaksesnya
        if (BackgroundMusic.Instance != null)
        {
            BackgroundMusic.Instance.ToggleMusic();
            UpdateButtonImage();
        }
    }

    void UpdateButtonImage()
    {
        // Ubah gambar tombol berdasarkan apakah musik sedang dimainkan
        if (BackgroundMusic.Instance != null && BackgroundMusic.Instance.GetComponent<AudioSource>().isPlaying)
        {
            buttonImage.sprite = musicOnSprite;
        }
        else
        {
            buttonImage.sprite = musicOffSprite;
        }
    }
}
