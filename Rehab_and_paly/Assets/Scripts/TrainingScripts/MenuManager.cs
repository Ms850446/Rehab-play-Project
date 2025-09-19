using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MenuManager 
{
    public static bool IsInitialized { get; private set;

    }
    
    public static GameObject assesmentMenu, resultsMenu;
   public static void Init(){
    GameObject canvas = GameObject.Find("Velocity_Track");

    assesmentMenu = canvas.transform.Find("assesmentMenu").gameObject;
    resultsMenu = canvas.transform.Find("resultMenu").gameObject;

    IsInitialized = true;

   }

   public static void OpenMenu(Menu menu){

    if (!IsInitialized) Init();

        switch (menu)
        {
            case Menu.ASSESMENT_MENU:
                assesmentMenu.SetActive(true);
                resultsMenu.SetActive(false);

                break;
            case Menu.RESULTS_MENU:
                resultsMenu.SetActive(true);
                assesmentMenu.SetActive(false);
                break;

        }
        
        

   }
}
