using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    //Declare Variables
    public GameObject dungeonPrefab;
    public Camera dungeonCam;
    public GameObject hoardPrefab;
    public GameObject playerRoomPrefab;
    public GameObject nextRoomMarker;
    public GameObject entrance;
    int roomCount;
    int roomsOwned;
    float roomWidth;
    float roomHeight;
    
    bool hasTrap;
    float roomCentre;
    float roomOffsetX;
    List<GameObject> rooms = new List<GameObject>();
    Vector3 entrancePos = new Vector3(-9.85f, 0, 0);
    //Variables for locked rooms
    bool isLocked;
    int unlockCost;
    //mask layer for deciding whats interactable
    public LayerMask raycastLayerMask;



    // Start is called before the first frame update
    void Start()
    {
        roomCount = 3;
        roomsOwned = 3;
        roomOffsetX = 0;
        roomWidth = dungeonPrefab.transform.localScale.x;
        roomHeight = dungeonPrefab.transform.localScale.y;
        roomCentre = roomWidth / 2;
        entrance.transform.position = entrancePos;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (roomCount <= roomsOwned)
        {
            CreateRoom();
        }
        if (Input.GetMouseButtonDown(0))
        {
            //Make a ray to mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //see if ray hit something on the mask layer
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, raycastLayerMask);
            if (hit)
            {
                Debug.Log("You clicked " +hit.collider.tag);
            }

        }

    }

    void CreateRoom()
    {
        //Create a new room
        roomCount += 1;
        entrancePos.x -=3.28f;
        entrance.transform.position = entrancePos;
        roomOffsetX = nextRoomMarker.transform.position.x;
        GameObject newRoom = Instantiate(dungeonPrefab, new Vector3(roomOffsetX, 0, 0), Quaternion.identity);
        rooms.Add(newRoom);
      

    }
}
