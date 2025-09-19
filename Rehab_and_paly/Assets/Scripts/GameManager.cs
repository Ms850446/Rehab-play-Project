using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton instance
    private int score = 0; // Current score

    void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep the singleton instance persistent across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to increase the score
    public void IncreaseScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
        // You can also update UI elements here to display the score
    }
}
