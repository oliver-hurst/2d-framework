using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Rigidbody2D rb;

      void Start()
    {
        rb.velocity = transform.right * speed;
    }

    //    void OnTriggerEnter2D(Collider2D hitinfo)
    //    {
    //        potrol Potrol = hitinfo.GetComponent<potrol>();
    //        if(Potrol != null)
    //        {
    //            Potrol.TakeDamage(damage);
    //        }
    //    }
}
