using UnityEngine;

public class ExpandObject : MonoBehaviour
{
    public float expansionRate = 1f; // Rate of expansion in units per second
    public float maxScale = 2f; // Maximum scale of the object

    private float currentScale; // Current scale of the object

    void Start()
    {
        currentScale = transform.localScale.x; // Record the starting scale of the object
    }

    void Update()
    {
        // Increase the scale of the object based on the expansion rate and the elapsed time
        currentScale += expansionRate * Time.deltaTime;
        currentScale = Mathf.Clamp(currentScale, 0f, maxScale); // Clamp the scale to prevent it from exceeding the maximum

        // Set the new scale of the object
        transform.localScale = new Vector3(currentScale, currentScale, 1f);

        // Destroy the object when it reaches its maximum size
        if (currentScale >= maxScale)
        {
            Destroy(gameObject);
        }
    }
}
