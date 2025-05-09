using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float speedX, speedY;
    private Rigidbody2D rb;
    private bool canMove = true;
    public bool canHide = false;
    public bool hiding = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        if (canMove)
        {
            speedX = Input.GetAxisRaw("Horizontal") * moveSpeed;
            speedY = Input.GetAxisRaw("Vertical") * moveSpeed;

            rb.velocity = new Vector2(speedX, speedY);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!hiding) 
            {
                canMove = false;
            }
        }
        else if (other.CompareTag("Pillar")) 
        {
            canHide = true;
            hiding = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Pillar")) 
        {
            canHide = false;
            hiding = false; 
        }
    }
}