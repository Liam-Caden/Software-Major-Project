using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    //Declare variables
    private float timeBtwShots;
    public float startTimeBtwShots;
    public float attackRadius;

    public GameObject projectile;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        //set variables
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        //shoot after certain time towards player
        if (Vector2.Distance(player.position, transform.position) < attackRadius)
        {
            if (timeBtwShots <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }
}
