using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCameraFollow : MonoBehaviour {

    public Camera mainCamera;
    public Camera stopCamera;


    //Runs on the first frame this object collides with another object
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            mainCamera.enabled = false;
            stopCamera.enabled = true;
        }
    }

    //Runs on the last frame this object collides with an object leaving its area
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            mainCamera.enabled = true;
            stopCamera.enabled = false;
        }
    }

}
