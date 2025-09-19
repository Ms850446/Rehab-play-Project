using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using Debug = UnityEngine.Debug;
public class ReactionTime : MonoBehaviour
{
    public GameObject coloredObject;
    public Material redMaterial;
    public Material greenMaterial;
    [SerializeField] private sendRequests sendRequest;
    [SerializeField]
    [Tooltip("GameObject of the left hand that contains the mesh and scripts.")]
    GameObject leftHandModel;

    [SerializeField]
    [Tooltip("GameObject of the right hand that contains the mesh and scripts.")]
    GameObject rightHandModel;
    private int currentTrial = 1; // Descriptive variable name
    private bool isGreen = false;
    private Stopwatch stopwatch;
    private float averageTime = 0f;
    //public GameObject buttonObject; // Reference the GameObject with PhysicsButton script
    public LayerMask handLayer1; // Layer for the hand controller
    public bool hasTouched = false;
    public bool currentDisabled = false;
    private bool detectCollision=false;
    private float reactionTime;

    private string requestString;
    void Start()
    {
        handLayer1 = LayerMask.GetMask("Interactable");
        stopwatch = new Stopwatch();

    }

private void OnTriggerEnter(Collider other) {
    if(detectCollision&&(other.gameObject==leftHandModel||other.gameObject==rightHandModel)){
        hasTouched = true;
        detectCollision=false;

    }
}
    void Update()
    {

        if (currentTrial <= 5)
        {
            if (!isGreen)
            {
                coloredObject.GetComponent<Renderer>().material = redMaterial;
                StartCoroutine(WaitAndTurnGreen());
                isGreen=true;
            }
            else
            {
                if ( hasTouched && !currentDisabled){
                 reactionTime= stopwatch.ElapsedMilliseconds;
                    stopwatch.Stop();
                    UnityEngine.Debug.Log("reaction time = "+ reactionTime + "ms");
                    requestString += reactionTime +";";
                    averageTime += reactionTime;
                    isGreen = false;
                    currentTrial++;
                    hasTouched=false;
                    stopwatch.Reset();
                }

            }
        }
        else if(currentTrial++==6)
        {
            averageTime /= (currentTrial - 1); // Exclude first trial (no reaction time)
            UnityEngine.Debug.Log("average time = " + averageTime + "ms");

            requestString += "" + sendRequest.pk ;
            sendRequest.SendString(requestString,"http://localhost:8000/reactionTime/");
        }
        else {

        }
    }

    IEnumerator WaitAndTurnGreen()
    {
        yield return new WaitForSeconds(Random.Range(5.0f, 10.0f));
        coloredObject.GetComponent<Renderer>().material = greenMaterial;
        stopwatch.Start();
        detectCollision=true;
        Debug.LogWarning("start watch ");

    }
}




