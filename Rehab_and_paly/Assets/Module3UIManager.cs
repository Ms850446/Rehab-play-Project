using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 using UnityEngine.UI;

public class Module3UIManager : MonoBehaviour
{
    // Start is called before the first frame update

     [SerializeField] private GameObject mode_label_object;
     [SerializeField] private GameObject scoreLabel;
     [SerializeField] private GameObject FixedDelaySlider;
     [SerializeField] private GameObject SpeedUpDelaySlider;
    [SerializeField] private GameObject SpeedUpDelaySliderDecrement;

    
     [SerializeField] private GameObject FixedDelaySliderObject;
     [SerializeField] private GameObject SpeedUpDelaySliderObject;
    [SerializeField] private GameObject SpeedUpDelaySliderDecrementObject;

     
     public string mode   // property
        {
        get { return mode_label_object.GetComponent<TMP_Text>().text; }  
        set { mode = mode_label_object.GetComponent<TMP_Text>().text; }  
        }

         public float fixedDelay   // property
        {
        get { return FixedDelaySliderObject.GetComponent<Slider>().value; }  
        set { fixedDelay = FixedDelaySliderObject.GetComponent<Slider>().value; }  
        }
        public float SpeedUpDelay   // property
        {
        get { return SpeedUpDelaySliderObject.GetComponent<Slider>().value; }  
        set { SpeedUpDelay = SpeedUpDelaySliderObject.GetComponent<Slider>().value; }  
        }
        public float SpeedUpDelayDecrement   // property
        {
        get { return SpeedUpDelaySliderDecrementObject.GetComponent<Slider>().value; }  
        set { SpeedUpDelayDecrement = SpeedUpDelaySliderDecrementObject.GetComponent<Slider>().value; }  
        }


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UiUpdateScore(int score){
        scoreLabel.GetComponent<TMP_Text>().text = "Score: " + score;
    }

    public void UpdateWidgets(){
        Debug.Log("mode clicked and changed" + mode);
        FixedDelaySlider.SetActive(false);
        SpeedUpDelaySlider.SetActive(false);
        SpeedUpDelaySliderDecrement.SetActive(false);
        if (mode == "Fixed Delay"){
        FixedDelaySlider.SetActive(true);

        }
        else if (mode == "Speed Up"){
        SpeedUpDelaySlider.SetActive(true);
        SpeedUpDelaySliderDecrement.SetActive(true);

        }
    }
}
