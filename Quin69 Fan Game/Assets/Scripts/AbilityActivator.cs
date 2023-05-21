using System.Linq;
using UnityEngine;

public class AbilityActivator : MonoBehaviour
{
    public GameObject abilityPrefab; // The prefab of the ability to activate
    public float activationInterval = 2f; // The time interval between activations
    public SpawnMode spawnMode = SpawnMode.AtTransform; // The spawn mode for the ability
    public string nearestObjectTag = "Enemy";
    public int nearestObjectTargets = 5;
    public float nearestObjectRadius = 5f; // The radius within which to find nearest objects

    private float lastActivationTime = -Mathf.Infinity; // The time of the last activation

    public enum SpawnMode
    {
        AtTransform,
        NearestObjectWithTag,
        AtMousePosition
    }

    void Update()
    {
        if (Time.time - lastActivationTime >= activationInterval)
        {
            ActivateAbility();
            lastActivationTime = Time.time;
        }
    }

    private GameObject GetNearestObject(GameObject[] objects)
    {
        GameObject nearestObject = null;
        float nearestDistance = Mathf.Infinity;

        foreach (GameObject obj in objects)
        {
            float distance = Vector2.Distance(transform.position, obj.transform.position);
            if (distance < nearestDistance && distance <= nearestObjectRadius)
            {
                nearestObject = obj;
                nearestDistance = distance;
            }
        }

        return nearestObject;
    }

    private void ActivateAbility()
    {
        switch (spawnMode)
        {
            case SpawnMode.AtTransform:
                InstantiateAbilities(transform.position);
                break;
            case SpawnMode.AtMousePosition:
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                InstantiateAbilities(mousePosition);
                break;
            case SpawnMode.NearestObjectWithTag:
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(nearestObjectTag);
                if (objectsWithTag.Length > 0)
                {
                    for (int i = 0; i < Mathf.Min(nearestObjectTargets, objectsWithTag.Length); i++)
                    {
                        GameObject nearestObject = GetNearestObject(objectsWithTag);
                        if (nearestObject != null)
                        {
                            InstantiateAbilities(nearestObject.transform.position);
                            // Remove the nearest object from the list to find the next nearest
                            objectsWithTag = objectsWithTag.Where(obj => obj != nearestObject).ToArray();
                        }
                    }
                }
                break;
        }
    }

    private void InstantiateAbilities(Vector3 position)
    {
        Instantiate(abilityPrefab, position, Quaternion.identity);
    }
}
