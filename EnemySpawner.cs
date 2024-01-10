using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
public class EnemySpawner : MonoBehaviour
{

     [SerializeField]
     private  GameObject[] monsterReference;
     [SerializeField]
     private Slider slider;
     [SerializeField]
     private GameObject monsterSpawm;
     private int index;
     private int side;
     [SerializeField]
     private Transform right, left;
     [SerializeField]
     private GameObject emptyCanvasPRefab;
     [SerializeField]
    private Canvas canvas; // Drag the Canvas here in the inspector
   // private Dictionary<Enemy, EnemyHealth> enemyHealthBars = new Dictionary<Enemy, EnemyHealth>();



    // Start is called before the first frame update
    void Start() 
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters(){
        while (true){
        yield return new WaitForSeconds(Random.Range(5,9));
        index = Random.Range(0,monsterReference.Length);
        side = Random.Range(0,2);
        monsterSpawm = Instantiate(monsterReference[index]);

            if (side == 0){
            monsterSpawm.transform.position  = left.position;
            monsterSpawm.GetComponent<Enemy>().speed = Random.Range(1,4);
        }else{
            monsterSpawm.transform.position = right.position;
            monsterSpawm.GetComponent<Enemy>().speed = -Random.Range(1, 4);
            monsterSpawm.transform.localScale = new Vector3(-1f,1f,1f);
        }
            //GameObject healthBar = Instantiate(healthBarPrefab, monsterSpawm.transform);
            GameObject enemyContainer = Instantiate(emptyCanvasPRefab);

            // Instantiate the health bar as a child of the monster

            // Set the health bar inactive initially
           // healthBar.gameObject.SetActive(false);

            // Create an empty GameObject as a container for the canvas
            GameObject canvasContainer = new GameObject("CanvasContainer");

            // Set the position of the container
            //canvasContainer.transform.position = monsterSpawm.transform.position;

            // Create a Canvas component and set it as a child of the container
           // Canvas canvas = canvasContainer.AddComponent<Canvas>();
           // canvas.renderMode = RenderMode.WorldSpace;

            // Set the canvas container as a child of the monster

            // Set the position of the canvas container relative to its parent (monster)
            //canvas.transform.position = transform.position;
            Canvas Canvas = Instantiate (canvas,monsterSpawm.transform).GetComponent<Canvas>();
            //Canvas.transform.SetParent(monsterSpawm.transform, false);

            Slider healthBar = Instantiate(slider, Canvas.transform).GetComponent<Slider>();
            //healthBar.transform.position = monsterSpawm.transform.position;
            float yOffset = 1.5f; // Adjust the Y value as needed
            float x0ffset = 0.25f;

            // Set the position of the health bar relative to the monster
            Vector3 healthBarPosition = monsterSpawm.transform.position;
            healthBarPosition.y += yOffset;
            if(side == 0){
                healthBarPosition.x += -x0ffset;
            }
            else{
                healthBarPosition.x += x0ffset;
            }

            // Explicitly set the X and Z components of the position
            healthBar.transform.position = new Vector3(healthBarPosition.x, healthBarPosition.y, healthBarPosition.z);
            //monsterSpawm.GetComponent<Enemy>().InitializeHealthBar(healthBar);
            //enemyHealthBars.Add(monsterSpawm.GetComponent<Enemy>(), healthBar.GetComponent<EnemyHealth>());



            // Set the position of the health bar relative to its parent (canvas)
            //healthBar.transform.SetParent(canvas.transform, false);

            Debug.Log("sucess" + slider.transform.position);
           // healthBar.SetActive(false);
            //Enemy enemyHealth = monsterSpawm.GetComponent<Enemy>();
            Debug.Log("Fill Color: " + healthBar.fillRect.GetComponent<Image>().color);
            healthBar.gameObject.SetActive(true);
            RectTransform fillRect = healthBar.fillRect.GetComponent<RectTransform>();
            //fillRect.sizeDelta = new Vector2(fillRect.sizeDelta.x,50);
            Debug.Log("Fill Area Size: " + fillRect.sizeDelta);
            Debug.Log("Health Bar Value: " + healthBar.value);


        }

    }
    // public void UpdateHealthBar(Enemy enemy, float currentHealth, float maxHealth)
    // {
    //     if (enemyHealthBars.ContainsKey(enemy))
    //     {
    //         enemyHealthBars[enemy].UpdateHealthBar(currentHealth, maxHealth);
    //     }
    // }


}
