using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour
{

    private int maxHealth = 100;
    private int currentHealth;
    [SerializeField]
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
        Debug.Log("Health bar value2" + slider.value);
    }
    //public void UpdateHealthBar()
}
