using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potrol : MonoBehaviour
{
    public int health = 50;


    public float speed;

    private bool movingright = true;

    public Transform grounddetection;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }
     
    void Die()
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

       
        RaycastHit2D groundinfo = Physics2D.Raycast(grounddetection.position, Vector2.down, 2f);
        if (groundinfo.collider == false)
        {
            if (movingright == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingright = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingright = true;
            }
        }
    }
}
