using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
public class UpdateSpeed : MonoBehaviour
{
    private Slider speedSlider;
    public TextMeshProUGUI speedtext;
    //Updates the text to display the speed as the slider is moved
    void Start()
    {
        speedSlider = GetComponent<Slider>();
        SpeedChanged();
        speedSlider.onValueChanged.AddListener(delegate { SpeedChanged (); });
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    
    void SpeedChanged()
    {
        speedtext.text = ((int)speedSlider.value).ToString()+" ft.";
    }
}
