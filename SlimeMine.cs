using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMine : MonoBehaviour
{
    //Declare variables
    public float speed;
    private Transform player;
    private Vector2 target;
    public GameObject SlimeKing;
    public GameObject BossMusic;
 


    // Start is called before the first frame update
    void Start()
    {
        //finds player position
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //sets it as target
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        //moves mine towards players location
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //destroys mines on slime kings death
        if (SlimeKing.activeInHierarchy == false)
        {
            //stops music 
            DestroyProjectile();
            BossMusic.SetActive(false);
        }
    }
    //destroys mines if hit player or wall
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }
        if (other.CompareTag("wall"))
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