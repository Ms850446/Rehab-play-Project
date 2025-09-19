using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit;

public class forceDrop : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private XrInteractionManager interactionManager;
    [SerializeField]
    private AssementManager assementManager;

    private GameObject startObject;

    private Transform objectTransform;
    [SerializeField]
    private List<Transform> targetsTransform;

    
    [SerializeField]
    private IXRSelectInteractor leftControllerDirectInteractor;
    [SerializeField]
    private IXRSelectInteractor rightControllerDirectInteractor;
    [SerializeField]
    private IXRSelectInteractable GrabInteractable;
    private float minDistance = 0.05f;
    private bool leftControllerIsSelecting = false;
    private bool rightControllerIsSelecting  = false;
    private bool ControllerIsSelecting = false;
    
 

    private
    void Start()
    {
        leftControllerDirectInteractor = GameObject.Find("Left Controller").GetComponent<XRDirectInteractor>();
        rightControllerDirectInteractor = GameObject.Find("Right Controller").GetComponent<XRDirectInteractor>();
        objectTransform = GetComponent<Transform>();
        GrabInteractable = GetComponent<XRGrabInteractable>();
        startObject = new GameObject("StartPosition");
        startObject.transform.SetPositionAndRotation(objectTransform.position,objectTransform.rotation);
       

    }

    // Update is called once per frame
    void Update()
    {
   
        var minimumdistance_temp= 99f;
        int index = 0;


        for (int i =0; i<targetsTransform.Count; i++){
            float distance = Vector3.Distance(transform.position, targetsTransform[i].position);
            if (distance< minimumdistance_temp){
            minimumdistance_temp = distance;
            index = i;
            }
        }
        
        if (minimumdistance_temp < minDistance && Vector3.Distance(transform.position, startObject.transform.position) > minDistance && !ControllerIsSelecting){
            DropObjectOnPosition(startObject.transform.position, startObject.transform.rotation);
        }
        if (minimumdistance_temp < minDistance ){

            
           
          
            if (leftControllerIsSelecting){
            DropObjectOnPosition(startObject.transform.position, startObject.transform.rotation);
            interactionManager.SelectExit(leftControllerDirectInteractor,GrabInteractable);
 

            DropObjectOnPosition(startObject.transform.position, startObject.transform.rotation);
            assementManager.IterationFinished();
            }
            else if (rightControllerIsSelecting){
            DropObjectOnPosition(startObject.transform.position, startObject.transform.rotation);
            interactionManager.SelectExit(rightControllerDirectInteractor,GrabInteractable);
    
            DropObjectOnPosition(startObject.transform.position, startObject.transform.rotation);
            assementManager.IterationFinished();
            }

            DropObjectOnPosition(startObject.transform.position, startObject.transform.rotation);
            
        }

        if (assementManager.assesmentfinished){
            if (Vector3.Distance(transform.position , startObject.transform.position)> 0.0001){
                DropObjectOnPosition(startObject.transform.position, startObject.transform.rotation);
            }
        }
    }

    private void DropObjectOnPosition(Vector3 pos, Quaternion rotation){
         
            var rigidbody = GetComponent<Rigidbody>();
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            transform.position = pos;
            transform.rotation = rotation;

    }
    public void SetSelectedflag(){
        ControllerIsSelecting = true;


    }
    public void ClearSelectedflag(){
        ControllerIsSelecting = false;


    }
    public void leftControllerSetSelectedflag(){
        leftControllerIsSelecting = true;


    }
    public void leftControllerclearSelectedflag(){
        leftControllerIsSelecting = false;
    }
    public void rightControllerSetSelectedflag(){
        rightControllerIsSelecting = true;

    }
    public void rightControllerclearSelectedflag(){
        rightControllerIsSelecting = false;
        
    }
    
}
