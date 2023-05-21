using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    public List<GameObject> possibleDrops = new List<GameObject>();
    

    public void DropItem()
    {
        Instantiate(possibleDrops[Random.Range(0, possibleDrops.Count)] , transform.position , Quaternion.identity);
    }

}
