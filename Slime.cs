using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{

    //Set up variables
    private Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //Assign values
        anim = GetComponent<Animator>();
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        currentState = EnemyState.idle;
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    public virtual void CheckDistance()
    {
        // Is player in chase radius
        StartCoroutine(MoveCo());
	}

    private void ChangeState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;  
		}
	}


    private IEnumerator MoveCo()
    {
    if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            anim.SetBool("WakeUp", true);
            yield return new WaitForSeconds(1f);
            
            //move towards player but not if in stagger
            if(currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            
            changeAnim(temp - transform.position);
            myRigidbody.MovePosition(temp);
            ChangeState(EnemyState.walk);
            anim.SetBool("Moving", true);
            
            }
            if(Vector3.Distance(target.position, transform.position) > chaseRadius)
            {
                anim.SetBool("Moving", false);
                yield return new WaitForSeconds(2f);
                anim.SetBool("WakeUp", false);
               
			}

           
			


		}
	}
    private void SetAnimFloat(Vector2 setVector)
    {
        //set animator to animate
        anim.SetFloat("MoveX", setVector.x);
        anim.SetFloat("MoveY", setVector.y);
	}

     private void changeAnim(Vector2 direction)
            {
        //changes animation based on direction
               if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
               {
                     if(direction.x > 0)
                     {
                            SetAnimFloat(Vector2.right);
				     }else if(direction.x < 0)
                     {
                            SetAnimFloat(Vector2.left);
				     }
			   }else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
               {
                     if(direction.y > 0)
                     {
                        SetAnimFloat(Vector2.up);
				     }else if(direction.y < 0)
                     {
                        SetAnimFloat(Vector2.down);
                     }
			   }
            }


}