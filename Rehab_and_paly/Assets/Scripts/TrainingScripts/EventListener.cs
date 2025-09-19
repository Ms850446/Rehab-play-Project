using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class EventListener : MonoBehaviour
{
    // Start is called before the first frame update



    [SerializeField] List<GameObject> Shapes;

    [SerializeField]
    private List<GameObject> spawnPoints; 
    [SerializeField]
    private List<GameObject> lastInstantiatedObjects; 

    void Start()
    {

        if (Shapes.Count > spawnPoints.Count){
            Debug.LogError("all shapes need to have spawn point, please add an empty object as a spawnpoint");

        }
        for (int i = 0; i<Shapes.Count; i++){
            lastInstantiatedObjects.Add(Shapes[i]);

        }



        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 
    public void instantiateObject(int index){
        var newObject = Instantiate(Shapes[index],spawnPoints[index].transform.position,spawnPoints[index].transform.rotation);
        lastInstantiatedObjects[index] = newObject;
   

        
    }
  
    public void instantiateObjectByName(String name){
        int index = -1;
        for (int i=0; i<Shapes.Count; i++){
            Debug.Log(Shapes[i].name);
            if(name == Shapes[i].name || name == Shapes[i].name + "(Clone)"){
                index = i;
            }

        }
        if (index != -1){
           
        var newObject = Instantiate(Shapes[index],spawnPoints[index].transform.position,spawnPoints[index].transform.rotation);
        lastInstantiatedObjects[index] = newObject;
        }

        
    }
/*
    public void DestroyLastObject(int index){
        Destroy(lastInstantiatedObjects[index]);
        
        
    }
*/
   
    
    
}
