using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ControllerData : MonoBehaviour
{
    
    public GameObject controllerLeft;
    public GameObject controllerRight;
    private bool isSelected = false;
    private int takeCounter = 0;
    [SerializeField] AssementManager assementManager;
    private Vector3 controllerLeftLastPosition;
    private Vector3 controllerRightLastPosition;
    public Vector3 controllerLeftVelocity;
    public Vector3 controllerRightVelocity;

    public List<List<float>> allDeltaTimes;
  

    private float deltaTime;





    void Start()
    {
       controllerLeft = GameObject.Find("Left Controller");
       controllerLeftLastPosition =controllerLeft.GetComponent<Transform>().position;
       

       controllerRight = GameObject.Find("Right Controller");
       controllerRightLastPosition =controllerRight.GetComponent<Transform>().position;

        takeCounter = assementManager.takeCounter;
        allDeltaTimes = new List<List<float>>();
        allDeltaTimes.Add(new List<float>());


    }

    // Update is called once per frame
    void Update()
    {

        
        if (takeCounter != assementManager.takeCounter){
            allDeltaTimes.Add(new List<float>());
             

            takeCounter=assementManager.takeCounter;
            }
        if (isSelected){
            updateControllerVelocity();
            allDeltaTimes[takeCounter].Add(Time.deltaTime);
        }

    }

    private void updateControllerVelocity(){
            controllerLeftVelocity = calculateVelocity(controllerLeft.GetComponent<Transform>().position, controllerLeftLastPosition);
            controllerLeftLastPosition = controllerLeft.GetComponent<Transform>().position;
            controllerRightVelocity = calculateVelocity(controllerRight.GetComponent<Transform>().position, controllerRightLastPosition);
            controllerRightLastPosition = controllerRight.GetComponent<Transform>().position;

            
    }

    public float GetAverageVelocity(int index){
        float temp = 0;
        foreach (float time in allDeltaTimes[index]){
            temp += time;
        }

 
        if (assementManager.displacements[index] == 0) return 0;
        
        else
        return assementManager.displacements[index]/temp;
    }
    public float GetTotalTime(int index){
        float temp = 0;
        foreach (float time in allDeltaTimes[index]){
            temp += time;
        }

 
        if (assementManager.displacements[index] == 0) return 0;
        
        else
        return temp;
    }

 
    private Vector3 calculateVelocity(Vector3 currentPosition, Vector3 lastPosition){
        Vector3 displacement = currentPosition - lastPosition;
       
        // Calculate the time elapsed since the last frame
        deltaTime = Time.deltaTime;

        // Calculate the velocity using the formula: velocity = displacement / time
        Vector3 velocity = displacement / deltaTime;

        // Print or use the velocity as needed
       return velocity;
    }

     public void setIsSelected(){
        isSelected = true;
    }
    public void clearIsSelected(){
        updateControllerVelocity();
        isSelected = false;
    }

}
