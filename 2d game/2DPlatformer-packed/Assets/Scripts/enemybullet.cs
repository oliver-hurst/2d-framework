using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemybullet : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    public float speed;
    private Rigidbody2D rb;
    private float timer;
    public int currenthealth = 100;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("player");
        
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;

       
    
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 10)
        {
            Destroy(gameObject);
        }

    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            other.gameObject.GetComponent<BasicCharacterController>().TakeDamage(20);
            //healthbar.instance.SetHealth(currenthealth); ;

           Destroy(gameObject);
        }  
    }
}


