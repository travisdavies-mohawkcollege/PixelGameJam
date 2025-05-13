using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    //Declare Variables
    public GameObject dungeonPrefab;
    public GameObject hoardPrefab;
    public GameObject playerRoomPrefab;
    public GameObject nextRoomMarker;
    public GameObject entrance;
    int roomCount;
    int roomsOwned;
    float roomWidth;
    float roomHeight;
    bool isLocked;
    bool hasTrap;
    float roomCentre;
    float roomOffsetX;
    List<GameObject> rooms = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        roomCount = 3;
        roomsOwned = 3;
        roomOffsetX = 0;
        roomWidth = dungeonPrefab.transform.localScale.x;
        roomHeight = dungeonPrefab.transform.localScale.y;
        roomCentre = roomWidth / 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (roomCount <= roomsOwned)
        {
            CreateRoom();
        }
    }

    void CreateRoom()
    {
        //Create a new room
        roomCount += 1;
        roomOffsetX = nextRoomMarker.transform.position.x;
        float entranceX = entrance.transform.position.x;
        entranceX += roomWidth;
        
        GameObject newRoom = Instantiate(dungeonPrefab, new Vector3(roomOffsetX, 0, 0), Quaternion.identity);
        rooms.Add(newRoom);
        Vector3 newEntrancePos = new Vector3(entranceX, 0, 0);
        entrance.transform.position = newEntrancePos;

    }
}
