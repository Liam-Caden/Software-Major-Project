using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    public void Smash(){
    //Smash pot
    anim.SetBool("Smash", true);
    StartCoroutine(breakCO());
	}

    IEnumerator breakCO()
    {
        //sets pot inactive
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
	}
}
