using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


[System.Serializable]
public class ActionData
{
    public string action;
}


public class sendRequests : MonoBehaviour
{
    
    [SerializeField] public int pk;
    public void postJson(string url, string json)
    {
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);

        // Create request
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        // Send request
        request.SendWebRequest().completed += (asyncOperation) =>
        {
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + request.error);
            }
            else
            {
                Debug.Log("Score sent successfully");
            }
        };
    }

    // Example method to call when game is finished
    public void SendString(string action, string url)
    {
        // Create ActionData object and serialize to JSON
        ActionData data = new ActionData();
        data.action = action;

        string json = JsonUtility.ToJson(data);
        Debug.Log("JSON: " + json); // Print JSON to debug

        postJson(url, json);
    }

    // Example method to call when game is finished
    public void BookHovored(int level)
    {
        SendString("level"+level+";hovor;"+ pk, "http://localhost:8000/ROM/");
    }

    public void bookReachedTarget(int level)
    {
        SendString("level"+level+";rechedTarget;"+ pk, "http://localhost:8000/ROM/");
    }


}
