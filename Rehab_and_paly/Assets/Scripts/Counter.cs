
using UnityEngine;

public class Counter : MonoBehaviour
{
    public int scoreIncrease = 1; // Amount to increase score by
    public LayerMask handLayer; // Layer for the hand controller
    public bool hasBeenTouched = false; // Flag to prevent multiple score increases
    public bool currentlyDisabled = false; // Flag to prevent multiple score increases

    [SerializeField] GameObject CubeChild;
    private string mode;
    [SerializeField] private GameObject mode_label_object;
    void Start()
    {
        // Assign the layer for the hand controller
        handLayer = LayerMask.GetMask("Interactable");
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        
        // Check if the collider belongs to the hand controller
        if ((other.gameObject.name == "L_Wrist" || other.gameObject.name ==  "R_Wrist" || other.gameObject.name == "Left Hand Model" || gameObject.name == "Right Hand Model"  ) && !hasBeenTouched && !currentlyDisabled)
        {
            if (CubeChild){
                 CubeChild.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
            }
           
            

            // Set flag to prevent further score increases
            hasBeenTouched = true;

            // Optionally, disable collider to prevent multiple interactions
            // GetComponent<Collider>().enabled = false;
        }
    }

    public void interaction(){
        Debug.Log("interaction");
        if(!hasBeenTouched && !currentlyDisabled)
        {
            if (CubeChild){
                 CubeChild.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
            }
           
            

            hasBeenTouched = true;

        }
    }

    public void disableEmissionMaterial(){
        CubeChild.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
    }
}
