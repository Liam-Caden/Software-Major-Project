using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room_Move : MonoBehaviour
{
    // Declares Variables
    public Vector2 cameraChangemax;
    public Vector2 cameraChangemin;
    public Vector3 playerChange;
    private CameraMovement cam;
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
          // Changes the max and min of the camera
          cam.minPosition += cameraChangemin;
          cam.maxPosition += cameraChangemax;

            // Moves the player
            other.transform.position += playerChange;


            if(needText)
            {
                StartCoroutine(placeNameCo());
			}
		}
	}
    //Display text for 4 seconds
    private IEnumerator placeNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
	}
}
