using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;
using TMPro;

public class slidervalueprinter : MonoBehaviour
{   [SerializeField] GameObject slider;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMP_Text>().text = " " + System.Math.Round(slider.GetComponent<Slider>().value,3)+ " s";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onchange(){
        GetComponent<TMP_Text>().text = " " + System.Math.Round(slider.GetComponent<Slider>().value,3)+ " s";

    }
}
