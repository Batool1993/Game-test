using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
[SerializeField]
    private float speed;
    private Vector2 bulletDirection;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not found on Bullet GameObject.");
        }
       // BulletDirection();
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();

        //bulletDirection = Input.GetAxisRaw("Horizontal");
    }

    public void SetDirection(Vector2 direction)
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb != null) // Check if rb is not null
        {
            float adjustedSpeed = speed * 500f;
            rb.velocity = direction.normalized * (adjustedSpeed * Time.deltaTime);

            Debug.Log("Bullet speed" + rb.velocity);
        }
        else
        {
            Debug.LogError("Rigidbody2D component is null in SetDirection.");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent)){
            enemyComponent.TakeDamage(25);
        }
        if(collision.gameObject.CompareTag("Enemy")){
            Destroy(gameObject);
        }
    }

}
