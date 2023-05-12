using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wepon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firepoint;
    public GameObject swordprefab;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(swordprefab, firepoint.position, firepoint.rotation);
    }
}
