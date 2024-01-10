using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    [SerializeField]
    int currentHealth , maxHealth , currentExperience , maxExperience , currentLevel;
    //public GameObject HealthBar;
    private PlayerHealth healthBarNew;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable(){
        ExperienceManager.Instance.OnExperienceChange += HandleExperienceChange;
        healthBarNew = GetComponentInChildren<PlayerHealth>();
        Debug.Log("healthBarNew" + healthBarNew);

    }

    private void OnDisable(){
        ExperienceManager.Instance.OnExperienceChange -= HandleExperienceChange;
    }
    private void HandleExperienceChange(int newExperience){
        currentExperience += newExperience;
        healthBarNew = GetComponentInChildren<PlayerHealth>();
        UpdateHealthBar(healthBarNew);
        if (currentExperience >= maxExperience){
            levelUp();
        }
    }

    private void levelUp(){

        Debug.Log("currentHealth" + currentHealth);
        maxHealth += 10;
        currentHealth = maxHealth;
        currentLevel ++;
        currentExperience = 0;
        maxExperience += 100;
    }

    private void UpdateHealthBar(PlayerHealth healthBar)
    {
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(currentExperience, maxExperience, currentLevel);
        }
        else
        {
            Debug.LogError("EnemyHealth script not found!");
        }
    }
}
