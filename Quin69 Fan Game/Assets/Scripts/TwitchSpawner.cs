using Lexone.UnityTwitchChat;
using TMPro;
using UnityEngine;

public class TwitchSpawner : MonoBehaviour
{
    public GameObject chatterObject;
    [SerializeField] private float spawnRange = 30f;


    private void Start()
    {
        IRC.Instance.OnChatMessage += OnChatMessage;
    }

    private void OnChatMessage(Chatter chatter)
    {
        GameObject recentlySpawned = Instantiate(chatterObject, Random.insideUnitCircle * spawnRange, Quaternion.identity);
        recentlySpawned.GetComponentInChildren<TextMeshProUGUI>().text = chatter.tags.displayName;
        recentlySpawned.GetComponentInChildren<TextMeshProUGUI>().color = chatter.GetNameColor();
    }
}