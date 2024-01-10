using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    private Rigidbody2D myBody;
    public float speed;
    [SerializeField]
    private float health, maxHealth = 100;
    //[SerializeField]
    //EnemyHealth healthBar;
    //public GameObject HealthBar;
    private EnemySpawner enemyHealth;
    //[SerializeField]
    private EnemyHealth healthBarNew;
    private EnemySpawner enemySpawner;
    int expAmount = 100;

    // Start is called before the first frame update


    void Awake(){
        myBody = GetComponent<Rigidbody2D>();
        //healthBar = GetComponent<EnemyHealth>();


       // Debug.Log("Component" + healthBar);
    }

    void Start()
    {


        // Set the initial health values
        health = maxHealth;
        healthBarNew = GetComponentInChildren<EnemyHealth>();

        // Get the EnemyHealth component from the instantiated healthBarObject
        enemyHealth = FindObjectOfType<EnemySpawner>();


        //EnemyHealth healthBar = healthBarObject.GetComponent<EnemyHealth>();

        //healthBar.UpdateHealthBar(health, maxHealth);

    }

    void FixedUpdate(){
        myBody.velocity = new UnityEngine.Vector2(speed,myBody.velocity.y);
    }

    // public void InitializeHealthBar(Slider slider)
    // {
    //     healthBar = slider;
    //     // Set initial health bar values
    // }
    // private void UpdateHealthBar()
    // {
    //     enemySpawner.UpdateHealthBar(this, health, maxHealth);
    // }
    private void UpdateHealthBar(EnemyHealth healthBar)
    {
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(health, maxHealth);
        }
        else
        {
            Debug.LogError("EnemyHealth script not found!");
        }
    }



    public void TakeDamage(float damageAmount){
        health -= damageAmount;
        UpdateHealthBar(healthBarNew);


        Debug.Log("test" + health);
        Debug.Log("Health" + health);
        if(health <= 0){
            Destroy(gameObject);
            ExperienceManager.Instance.AddExperience(expAmount);
        }
    }
}
