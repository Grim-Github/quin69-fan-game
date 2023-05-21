using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private bool destroyOnAwake = false;
    [SerializeField] private float destructionTimer = 2f;

    private void Awake()
    {
        if(destroyOnAwake)
        {
            Destroy(gameObject , destructionTimer);
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
