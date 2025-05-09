using System.Collections;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Color gizmoColor = Color.red; 
    [SerializeField] private float gizmoRadius; 

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

        if (other.CompareTag("Player") && !playerMovement.hiding)
        {
            StartCoroutine(ShowGameOverPanelWithDelay());
        }
    }

    private IEnumerator ShowGameOverPanelWithDelay()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        audioManager.PlaySFX(audioManager.Lose);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;

        Gizmos.DrawWireSphere(transform.position, gizmoRadius);
    }
}