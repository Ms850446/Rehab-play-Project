using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DrawLineTracking : MonoBehaviour
{
 
    [SerializeField] private Transform trackedObjectTransform;
    [SerializeField] private LineRenderer lineRenderer;
    public List<List<Vector3>> allLines;
    private int iteration;
    private int index=0;

    public int currentLineShown = 0;

    [SerializeField] AssementManager assementManager;



    public bool isSelected = false;
    

    
    void Start()
    {   
        iteration = assementManager.takeCounter;
        allLines = new List<List<Vector3>>();
        allLines.Add(new List<Vector3>());
    }

    // Update is called once per frame
    void Update()
    {

        if (iteration != assementManager.takeCounter){

            allLines.Add(new List<Vector3>());
            iteration = assementManager.takeCounter;
            index ++;

        }
        if (isSelected){
            
            allLines[index].Add(trackedObjectTransform.position);
            
            
        }
      
    }

    public float changeLineAndGetDistance(){
        lineRenderer.positionCount = allLines[currentLineShown].Count;
        lineRenderer.SetPositions(allLines[currentLineShown].ToArray());
        float dist =  calculateLineDistance (currentLineShown);
        currentLineShown++ ;
        if (currentLineShown >= allLines.Count) 
            currentLineShown = 0;
             
        return dist;


    }
    public float calculateLineDistance (int index){
        float temp = 0f;
     
        for (int i=0 ; i<allLines[index].Count-1; i++){
            temp += Vector3.Distance(allLines[index][i],allLines[index][i+1]);

        }
        return temp;
    }
   

    

    public void setIsSelected(){
        isSelected = true;
    }
    public void clearIsSelected(){
        isSelected = false;
    }

}
