using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed
    public float snapForce = 10f; // Force applied for snappy movement
    public float rawForce = 20f; // Force applied for raw movement

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector2(moveHorizontal, moveVertical).normalized;
    }

    void FixedUpdate()
    {
        Vector2 targetVelocity = movement * moveSpeed;

        Vector2 force = targetVelocity - rb.velocity;

        if (movement.magnitude > 0)
        {
            rb.AddForce(force * snapForce, ForceMode2D.Force);
        }
        else
        {
            rb.AddForce(force * rawForce, ForceMode2D.Force);
        }
    }
}
