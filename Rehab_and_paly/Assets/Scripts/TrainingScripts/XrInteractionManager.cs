using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


[AddComponentMenu("XR/XR Interaction Manager")]
[DisallowMultipleComponent]
[DefaultExecutionOrder(-100)]


public class XrInteractionManager : XRInteractionManager
{
    
    public  override void SelectExit(IXRSelectInteractor interactor, IXRSelectInteractable interactable){

        base.SelectExit(interactor, interactable);
    }
    protected override void OnEnable(){
        base.OnEnable();
    }
    protected override void OnDisable(){
        base.OnDisable();
    }
}
