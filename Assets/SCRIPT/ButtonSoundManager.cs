using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonSoundManager : MonoBehaviour
{
    public AudioClip buttonClickSound; // Drag and drop your audio clip here in the inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component missing from this game object. Please add one.");
        }
    }

    public void PlayButtonClickSoundAndChangeScene(string sceneName)
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
            StartCoroutine(ChangeSceneAfterSound(sceneName));
        }
        else
        {
            Debug.LogError("Missing AudioSource or AudioClip. Please assign them in the inspector.");
        }
    }

    private IEnumerator ChangeSceneAfterSound(string sceneName)
    {
        // Wait for the duration of the audio clip before changing the scene
        yield return new WaitForSeconds(buttonClickSound.length);
        SceneManager.LoadScene(sceneName);
    }
}
