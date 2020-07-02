using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerState{
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class PlayerMovement : MonoBehaviour
{

    // Create Variables
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public VectorValue startingPosition;
    public FloatValue currentHealth;
    public SignalSender playerHealthSignal;
    public Inventory playerInventory;
    public SpriteRenderer getItemSprite;
    public GameObject Mine;
    public GameObject DeathScreen;
   

    // Start is called before the first frame update
    void Start()
    {
        //Set up Variables
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
       myRigidbody = GetComponent<Rigidbody2D>();
        transform.position = startingPosition.initialValue;
       
    }



    // Update is called once per frame
    void Update()
    {
        //if player is in interact do nothing
        if (currentState == PlayerState.interact)
        {
            return;
        }

        //update health
        playerHealthSignal.Raise();

        //Set up change to = direction
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        
        //if press space and player has sword attack
        if(Input.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger && playerInventory.HasSword == true)
        {
            StartCoroutine(AttackCo());
		}
        //move and animate
        else if(currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
		}
        //If player presses M and has defeated slime king place a mine 
        if (Input.GetButtonDown("SlimeWand") && currentState != PlayerState.attack && currentState != PlayerState.stagger && playerInventory.HasMine == true && playerInventory.Mines >= 1)
        {
            Instantiate(Mine, transform.position, Quaternion.identity);
            playerInventory.Mines = playerInventory.Mines - 1;
        }
        //move and animate
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }

    }

        private IEnumerator AttackCo()
        {
             //animates atack
            animator.SetBool("attacking", true);
            //sets state machine
            currentState = PlayerState.attack;
            yield return null;
            //after attack turn animation off
            animator.SetBool("attacking", false);
            yield return new WaitForSeconds(.3f);
            //get out of signs with space
            if(currentState != PlayerState.interact)
            {
            currentState = PlayerState.walk;
			}
            
		}

        //raises item above players head
        public void RaiseItem()
        {
            if(currentState != PlayerState.interact)
            {
                animator.SetBool("Get Item", true);  
                currentState = PlayerState.interact;
                getItemSprite.sprite = playerInventory.currentItem.itemSprite;
            }else
            {
                animator.SetBool("Get Item", false);
                currentState = PlayerState.idle;
                getItemSprite.sprite = null;
                currentState = PlayerState.idle;
            }
		}
  

    void UpdateAnimationAndMove()
        {

        // Animate Character when moving or Idle
        if (change != Vector3.zero)
        {
            MoveCharacter();  
            animator.SetFloat("move_x", change.x);
            animator.SetFloat("move_y", change.y);
            animator.SetBool("moving", true);
		}
        else
        {
            animator.SetBool("moving", false); 
		}  
		}
         
       
        
        void MoveCharacter()
        {
            //Make character move
            change.Normalize();
            myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime); 
		}

        public void Knock(float knockTime, float damage)
        {
            //take damage
            currentHealth.RuntimeValue -= damage;
            playerHealthSignal.Raise();

            if(currentHealth.RuntimeValue > 0)
            {
                StartCoroutine(KnockCo(myRigidbody, knockTime));  
            }else
            {
                //kill the character
                this.gameObject.SetActive(false);
            DeathScreen.SetActive(true);
			}
		}

        private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if(myRigidbody != null)
        {
            //take knockback
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            
		}
	}

    public void BackToMenu()
    {
        SceneManager.LoadScene("StartMenu");

    }

}
