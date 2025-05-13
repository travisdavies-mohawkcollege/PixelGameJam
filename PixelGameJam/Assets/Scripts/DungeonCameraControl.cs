using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCameraControl : MonoBehaviour
{
    //Declare variables
    public Camera dungeonCamera;
    int camStartingPositionX = 0;
    int camStartingPositionY = 0;
    int camStartingPositionZ = -10;


    // Start is called before the first frame update
    void Start()
    {
        dungeonCamera.transform.position = new Vector3(camStartingPositionX, camStartingPositionY, camStartingPositionZ);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            dungeonCamera.transform.position += new Vector3(0, 0.01f, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            dungeonCamera.transform.position += new Vector3(0, -0.01f, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            dungeonCamera.transform.position += new Vector3(-0.01f, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            dungeonCamera.transform.position += new Vector3(0.01f, 0, 0);
        }
    }
}
