using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class DragDropScript : MonoBehaviour
{
    Vector3 offset;
    public string destinationTag = "DropArea";
    void OnMouseDown(){
        offset = transform.position - MouseWorldPosition();
        transform.GetComponent<Collider>().enabled = false;
    }
    void OnMouseDrag() {
        transform.position = MouseWorldPosition() + offset;
    }
    void OnMouseUp() {
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit hitInfo;
        if(Physics.Raycast(rayOrigin, rayDirection, out hitInfo)){
            if(hitInfo.transform.tag == destinationTag){
                transform.position = hitInfo.transform.position;

            }
        }
        transform.GetComponent<Collider>().enabled = true;
    }
    Vector3 MouseWorldPosition(){
        var MouseScreenPos = Input.mousePosition;
        MouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.WorldToScreenPoint(MouseScreenPos);
    }
}
