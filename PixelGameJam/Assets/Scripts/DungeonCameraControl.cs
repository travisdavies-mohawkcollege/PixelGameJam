using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCameraControl : MonoBehaviour
{
    //Declare variables
    public Camera dungeonCamera;
    public DungeonManager dungeonManager;
    public GameManager gameManager;
    int camStartingPositionX = 0;
    int camStartingPositionY = 0;
    int camStartingPositionZ = -10;
    float camRightClamp = 0;
    float camLeftClamp;
    public GameObject adventurer;

    // Start is called before the first frame update
    void Start()
    {
        dungeonCamera.transform.position = new Vector3(camStartingPositionX, camStartingPositionY, camStartingPositionZ);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.GetComponent<GameManager>().gameState == 3)
        {
            adventurer = GameObject.FindGameObjectWithTag("Adventurer");
            dungeonCamera.transform.position = new Vector3(adventurer.transform.position.x, camStartingPositionY, camStartingPositionZ);
        }


        else if (gameManager.GetComponent<GameManager>().gameState == 1)
       {
            if (Input.GetKey(KeyCode.A))
            {
                dungeonCamera.transform.position += new Vector3(-0.01f, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                dungeonCamera.transform.position += new Vector3(0.01f, 0, 0);
            }
            //clamp the camera to the dungeon
            camLeftClamp = dungeonManager.entrancePos.x;
            if (dungeonCamera.transform.position.x < dungeonManager.entrancePos.x)
            {
                dungeonCamera.transform.position = new Vector3(camLeftClamp, camStartingPositionY, camStartingPositionZ);
            }
            if (dungeonCamera.transform.position.x > camRightClamp)
            {
                dungeonCamera.transform.position = new Vector3(camRightClamp, camStartingPositionY, camStartingPositionZ);
            }
        }
       


    }
}
