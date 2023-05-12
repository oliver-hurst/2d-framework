using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stomp : MonoBehaviour
{

    public float bounce;
     Rigidbody2D rb;
    bool IsBouncing;

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        if (IsBouncing)
        {
            rb.AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("top"))
        {
  
            if (other.GetComponentInParent<potrol>() != null)
            {
                other.GetComponentInParent<potrol>().TakeDamage(100);
            }

            
            Debug.Log("hit");
            rb.velocity = new Vector2(rb.velocity.x, 0);
            StartCoroutine(BounceTimer());
        }
    }

    IEnumerator BounceTimer()
    {
        IsBouncing = true;
        yield return new WaitForSeconds(0.01f);
        IsBouncing = false;
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag == "top")
    //    {
    //        
    //        Destroy(collision.gameObject);
    //    }
    //}
}
