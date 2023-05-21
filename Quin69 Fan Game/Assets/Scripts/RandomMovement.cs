using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float movementSpeed = 1f; // Speed of movement in units per second
    public float noiseScale = 1f; // Scale of the Perlin noise
    public float noiseSpeed = 1f; // Speed of the Perlin noise

    private Vector3 startPosition; // Starting position of the object
    private float seed; // Random seed value for the object

    void Start()
    {
        // Record the starting position of the object
        startPosition = transform.position;

        // Generate a random seed value for the object based on its position
        seed = Random.Range(-1000f, 1000f) + transform.position.x + transform.position.y;
    }

    void Update()
    {
        // Calculate the new position based on the Perlin noise and the elapsed time
        float noiseValue = Mathf.PerlinNoise(Time.time * noiseSpeed, seed) * 2f - 1f;
        Vector3 newPosition = startPosition + new Vector3(noiseValue * noiseScale, noiseValue * noiseScale, 0f);
        float step = movementSpeed * Time.deltaTime;

        // Move the object towards the new position
        transform.position = Vector3.MoveTowards(transform.position, newPosition, step);
    }
}
