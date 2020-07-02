using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Declare variables
    public float speed;
    private Transform player;
    private Vector2 target;


    // Start is called before the first frame update
    void Start()
    {
        //sets variables and targets player
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        //shoots projectiles
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            //destroy projectile when it reaches its destination
            DestroyProjectile();
        }
      
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //destroys projectile on hit
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }
       
    }

    void DestroyProjectile()
    {
        //destroy
        Destroy(gameObject);
    }
}
