using UnityEngine;

public class WinningEffect : MonoBehaviour
{
    public GameObject[] books;
    public GameObject[] bookPlaces;
    public ParticleSystem celebration;

    private bool[] isBookPlaced;

    void Start()
    {
        // Initialize the array to track the placement status of each book
        isBookPlaced = new bool[books.Length];
    }

    void Update()
    {
        CheckAllBooksPlacement();
    }

    void CheckAllBooksPlacement()
    {
        bool allBooksPlaced = true;

        for (int i = 0; i < books.Length; i++)
        {
            if (!IsBookInCorrectPosition(i))
            {
                allBooksPlaced = false;
                // If any book is not in the correct position, exit the loop
                break;
            }
        }

        if (allBooksPlaced)
        {
            PlayWinningEffect();
            Debug.Log("All books are placed in their right places.");
        }
    }

    bool IsBookInCorrectPosition(int bookIndex)
    {
        float distanceThreshold = 0.1f; // Adjust this threshold based on your scene scale
        float distance = Vector3.Distance(books[bookIndex].transform.position, bookPlaces[bookIndex].transform.position);
        return distance < distanceThreshold;
    }

    void PlayWinningEffect()
    {
        celebration.Play();
    }
}

