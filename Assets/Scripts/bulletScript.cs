using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        EnemyScript enemy = collision.GetComponent<EnemyScript>();
        if(enemy != null)
        {
            enemy.takeDamage();
        }
        DestroyObject(gameObject);
    }
}
