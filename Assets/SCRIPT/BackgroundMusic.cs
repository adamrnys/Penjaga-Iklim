using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic Instance { get; private set; }
    private AudioSource audioSource;
    private bool isMusicPlaying = true;

    public string[] stopMusicScenes;

    void Awake()
    {
        // Implement Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        audioSource = GetComponent<AudioSource>();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (System.Array.Exists(stopMusicScenes, element => element == scene.name))
        {
            audioSource.Pause();
        }
        else if (isMusicPlaying)
        {
            audioSource.UnPause();
        }
    }

    public void ToggleMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
            isMusicPlaying = false;
        }
        else
        {
            audioSource.Play();
            isMusicPlaying = true;
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
