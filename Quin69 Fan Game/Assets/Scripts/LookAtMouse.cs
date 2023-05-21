using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    void Update()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z; // Keep the same Z coordinate as the sprite

        // Calculate the direction vector from the sprite to the mouse
        Vector3 direction = mousePosition - transform.position;

        // Calculate the angle besstween the direction vector and the sprite's forward vector
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Set the sprite's rotation to the calculated angle
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
