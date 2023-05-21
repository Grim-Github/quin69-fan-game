using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] bloodPuddles;
    public int maxHealth = 100; // Maximum health value
    private int currentHealth; // Current health value
    private Slider healthSlider;
    [SerializeField] private SpriteRenderer entitySprite;
    [SerializeField] private UnityEvent _onDeath;
    [SerializeField] private Animator entityAnimator;
    public bool isPlayer = false;

    void Start()
    {
        healthSlider = GetComponentInChildren<Slider>();
        currentHealth = maxHealth; // Set the initial health to the maximum value
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Reduce the current health by the damage amount
        entitySprite.color = Color.red;
        GameObject.FindAnyObjectByType<CameraShake>().ShakeCamera(.2f);
        Instantiate(bloodPuddles[Random.Range(0, bloodPuddles.Length)], transform.position, Quaternion.identity);

        if (currentHealth <= 0)
        {
            Die(); // Call the Die() method if the health reaches zero or below
        }
    }

    private void RecoverSpriteColor()
    {
        if(entitySprite.color != Color.white)
        {
            entitySprite.color = Color.Lerp(entitySprite.color, Color.white , Time.deltaTime * 5);
        }
        
    }

    private void Update()
    {
        RecoverSpriteColor();

        healthSlider.maxValue = maxHealth;
        healthSlider.value = Mathf.MoveTowards(healthSlider.value, currentHealth , Time.deltaTime * 70 );
    }

    private void Die()
    {
        // Implement the behavior when the object dies (e.g., play death animation, destroy object, etc.)
        _onDeath.Invoke();
        entityAnimator.SetTrigger("Death");
        healthSlider.value = 0;
        Destroy(this);
    }
}
