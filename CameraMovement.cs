using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

   //Declare variables
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;

  



    // Update is called once per frame
    void LateUpdate()
    {
        
        // Moves the camera towards player if not on player
        if(transform.position != target.position)
        {
              Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

              //sets the max and min limits
              targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);

              targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

              transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
		}
    }
}
