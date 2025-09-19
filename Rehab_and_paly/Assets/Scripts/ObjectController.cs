using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class ObjectController : MonoBehaviour
{
    public GameObject[] objectsToControl;

    private Module3UIManager UIManager;
    [SerializeField] private float minInterval = 1.0f; // Minimum interval in seconds
    [SerializeField] private float maxInterval = 5.0f; // Maximum interval in seconds

    private bool gameStarted = false;
    private int counter = 0;
    private float timer;



    [SerializeField] private float ModeDelay = 3f;
    private float speedupModeDelayDecrement = 0.1f;
    private int current_active_index ;
    private List<int> toBeDisabled ;
   
    private string mode;

    private void Start()
    {
        UIManager = GetComponent<Module3UIManager>();
        toBeDisabled = new List<int>();
        // Deactivate all objects initially
        foreach (GameObject obj in objectsToControl)
        {
            obj.SetActive(false);
        }

      
      
    }


    public void startGame(){
        InitGame();
        gameStarted = true;
        mode = UIManager.mode;

        if (mode == "Fixed Delay")
            ModeDelay = UIManager.fixedDelay;
        else if(mode == "Speed Up"){
            ModeDelay = UIManager.SpeedUpDelay;
            speedupModeDelayDecrement = UIManager.SpeedUpDelayDecrement;

        }
        counter = 0;
        UIManager.UiUpdateScore(counter);
        Debug.Log(mode);
        ToggleRandomObject();
        
    }

    private void InitGame(){
        foreach (GameObject obj in objectsToControl){
            var ctr = obj.GetComponent<Counter>();
            ctr.disableEmissionMaterial();
            ctr.hasBeenTouched = false;
            ctr.currentlyDisabled = false;
            timer = ModeDelay;
            obj.SetActive(false);

        }
    }

    private void Update()
    {

        if (gameStarted){
            
            // timer dependent modes
            if (mode == "Speed Up" || mode == "Fixed Delay"){
                if (timer > 0){
                timer -= Time.deltaTime; 
                }
                else{
                    // what should you do when the time is up?
                    immediatlyDisableObject();
                    ToggleRandomObject();
                    timer = ModeDelay;
                }
        
                
            }

            
            // here is the logic for if the hand touched the objects i.e. collision
            Counter counterobj = objectsToControl[current_active_index].GetComponent<Counter>();
            if (counterobj.hasBeenTouched && ! counterobj.currentlyDisabled){
                counterobj.hasBeenTouched = false;
                counterobj.currentlyDisabled = true;

                counter ++;
                UIManager.UiUpdateScore(counter);
                if (mode != "Fixed Delay")disableObject();
                Debug.Log("counter: " + counter);
                if (mode == "Speed Up" && ModeDelay > 0.6){
                    ToggleRandomObject();
                    ModeDelay -= speedupModeDelayDecrement;
                    timer = ModeDelay;

                    
                }
                else if (mode == "No Delay"){
                    ToggleRandomObject();
                }
            }
        }
    }

    private void immediatlyDisableObject(){

        objectsToControl[current_active_index].GetComponent<Counter>().disableEmissionMaterial();
        objectsToControl[current_active_index].GetComponent<Counter>().hasBeenTouched = false;
        objectsToControl[current_active_index].GetComponent<Counter>().currentlyDisabled = false;

        objectsToControl[current_active_index].SetActive(false);

    }
    private void disableObject(){
        objectsToControl[current_active_index].GetComponent<Counter>().currentlyDisabled = true;
        toBeDisabled.Add(current_active_index);
        Invoke("disableobjectdelayed", 0.5f);
        print(toBeDisabled);
        objectsToControl[current_active_index].GetComponent<Counter>().hasBeenTouched = false;
    }

    private void disableobjectdelayed(){
            objectsToControl[current_active_index].GetComponent<Counter>().currentlyDisabled = false;
            objectsToControl[toBeDisabled[0]].SetActive(false);
            objectsToControl[toBeDisabled[0]].GetComponent<Counter>().disableEmissionMaterial();
            toBeDisabled.RemoveAt(0);

    }
 
    private void ToggleRandomObject()
    {

        print("activating random" + counter);

        int newIndex = Random.Range(0, objectsToControl.Length);

        while (true){
            bool breaking = true;
            foreach (int i in toBeDisabled) if (i == newIndex) breaking = false;
            if (breaking && newIndex != current_active_index)break;
            else newIndex = Random.Range(0, objectsToControl.Length);
        }
        current_active_index = newIndex;
        objectsToControl[newIndex].SetActive(true);
        objectsToControl[newIndex].GetComponent<Counter>().hasBeenTouched = false;
        objectsToControl[newIndex].GetComponent<Counter>().currentlyDisabled = false;

        
        
    }


}
