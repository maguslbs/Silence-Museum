using System.Collections;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float idleTime = 2f; 

    private Rigidbody2D rb;
    private Transform currentPoint;
    private bool isIdle = false;
    private bool isStopped = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }

    void Update()
    {
        if (isIdle || isStopped) { return; }

        Vector2 direction = (currentPoint.position - transform.position).normalized;

        rb.velocity = direction * speed;

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f)
        {
            StartCoroutine(IdleAtPoint());
        }
    }

    IEnumerator IdleAtPoint()
    {
        isIdle = true;               
        rb.velocity = Vector2.zero;  

        yield return new WaitForSeconds(idleTime); 

        currentPoint = (currentPoint == pointB.transform) ? pointA.transform : pointB.transform;
        isIdle = false; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (!playerMovement.hiding) 
            {
                isStopped = true;       
                rb.velocity = Vector2.zero; 
                StopAllCoroutines();    
            }
        }
    }
}