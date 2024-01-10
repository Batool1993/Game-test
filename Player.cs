using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;
    private float movementX;
    private float movementY;
    private  bool isGround;
    private string Ground = "Ground";
    private string Enemy = "Enemy";
    public Transform shootingPoint;
    public GameObject Bullet;

    private Rigidbody2D myBody;

    private Animator anim;
    private SpriteRenderer sr;
    private string WALK_ANIMATION = "Walk";
    private SpriteRenderer WeaponSR;
    [SerializeField]
    private Slider slider;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        WeaponSR = shootingPoint.GetComponent<SpriteRenderer>();
        Slider healthBar = Instantiate(slider, myBody.transform).GetComponent<Slider>();
        healthBar.gameObject.SetActive(true);
    }

    void Start()
    {

    }

    void Update()
    {
        PlayerMoveKeyboard();
        PlayerAnimation();
        PlayerJump();
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log(true);
            GameObject newBulletObject = Instantiate(Bullet);
            newBulletObject.transform.position = shootingPoint.position;
            newBulletObject.transform.rotation = transform.rotation;
            Bullet bulletScript = newBulletObject.GetComponent<Bullet>();

            // Ensure the Bullet script is not null
            if (bulletScript != null)
            {
                // Determine the direction based on the player's facing direction
                float playerDirection = Mathf.Sign(shootingPoint.localPosition.x);
                Debug.Log("Player Durection: " + playerDirection);

                // Set the direction of the newly instantiated bullet
                bulletScript.SetDirection(new Vector2(playerDirection, 0f));
            }
            else
            {
                Debug.LogError("Bullet script not found on the instantiated Bullet object.");
            }
        }

    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void PlayerAnimation(){
        if(movementX > 0){
            anim.SetBool(WALK_ANIMATION,true);
            sr.flipX = false;
            WeaponSR.flipX = false;
           // transform.localScale = new Vector3(Mathf.Abs(transform.localPosition.x), transform.localScale.y, 0f);
            shootingPoint.localPosition = new Vector3(Mathf.Abs(shootingPoint.localPosition.x), shootingPoint.localPosition.y, 0f);
        }
        else if(movementX < 0){
            anim.SetBool(WALK_ANIMATION,true);
            sr.flipX = true;
            WeaponSR.flipX = true;
           // transform.localScale = new Vector3(-Mathf.Abs(transform.localPosition.x), transform.localScale.y, 0f);

            //shootingPoint.transform.localScale = new Vector3(-1f,1f,1f);
            shootingPoint.localPosition = new Vector3(-Mathf.Abs(shootingPoint.localPosition.x), shootingPoint.localPosition.y, 0f);
        }
        else
        {
            anim.SetBool(WALK_ANIMATION,false);
        }
        if(movementY > 0){
            anim.SetBool(WALK_ANIMATION,false);
        }
    }

    void PlayerJump(){
        if(Input.GetButtonDown("Jump") && isGround){
            Debug.Log("Jumped");
            isGround = false;
            myBody.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag(Ground)){
            isGround = true;
        }
        if(collision.gameObject.CompareTag(Enemy)){
          Destroy(gameObject);
        }
    }
    public void UpdateHealthBar(float currentHealth)
    {
        slider.value += currentHealth;
        Debug.Log("Health bar value2" + slider.value);
    }
}

