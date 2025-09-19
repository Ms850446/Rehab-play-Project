using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityCalculation : MonoBehaviour
{
    [SerializeField] private ControllerData controllerData;
    [SerializeField] private AssementManager assementManager;

    [SerializeField] private DrawLineTracking drawLineTracking;
    [SerializeField] private sendRequests sendRequest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void assesmentFinished(){
        float temp;
        string request_string = "";
        for (int i =0; i<9; i++){
            temp = 0;
            foreach (float time in controllerData.allDeltaTimes[i]){
                temp += time;
            }

            if (temp == 0) continue;
            print("average v");
            print(assementManager.displacements[i]/temp);
            request_string += "average:"+ assementManager.displacements[i]/temp + "/";
            //here store the  average velocity

            //calculating speed
            print(drawLineTracking.calculateLineDistance(i)/temp);
            request_string += "speed:"+ drawLineTracking.calculateLineDistance(i)/temp + ";";



        
        
        }

        request_string += sendRequest.pk;
        sendRequest.SendString(request_string,  "http://localhost:8000/velocity/");
    }



}
