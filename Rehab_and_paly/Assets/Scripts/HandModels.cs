using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandModels : MonoBehaviour
{   
    private SphereCollider LeftControllerSphereCollider;
    private SphereCollider RightControllerSphereCollider;
    private GameObject LeftController;
    private GameObject RightController;

    private GameObject LeftAttachTransform;
    private GameObject RightAttachTransform;
    [SerializeField] private GameObject LeftControllerModel;
    [SerializeField] private GameObject RightControllerModel;

    [SerializeField] public Vector3 RightHandTrackingColliderOffset;
    [SerializeField] public Vector3 LeftHandTrackingColliderOffset;

    
    // Start is called before the first frame update
    void Start()
    {
        LeftControllerSphereCollider = GameObject.Find("Left Controller").GetComponent<SphereCollider>();
        LeftController = GameObject.Find("Left Controller");
        RightControllerSphereCollider = GameObject.Find("Right Controller").GetComponent<SphereCollider>();
        RightController = GameObject.Find("Right Controller");
        if (LeftControllerSphereCollider == null){
            LeftControllerSphereCollider = GameObject.Find("Left Direct Interactor").GetComponent<SphereCollider>();
            LeftController = GameObject.Find("Left Direct Interactor");
            LeftAttachTransform = GameObject.Find("[Left Direct Interactor] Attach");
        }
        if (RightControllerSphereCollider == null){
            RightControllerSphereCollider = GameObject.Find("Right Direct Interactor").GetComponent<SphereCollider>();
            RightController = GameObject.Find("Right Direct Interactor");
            RightAttachTransform = GameObject.Find("[Right Direct Interactor] Attach");
        }


    }

    public void SetLeftControllerModelsActive(bool active){
        if (!active){ //active= 0, Hand tracking is ON

         //set collider
        LeftControllerSphereCollider.center = LeftHandTrackingColliderOffset;
        

        //set attach transform
        LeftAttachTransform.transform.localPosition = LeftHandTrackingColliderOffset;
        LeftController.GetComponent<XRDirectInteractor>().attachTransform = LeftAttachTransform.transform;

        }
        else{ //active = 0 hand tracking is OFF
        LeftControllerSphereCollider.center = new Vector3(0,0,0);

        //set attach transform
        LeftAttachTransform.transform.localPosition = new Vector3(0,0,0);
        LeftController.GetComponent<XRDirectInteractor>().attachTransform = LeftAttachTransform.transform;



        }
        LeftControllerModel.SetActive(active);
        
    }
    public void SetRightControllerModelsActive(bool active){
         if (!active){ //active= 0, Hand tracking is ON

         //set collider
        RightControllerSphereCollider.center = RightHandTrackingColliderOffset;
        
        //set attach transform
        RightAttachTransform.transform.localPosition = RightHandTrackingColliderOffset;
        RightController.GetComponent<XRDirectInteractor>().attachTransform = RightAttachTransform.transform;


        }
        else{ //active = 0 hand tracking is OFF
        //set collider
        RightControllerSphereCollider.center = new Vector3(0,0,0);
        //set attach transform
        RightAttachTransform.transform.localPosition = new Vector3(0,0,0);
        RightController.GetComponent<XRDirectInteractor>().attachTransform = RightAttachTransform.transform;
        }
        RightControllerModel.SetActive(active);
        
    }
 
}
