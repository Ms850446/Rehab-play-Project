using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public string objectTag = "Touchable"; // Tag for the collectible objects

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the hand controller
        if (other.gameObject.CompareTag("HandController"))
        {
            // Set the tag for the collectible object
            gameObject.tag = objectTag;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the collider belongs to the hand controller
        if (other.gameObject.CompareTag("HandController"))
        {
            // Reset the tag when the hand controller releases the object
            gameObject.tag = "Untagged";
        }
    }
}
