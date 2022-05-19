using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //Creates an offset based on the camera and player position
        offset = transform.position - player.transform.position;
        Debug.Log("x offset: " + offset.x);
        Debug.Log("y offset: " + offset.y);
        Debug.Log("z offset: " + offset.z);

    }

    // Update is called once per frame
    void Update()
    {
        //Transforms the position of the camera to that of the players position plus the offset
        transform.position = player.transform.position + offset;
    }
}
