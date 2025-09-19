using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AssementManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int totalAssesmentIterations = 3;
    public int currentAssesmentIteration = 0;

    public int positionIndex = 0;

    public int takeCounter = 0;
    public List<float> displacements;
  
    public List<GameObject> targetsList;
    private GameObject initial_target_positon_holder;

    [SerializeField]
    private Transform interactable_transform;

    
    [SerializeField]
    private XRRayInteractor rayInteractor1;
    [SerializeField]
    private XRRayInteractor rayInteractor2;

    [SerializeField] private VelocityCalculation velocityCalculation;

    public bool assesmentfinished= false;


    void Start()
    {
        initial_target_positon_holder = new GameObject();
        initial_target_positon_holder.transform.SetPositionAndRotation(targetsList[0].transform.position, targetsList[0].transform.rotation);
        displacements = new List<float>();
        
          

        foreach (GameObject obj in targetsList){
            for (int i=0 ; i<totalAssesmentIterations; i++)
            displacements.Add(Vector3.Distance(interactable_transform.position,initial_target_positon_holder.transform.position));

        }
        displacements.Add(0);
        
    }



    public void IterationFinished(){
        
        currentAssesmentIteration++;
        takeCounter++;

        if (currentAssesmentIteration >= totalAssesmentIterations){
            changeTarget();
            currentAssesmentIteration = 0;
        }
       
    }

    public void changeTarget(){
     
        
        if (positionIndex < targetsList.Count-1){
        targetsList[0].transform.SetPositionAndRotation( targetsList[positionIndex+1].transform.position, targetsList[positionIndex+1].transform.rotation);
        positionIndex++;}
        else if (positionIndex >= targetsList.Count-1){
            targetsList[0].transform.SetPositionAndRotation(initial_target_positon_holder.transform.position, initial_target_positon_holder.transform.rotation);
            MenuManager.OpenMenu(Menu.RESULTS_MENU);
            assesmentfinished = true;
            velocityCalculation.assesmentFinished();

            enableRayInteractor();
            takeCounter = 0;

        }

    
        
        
    }

    private void enableRayInteractor(){
        rayInteractor1.enabled = true;
        rayInteractor2.enabled = true;
    }
}
