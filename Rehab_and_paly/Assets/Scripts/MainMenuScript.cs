using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // public void StartBtn(){
    //     SceneManager.LoadScene("MainMenu");
    // }
    public void Level1Btn(){
        SceneManager.LoadScene("Level 1");
    }
    public void Level2Btn(){
        SceneManager.LoadScene("Level 2");
    }
    public void Level3Btn(){
        SceneManager.LoadScene("Level 3");
    }
    
}
