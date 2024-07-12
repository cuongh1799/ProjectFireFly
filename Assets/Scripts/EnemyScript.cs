using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject player; // a target to chase
    public Rigidbody2D rb;

    public float speed;
    private float health = 5;

    [HideInInspector]
    private float lastx;
    private float newx;
    SpriteRenderer sr;
    

    // Start is called before the first frame update
    void Start()
    {
        lastx = 0;
        newx = 0;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        lastx = transform.position.x;
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        newx = transform.position.x;
        if(newx - lastx < 0)
        {
            sr.flipX = true;
        }
        else if(newx - lastx > 0)
        {
            sr.flipX = false;
        }
    }

    public void takeDamage()
    {
        Debug.Log("Enemy is taking damage");
        Debug.Log("Enemy is now at " + (health - 1) + " health");
        health--;
    }

    
}
