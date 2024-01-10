using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private Slider slider ;
    [SerializeField] private Text textValue;

    [SerializeField] private Slider levelSlider;
    [SerializeField] private Text levelTextValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthBar(float currentExp , float maxExp , float level)
    {
        slider.value = currentExp / maxExp;
        textValue.text = "XP: " + slider.value.ToString("F2");
        levelSlider.value = level;
        levelTextValue.text = "Level: " + level.ToString("F0");
        Debug.Log("Health bar value newww" + slider.value);
    }
}
