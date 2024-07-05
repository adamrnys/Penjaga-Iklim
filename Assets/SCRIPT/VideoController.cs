using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer; // Menyembunyikan dari akses publik, tapi masih dapat diatur di Inspector
    [SerializeField] private string sceneToLoad; // Menyembunyikan dari akses publik, tapi masih dapat diatur di Inspector

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
        videoPlayer.Play();
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Memastikan bahwa sceneToLoad tidak kosong
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Nama scene tidak ditentukan. Harap masukkan nama scene di Inspector.");
        }
    }
}
