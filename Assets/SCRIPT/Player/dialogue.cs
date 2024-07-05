using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class dialogue : MonoBehaviour
{
    // UI References
    [SerializeField] private GameObject dialogueCanvas;
    [SerializeField] private TMP_Text speakerText;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Image portraitImage;
    [SerializeField] private Button interactButton; // Reference to the UI Button

    // Dialogue Content
    [SerializeField] private string[] speaker;
    [SerializeField] [TextArea] private string[] dialogueWords;
    [SerializeField] private Sprite[] portrait;

    private bool dialogueActivated;
    private int step;
    private bool nextDialogueRequested; // Flag to check if the button was clicked

    void Start()
    {
        // Add listener to the button to set the nextDialogueRequested flag when clicked
        interactButton.onClick.AddListener(OnInteractButtonClicked);
    }

    void Update()
    {
        if (nextDialogueRequested && dialogueActivated == true) // Check the flag instead of the button press
        {
            nextDialogueRequested = false; // Reset the flag

            if (step >= speaker.Length)
            {
                dialogueCanvas.SetActive(false);
                step = 0;
            }
            else
            {
                speakerText.text = speaker[step];
                dialogueText.text = dialogueWords[step];
                portraitImage.sprite = portrait[step];
                step += 1;
            }
        }
    }

    public void OnInteractButtonClicked()
    {
        // Set the flag to true when the button is clicked
        nextDialogueRequested = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueActivated = true;
            dialogueCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueActivated = false;
            dialogueCanvas.SetActive(false);
        }
    }
}
