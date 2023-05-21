using UnityEngine;
using UnityEngine.UI;

public class LevelingSystem : MonoBehaviour
{
    public static LevelingSystem instance;
    public int currentLevel = 1;
    public int maxLevel = 10;
    public int experiencePoints = 0;
    public int[] levelXPRequirements; // Array to define XP requirements for each level
    private Slider levelingSlider;

    private void Awake()
    {
        instance = this;
        levelingSlider = GameObject.Find("LevelingBar").GetComponent<Slider>();
    }

    void Start()
    {
        // Initialize the XP requirements array with some example values
        maxLevel = levelXPRequirements.Length;
        levelingSlider.maxValue = levelXPRequirements[currentLevel - 1];
        levelingSlider.value = experiencePoints;
        // ... continue setting XP requirements for other levels
    }

    // Function to earn XP
    public void EarnXP(int amount)
    {
        experiencePoints += amount;
        levelingSlider.value = experiencePoints;
        CheckLevelUp();
    }

    // Function to check if the player has leveled up
    private void CheckLevelUp()
    {
        if (currentLevel < maxLevel && experiencePoints >= levelXPRequirements[currentLevel - 1])
        {
            LevelUp();
        }
    }

    // Function to handle level up
    private void LevelUp()
    {
        experiencePoints = 0;
        currentLevel++;
        levelingSlider.value = experiencePoints;
        levelingSlider.maxValue = levelXPRequirements[currentLevel - 1];
        // Provide rewards or adjust player attributes as desired
        Debug.Log("Level up! Current level: " + currentLevel);
    }
}
