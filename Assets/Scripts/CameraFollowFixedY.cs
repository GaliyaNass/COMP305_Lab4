using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowFixedY : MonoBehaviour {

    public Transform playerPosition;
    public Camera mainCamera;
    public Camera zoomCamera;
    public Rigidbody2D rBody;

    public float max, min;

    //Runs on the first frame this object collides with another object
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            mainCamera.enabled = false;
            zoomCamera.enabled = true;
            
        }
    }

    //Runs on the last frame this object collides with an object leaving its area
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            mainCamera.enabled = true;
            zoomCamera.enabled = false;
        }
    }

    //Runs on every frame that an object is in the collision area
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            zoomCamera.transform.LookAt(playerPosition);
            max = 34;
            min = 7;
            if (rBody.velocity.x < 0) //zoom out
            {
                zoomCamera.fieldOfView++;
                if (zoomCamera.fieldOfView > max)
                {
                    zoomCamera.fieldOfView = max;
                }
            }
            if (rBody.velocity.x > 0) //zoom in
            {
                zoomCamera.fieldOfView--;
                if (zoomCamera.fieldOfView < min)
                {
                    zoomCamera.fieldOfView = min;
                }
            }
        }
    }

}
