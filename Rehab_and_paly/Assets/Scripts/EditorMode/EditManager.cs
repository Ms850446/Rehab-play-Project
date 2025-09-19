using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditManager : MonoBehaviour
{
    public List<GameObject> objectsInRegion;
    EventListener eventListener;

    // Start is called before the first frame update
    void Start()
    {
        eventListener = GetComponent<EventListener>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addNewObject(GameObject gameObject){
        

        objectsInRegion.Add(gameObject);
        Debug.Log(gameObject.name);
        eventListener.instantiateObjectByName(gameObject.name);
        int len = gameObject.name.Length;
        if (len < 40){
            gameObject.name += "_added";
        }
        
        
    }
    public void removeGameObject(GameObject gameObject){
        for(int i =objectsInRegion.Count-1 ; i>=0; i++){
            if (objectsInRegion[i].name == gameObject.name){
                objectsInRegion.RemoveAt(i);
                break;
            }
            
        }
    }
}
