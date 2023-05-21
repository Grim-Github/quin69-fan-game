using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    public string damageTag = "Enemy";
    public int damage = 1;
    public float timer = .2f;
    private float remainingTimer = 0;
    public float knockbackForce = 10f; // Force of the knockback

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<HealthSystem>() != null)
        {
            HealthSystem HP = collision.transform.GetComponent<HealthSystem>();

            if(remainingTimer <=0)
            {
                if (collision.transform.CompareTag(damageTag))
                {
                    HP.TakeDamage(damage);
                    Rigidbody2D otherRigidbody = collision.GetComponent<Rigidbody2D>();
                    if (otherRigidbody != null)
                    {
                        // Calculate the direction of the knockback
                        Vector2 knockbackDirection = otherRigidbody.transform.position - transform.position;
                        knockbackDirection.Normalize();

                        // Set the knockback velocity directly
                        otherRigidbody.velocity = knockbackDirection * knockbackForce;
                    }
                    remainingTimer = timer;
                }
            }
            else
            {
                remainingTimer -= Time.deltaTime;
            }
        }
    }
}
