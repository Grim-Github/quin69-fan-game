using Unity.VisualScripting;
using UnityEngine;

public class AIBehaviour : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public float forceMagnitude = 10f;
    public float friction = 5f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb.drag = friction;
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            // Calculate the direction towards the player
            Vector2 direction = player.position - transform.position;
            direction.Normalize();

            // Apply force to move the cube towards the player
            Vector2 force = direction * forceMagnitude;
            rb.AddForce(force);
        }
    }
}
