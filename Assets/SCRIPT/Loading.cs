using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Transform masukanLoadingbar;

    [SerializeField]
    private float nilaiSekarang;
    [SerializeField]
    private float nilaiKecepatan;

    // Start is called before the first frame update
    void Start()
    {
        if (masukanLoadingbar == null)
        {
            Debug.LogError("Masukan Loading Bar is not assigned in the inspector.");
        }
        if (nilaiKecepatan <= 0)
        {
            Debug.LogWarning("Nilai Kecepatan should be greater than 0.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (masukanLoadingbar == null)
        {
            Debug.LogError("Masukan Loading Bar is not assigned.");
            return;
        }

        if (nilaiSekarang < 100)
        {
            nilaiSekarang += nilaiKecepatan * Time.deltaTime;
            Debug.Log("Current value: " + (int)nilaiSekarang);
        }
        else
        {
            Debug.Log("Loading complete, switching scene.");
            UnityEngine.SceneManagement.SceneManager.LoadScene("FirstMenu");
        }

        Image loadingImage = masukanLoadingbar.GetComponent<Image>();
        if (loadingImage != null)
        {
            loadingImage.fillAmount = nilaiSekarang / 100f;
            Debug.Log("Fill Amount: " + loadingImage.fillAmount);
        }
        else
        {
            Debug.LogError("The assigned Transform does not have an Image component.");
        }
    }
}
