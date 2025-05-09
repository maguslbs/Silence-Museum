using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSteal : MonoBehaviour
{
    [SerializeField] private GameObject diamond;
    [SerializeField] private GameObject playerDiamond;
    [SerializeField] private GameObject winGamePanel;

    AudioManager audioManager;

    private bool diamondCollected = false;
    private bool isInDTableArea = false;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        if (isInDTableArea && Input.GetKeyDown(KeyCode.E))
        {
            if (!diamondCollected)
            {
                audioManager.PlaySFX(audioManager.Collect);
                diamond.SetActive(false);
                playerDiamond.SetActive(true);
                diamondCollected = true;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("DTable"))
        {
            isInDTableArea = true; 
        }

        if (other.CompareTag("Door"))
        {
            if (diamondCollected)
            {
                audioManager.PlaySFX(audioManager.Win);
                Time.timeScale = 0f;
                winGamePanel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("DTable"))
        {
            isInDTableArea = false; 
        }
    }
}