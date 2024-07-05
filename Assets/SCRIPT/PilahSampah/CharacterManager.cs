using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;

    private GameObject activePlayer;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        SetActivePlayer(player1);
    }

    public void SetActivePlayer(GameObject player)
    {
        DeactivatePlayer(player1);
        DeactivatePlayer(player2);
        DeactivatePlayer(player3);

        ActivatePlayer(player);

        activePlayer = player;

        // Update NyawaBar dengan referensi ke Nyawa dari karakter yang baru diaktifkan
        if (gameManager != null)
        {
            NyawaSampah playerNyawa = activePlayer.GetComponent<NyawaSampah>();
            if (playerNyawa != null)
            {
                // Update UI or handle as needed
            }
        }
    }

    public void OnSelectPlayer1()
    {
        SetActivePlayer(player1);
    }

    public void OnSelectPlayer2()
    {
        SetActivePlayer(player2);
    }

    public void OnSelectPlayer3()
    {
        SetActivePlayer(player3);
    }

    private void DeactivatePlayer(GameObject player)
    {
        player.SetActive(false);
        if (player.TryGetComponent<NyawaSampah>(out NyawaSampah nyawa))
        {
            nyawa.enabled = false;
        }
        if (player.TryGetComponent<ScorePilahSampah>(out ScorePilahSampah scoreSampah))
        {
            scoreSampah.enabled = false;
        }
    }

    private void ActivatePlayer(GameObject player)
    {
        player.SetActive(true);
        if (player.TryGetComponent<NyawaSampah>(out NyawaSampah nyawa))
        {
            nyawa.enabled = true;
        }
        if (player.TryGetComponent<ScorePilahSampah>(out ScorePilahSampah scoreSampah))
        {
            scoreSampah.enabled = true;
        }
    }

    public NyawaSampah GetActivePlayerNyawa()
    {
        if (activePlayer != null)
        {
            return activePlayer.GetComponent<NyawaSampah>();
        }
        return null;
    }
}
