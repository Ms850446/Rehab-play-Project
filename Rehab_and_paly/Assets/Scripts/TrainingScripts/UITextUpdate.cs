using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITextUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI textMeshPro;

    [SerializeField]
    private ControllerData controllerData;
    public bool selecting = false;
    public bool assesment_started = false;

    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (assesment_started)
        {
            AssesmentStarted();
        }
        
    }

    private void AssesmentStarted()
    {
        if (selecting)
            textMeshPro.text =
                "Right controller Velocity: "
                + controllerData.controllerRightVelocity
                + "\nLeft controller Velocity: "
                + controllerData.controllerLeftVelocity;
        else
            textMeshPro.text = "Hold back another Object";
    }

    public void AssesmentFinished()
    {
        MenuManager.OpenMenu(Menu.RESULTS_MENU);
    }

    public void SetSelectedflag()
    {
        selecting = true;
    }

    public void ClearSelectedflag()
    {
        selecting = false;
    }

    public void SetAssesmentStarted()
    {
        assesment_started = true;
    }
}
