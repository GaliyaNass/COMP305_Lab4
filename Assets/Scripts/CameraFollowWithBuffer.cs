using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowWithBuffer : MonoBehaviour {

    public Transform playerPosition;
    public Transform playerMoveThreshold;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerPosition.position.x > playerMoveThreshold.position.x)
        {
            this.transform.position = new Vector3(playerPosition.position.x, this.transform.position.y, this.transform.position.z);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(playerMoveThreshold.position, new Vector2(playerMoveThreshold.position.x, playerMoveThreshold.position.y + 50));
        Gizmos.color = Color.red;
        Gizmos.DrawLine(playerMoveThreshold.position, new Vector2(playerMoveThreshold.position.x, playerMoveThreshold.position.y - 50));

    }
}
