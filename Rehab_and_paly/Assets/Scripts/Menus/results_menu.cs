using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class results_menu : MonoBehaviour
{

    [SerializeField] private DrawLineTracking LineTracking;
    [SerializeField] private TextMeshProUGUI AverageVelocityText;
    [SerializeField] private TextMeshProUGUI SpeedText;
    [SerializeField] private ControllerData controllerData;
    [SerializeField] private TextMeshProUGUI ButtonText;

    private Transform startTransform;
    [SerializeField] Transform interactableTransform;

    [SerializeField] private AssementManager assementManager;
    private int index = 0;
    private int totalAssesmentIterations;
    private int targetsCounter = 0;
    private int totalNumTargets;

    // Start is called before the first frame update
    void Start()
    {
        totalAssesmentIterations = assementManager.totalAssesmentIterations;
        totalNumTargets = assementManager.targetsList.Count;
        

    }

    // Update is called once per frame
    void Update()
    {

        if (startTransform == null){
            startTransform = GameObject.Find("StartPosition").transform;
            interactableTransform.SetPositionAndRotation(startTransform.position,startTransform.rotation);

        }
        
    }

    public void onClick_result(){
        float averageVelocity =  controllerData.GetAverageVelocity(LineTracking.currentLineShown);
        float TotalTime =  controllerData.GetTotalTime(LineTracking.currentLineShown);
        
        float distance = LineTracking.changeLineAndGetDistance();
        
        if (averageVelocity == 0 || TotalTime == 0){
        AverageVelocityText.text = "Average Velocity = ??";
        SpeedText.text = "Speed = ??";
        }
        else{
        AverageVelocityText.text = "Average Velocity = " + averageVelocity;
        SpeedText.text = "Speed = " + distance/TotalTime;

        }


        if (LineTracking.currentLineShown == 0)
            ButtonText.text = "Click to Show Result";
        else
        ButtonText.text = "Take: " + LineTracking.currentLineShown;
        

        // to change the position of the grabable object and forcefield
        // total assesment iteration = 2 then
        // index:         0->1->2->1->2->1->2->0
        // targetCounter: 0------->1---->2---->0
        index ++;
        if (index > totalAssesmentIterations){
            targetsCounter++;
            
            if (targetsCounter >= totalNumTargets){
                index = 0;
                targetsCounter = 0;
            }
            else index=1;

            for (int i =0 ; i<totalNumTargets; i++){
                if (i == targetsCounter){
                    assementManager.targetsList[i].SetActive(true);

                }
                else assementManager.targetsList[i].SetActive(false);
            }
            
        }
        
    }

    private void changeTargetPoistion(int index){

    }
     
}
