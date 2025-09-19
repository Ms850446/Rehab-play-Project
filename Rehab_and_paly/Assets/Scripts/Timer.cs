// using UnityEngine;

// public class Timer : MonoBehaviour
// {
//     public float maxTime = 10f; // Maximum time in seconds
//     private float currentTime; // Current time remaining
//     private bool timerActive = true; // Flag to indicate if the timer is active

//     private void Start()
//     {
//         currentTime = maxTime; // Set the initial time
//     }

//     private void Update()
//     {
//         if (timerActive)
//         {
//             // Decrease the current time by deltaTime
//             currentTime -= Time.deltaTime;

//             // Print the time remaining to the console
//             Debug.Log("Time: " + Mathf.RoundToInt(currentTime));

//             // Check if time has run out
//             if (currentTime <= 0f)
//             {
//                 // Time's up, do something (e.g., end the game)
//                 Debug.Log("Time's up!");
//                 timerActive = false;
//             }
//         }
//     }
// }

// console

// using UnityEngine;

// public class Timer : MonoBehaviour
// {
// 	public float totalTime = 30.0f; // Total time for the timer
// 	private float timeRemaining; // Current time remaining

// 	void Start()
// 	{
// 		timeRemaining = totalTime; // Initialize the timer
// 	}

// 	void Update()
// 	{
// 		if (timeRemaining > 0)
// 		{
// 			// Decrease the time remaining
// 			timeRemaining -= Time.deltaTime;
// 			Debug.Log("Time: " + Mathf.RoundToInt(timeRemaining));
// 		}
// 		else
// 		{
// 			// Timer has run out, handle this event (e.g., end the game)
// 			Debug.Log("Time's up!");
// 			// You might want to add more here, like stopping game play or showing a game over screen
// 		}
// 	}
// }


// menu

// using UnityEngine;
// using UnityEngine.UI; // Import Unity's UI library

// public class Timer : MonoBehaviour
// {
//     public float totalTime = 30.0f; // Total time for the timer
//     private float timeRemaining; // Current time remaining
//     public Text timerText; // Reference to the UI Text component to display the timer

//     void Start()
//     {
//         timeRemaining = totalTime; // Initialize the timer
//     }

//     void Update()
//     {
//         if (timeRemaining > 0)
//         {
//             // Decrease the time remaining
//             timeRemaining -= Time.deltaTime;
//             // Update the UI Text component to display the remaining time
//             timerText.text = "Time: " + Mathf.RoundToInt(timeRemaining);
//         }
//         else
//         {
//             // Timer has run out, handle this event (e.g., end the game)
//             timerText.text = "Time's up!";
//             // You might want to add more here, like stopping gameplay or showing a game over screen
//         }
//     }
// }
