using UnityEngine;

public class InstantiateAndApplyForce : MonoBehaviour
{
    public GameObject projectilePrefab;  // The prefab of the projectile to instantiate
    public string playerTag = "Player";  // The tag of the player GameObject
    public float forceMagnitude = 10f;  // The magnitude of the force applied
    public int projectileCount = 5;  // The number of projectiles to instantiate
    public float spreadAngle = 30f;  // The angle of spread for the projectiles
    public float activationInterval = 2f; // The time interval between activations

    private float lastActivationTime = -Mathf.Infinity; // The time of the last activation
    private Transform target; // The transform of the player

    private void Awake()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObject != null)
        {
            target = playerObject.transform;
        }
    }

    private void Update()
    {
        if (Time.time - lastActivationTime >= activationInterval)
        {
            ActivateAbility();
            lastActivationTime = Time.time;
        }
    }

    private void ActivateAbility()
    {
        for (int i = 0; i < projectileCount; i++)
        {
            GameObject instantiatedProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = instantiatedProjectile.GetComponent<Rigidbody2D>();

            if (rb != null && target != null)
            {
                Vector2 direction = target.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                // Apply spread angle
                float spreadOffset = Random.Range(-spreadAngle, spreadAngle);
                angle += spreadOffset;

                // Calculate force direction based on the adjusted angle
                Vector2 forceDirection = Quaternion.AngleAxis(angle, Vector3.forward) * Vector2.right;

                rb.AddForce(forceDirection.normalized * forceMagnitude, ForceMode2D.Impulse);
            }
        }
    }
}
