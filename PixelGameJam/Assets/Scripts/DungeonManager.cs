using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    //Declare Variables
    int tempR;
    bool raiding = false;
    bool moving;
    bool facingTrap = false;

    // Prefabs and Refrences
    public GameObject dungeonPrefab;
    public GameObject GameManager;
    public Camera dungeonCam;
    public GameObject hoardPrefab;
    public GameObject playerRoomPrefab;
    public GameObject nextRoomMarker;
    public GameObject entrance;
    public GameObject roomLock;
    public GameObject TrapManager;
    public GameObject initialTrapRoom;
    public GameObject roomToTrap;
    public GameObject[] spawns = new GameObject[4];
    GameObject activeAdventurer;


    //Variables for room generation
    public int roomCount;
    public int roomsOwned;
    public float roomWidth;
    float roomHeight;
    float roomCentre;
    float roomOffsetX;
    public Vector3 entrancePos = new Vector3(0.053f, 0, 0);
    int lockToBreak;
    bool isLocked;
    bool firstTrap = true;
    int adventurersAlive = 0;

    //Variables for camera
    public float cameraClampLeft;

    //trap variables
    bool hasTrap;
    public int optionSelected;

    //adventurer variables
    int adventurerStr;
    int adventurerAgl;
    int adventurerInt;
    int adventurerGreed;
    int adventurerHp;

    //Lists
    List<GameObject> rooms = new List<GameObject>();
    List<bool> isLockedList = new List<bool>();
    List<GameObject> roomLocks = new List<GameObject>();
    List<bool> hasTrapList = new List<bool>();
    bool[] spawnFilled = new bool[4];
    public List<int> trapInt = new List<int>();
    public List<int> trapStr = new List<int>();
    public List<int> trapAgl = new List<int>();

    //spawn variables
    public int spawnToUse = 0;

    //Variables for locked rooms
    int unlockCost;

    //mask layer for deciding whats interactable
    public LayerMask raycastLayerMask;

    bool aglPriority = false;
    bool strPriority = false;
    bool intPriority = false;
    
    //roll with, 1 is agl, 2 is str, 3 is int
    int rollWith;
    int difficultyCheck = 0;
    int raidIndex;


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
        spawnFilled[0] = false;
        spawnFilled[1] = false;
        spawnFilled[2] = false;
        spawnFilled[3] = false;

        //set hoard, player and entrance to be not locked, new rooms start at 3
        isLockedList.Add(false);
        isLockedList.Add(false);
        isLockedList.Add(false);

        rooms.Add(playerRoomPrefab);
        rooms.Add(hoardPrefab);
        rooms.Add(entrance);

        //set existing rooms to trapped or not
        hasTrapList.Add(false);
        hasTrapList.Add(false);
        hasTrapList.Add(false);

        trapInt.Add(0);
        trapInt.Add(0);
        trapInt.Add(0);
        trapStr.Add(0);
        trapStr.Add(0);
        trapStr.Add(0);
        trapAgl.Add(0);
        trapAgl.Add(0);
        trapAgl.Add(0);

        //roomToTrap = initialTrapRoom;
        CreateRoom();

        /* for (int i=0; i < 8; i++)
         {
             roomToTrap.transform.GetChild(i).gameObject.SetActive(false);
         }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameObject.GetComponent<GameManager>().gameState == 1)
        {


            if (roomCount <= roomsOwned)
            {
                CreateRoom();
            }
            MouseHandler();
        }
        if (GameManager.gameObject.GetComponent<GameManager>().gameState == 3)
        {
            raiding = true;
            Raid();
        }



    }

    void CreateRoom()
    {
        //Create a new room
        roomCount += 1;
        entrancePos.x -= 3.28f;
        entrance.transform.position = entrancePos;
        roomOffsetX = nextRoomMarker.transform.position.x;
        GameObject newRoom = Instantiate(dungeonPrefab, new Vector3(roomOffsetX, 0, 0), Quaternion.identity);
        rooms.Add(newRoom);
        isLockedList.Add(true);
        if (newRoom.tag == "isLocked")
        {
            isLocked = true;
            unlockCost = 1;

        }
        //create lock on new room, locks start at 0
        GameObject newLock = Instantiate(roomLock, new Vector3(roomOffsetX, -0.5f, -1), Quaternion.identity);
        // newLock.transform.parent = newRoom.transform;
        roomLocks.Add(newLock);
        for (int i = 0; i < 8; i++)
        {
            newRoom.transform.GetChild(i).gameObject.SetActive(false);
        }

    }


    //Handle Dungeon Interactions with mouse
    void MouseHandler()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Make a ray to mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //see if ray hit something on the mask layer
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, raycastLayerMask);
            if (hit)
            {
                Debug.Log("You clicked " + hit.collider.tag);
                if (hit.collider.tag == "isLocked")
                {
                    if(GameManager.GetComponent<GameManager>().gold > unlockCost)
                    {
                        GameManager.GetComponent<GameManager>().gold -= unlockCost;
                        Debug.Log("Unlocking room");
                        unlockCost += 5;
                        hit.collider.tag = "isUnlocked";
                        //hit.collider.gameObject.SetActive(false);
                        roomLocks[lockToBreak].gameObject.SetActive(false);
                        lockToBreak += 1;
                        roomsOwned += 1;
                        
                    }
                    else
                    {
                        Debug.Log("Not enough gold to unlock room");
                    }
                    

                }
                if (hit.collider.tag == "hoard")
                {
                    //open hoard
                }
                if (hit.collider.tag == "playerRoom")
                {
                    //open player room
                }
                if (hit.collider.tag == "isUnlocked")
                {



                    roomToTrap = rooms[roomCount - 1];


                    TrapManager.GetComponent<TrapManager>().TrapChooser();
                    hit.collider.tag = "hasTrap";
                    hit.collider.enabled = false;

                  //  Debug.Log("Trap Stats: " + trapAgl[roomCount] + " " + trapStr[roomCount] + " " + trapInt[roomCount]);
                    // roomToTrap.tag = "hasTrap";


                }
                else
                {
                    Debug.Log("room type exception");
                }
            }

        }
    }

    public void SpawnHandler()
    {
        if (!spawnFilled[0])
        {
            spawnFilled[0] = true;
            spawnToUse = 0;
        }
        else if (!spawnFilled[1])
        {
            spawnFilled[1] = true;
            spawnToUse = 1;
        }
        else if (!spawnFilled[2])
        {
            spawnFilled[2] = true;
            spawnToUse = 2;
        }
        else if (!spawnFilled[3])
        {
            spawnFilled[3] = true;
            spawnToUse = 3;
        }
        else
        {
            Debug.Log("No more spawns available");
        }
    }
    public void ResetSpawns()
    {
        for (int i = 0; i < spawnFilled.Length; i++)
        {
            spawnFilled[i] = false;
        }
    }

    public void Raid()
    {
        moving = true;
        raidIndex = roomCount - 1;
        SetAdventurer();
        StartCoroutine(RaidCoroutine());
        if (adventurersAlive == 0)
        {
            Debug.Log("No adventurers alive");
            GameManager.GetComponent<GameManager>().gameState = 1;
        }
        else
        {
            Debug.Log("Adventurers alive: " + adventurersAlive);
        }
    }

    IEnumerator RaidCoroutine()
    {
        for (int i = roomCount - 1; i > 1; i-- )
        {
            while (moving)
            {
                MoveAdventurer();

                yield return null;
            }
            while (facingTrap)
            {
                FaceTrap();
                yield return null;
            }
            raidIndex -= 1;
            Debug.Log("Raid Index: " + raidIndex);
        }
        yield return new WaitForSeconds(3f);
    }

    public void MoveAdventurer()
    {

        //move to next room
        GameObject activeAdventurer = GameObject.FindGameObjectWithTag("Adventurer");
        Debug.Log("Active Adventurer: " + activeAdventurer);
        //Debug.Log("Moving to next room: " + rooms[raidIndex - 1].transform.GetChild(8).transform.position);
        Vector3 nextPos = new Vector3(rooms[raidIndex].transform.GetChild(8).transform.position.x, activeAdventurer.transform.position.y, 0);
        activeAdventurer.transform.position = Vector3.MoveTowards(activeAdventurer.transform.position, nextPos, 1f * Time.deltaTime);
        Debug.Log("Moving to next room");
        if (activeAdventurer.transform.position.x == nextPos.x || activeAdventurer.transform.position.x > -1.38)
        {
            moving = false;
        }
        else { }
        if (rooms[raidIndex].tag == "hasTrap")
        {
            Debug.Log("trap detected in room " + rooms[raidIndex]);
            facingTrap = true;
        }
        else
        {
            raidIndex -= 1;
            if (raidIndex <= 1 && activeAdventurer.transform.position.x > -1.38f && !moving)
            {
                Debug.Log("Raid complete, player loses");
                GameManager.GetComponent<GameManager>().gameState = 1;
                GameManager.GetComponent<GameManager>().souls--;
                GameManager.GetComponent<GameManager>().gold -= adventurerGreed;
                Destroy(activeAdventurer);
            }
            else
            {
                Debug.Log("No trap detected in room " + rooms[raidIndex]);
                facingTrap = false;
            }
        }
    }

    public void FaceTrap()
    {
        Debug.Log("Facing Trap");
        Debug.Log("Adv Stats : " + adventurerAgl + " " + adventurerStr + " " + adventurerInt);
        Debug.Log("Trap Stats: " + trapAgl[raidIndex - 1] + " " + trapStr[raidIndex - 1] + " " + trapInt[raidIndex - 1]);
        //compare stats
        if (adventurerAgl > trapAgl[raidIndex])
        {
            aglPriority = true;
        }
        if (adventurerStr > trapStr[raidIndex])
        {
            strPriority = true;
        }
        if (adventurerInt > trapInt[raidIndex])
        {
            intPriority = true;
        }
        Debug.Log("Agl Priority: " + aglPriority + " Str Priority: " + strPriority + " Int Priority: " + intPriority);
        // see which is best to roll with
        if (aglPriority && strPriority && intPriority)
        {
            if (adventurerAgl > adventurerStr && adventurerAgl > adventurerInt)
            {
                rollWith = 1;
            }
            else if (adventurerStr > adventurerAgl && adventurerStr > adventurerInt)
            {
                rollWith = 2;
            }
            else
            {
                rollWith = 3;
            }
        }
        else if (aglPriority && strPriority)
        {
            if (adventurerAgl > adventurerStr)
            {
                rollWith = 1;
            }
            else
            {
                rollWith = 2;
            }
        }
        else if (aglPriority && intPriority)
        {
            if (adventurerAgl > adventurerInt)
            {
                rollWith = 1;
            }
            else
            {
                rollWith = 3;
            }
        }
        else if (strPriority && intPriority)
        {
            if (adventurerStr > adventurerInt)
            {
                rollWith = 2;
            }
            else
            {
                rollWith = 3;
            }
        }
        else if (aglPriority)
        {
            rollWith = 1;
        }
        else if (strPriority)
        {
            rollWith = 2;
        }
        else if (intPriority)
        {
            rollWith = 3;
        }
        else
        {
            Debug.Log("No priority");
            rollWith = Random.Range(1, 4);
        }
        Debug.Log("Roll with: " + rollWith);
        //check goal to beat
        if (rollWith == 1)
        {
            if (adventurerAgl > trapAgl[raidIndex])
            {
                difficultyCheck = 5;
            }
            if (adventurerAgl == trapAgl[raidIndex])
            {
                difficultyCheck = 10;
            }
            if (adventurerAgl < trapAgl[raidIndex])
            {
                difficultyCheck = 15;
            }
            Debug.Log("Agl Check: " + difficultyCheck);
        }
        else if (rollWith == 2)
        {
            if (adventurerStr > trapStr[raidIndex])
            {
                difficultyCheck = 5;
            }
            if (adventurerStr == trapStr[raidIndex])
            {
                difficultyCheck = 10;
            }
            if (adventurerStr < trapStr[raidIndex])
            {
                difficultyCheck = 15;
            }
            Debug.Log("Str Check: " + difficultyCheck);
        }
        else if (rollWith == 3)
        {
            if (adventurerInt > trapInt[raidIndex])
            {
                difficultyCheck = 5;
            }
            if (adventurerInt == trapInt[raidIndex])
            {
                difficultyCheck = 10;
            }
            if (adventurerInt < trapInt[raidIndex])
            {
                difficultyCheck = 15;
            }
        }
        //roll dice
        while (facingTrap)
        {
            int roll = Random.Range(1, 21);
            Debug.Log("Roll: " + roll);
            if (roll >= difficultyCheck)
            {
                facingTrap = false;
                Debug.Log("Success");
                facingTrap = false;
                moving = true;
            }
            else
            {
                Debug.Log("Failure");
                adventurerHp -= 1;

                //kill adventurer
                GameObject activeAdventurer = GameObject.FindGameObjectWithTag("Adventurer");
                DestroyImmediate(activeAdventurer);
                Debug.Log("Adventurer is dead");
                GameManager.GetComponent<GameManager>().souls++;
                facingTrap = false;
                raiding = false;

            }
        }


    }

    /* public void Raid()
     {
         for (int i = 0; i < 4; i++)
         {
             GameObject activeAdventurer = GameObject.FindGameObjectWithTag("Adventurer");
             if (activeAdventurer == null)
             {
                 //end raid phase
                 GameManager.GetComponent<GameManager>().gameState = 1;
             }
             else
             {
                 //set stats
                 int tempRoomCount = roomCount;
                 adventurerAgl = activeAdventurer.GetComponent<adventurer>().agil;
                 adventurerStr = activeAdventurer.GetComponent<adventurer>().strg;
                 adventurerInt = activeAdventurer.GetComponent<adventurer>().intl;
                 adventurerHp = activeAdventurer.GetComponent<adventurer>().hp;
                 adventurerGreed = activeAdventurer.GetComponent<adventurer>().greed;


                 //rooms before player
                 for (int r = roomCount - 1; r > 2; r--)
                 {
                     Debug.Log("Room: " + r + " Room Count:" + roomCount);
                     Debug.Log("trapAgl: " + trapAgl[r - 1] + " trapStr" + trapStr[r-1] + " trapInt" + trapInt[r-1]);
                     tempR = r;
                     if (adventurerHp <= 0)
                     {
                         Debug.Log("Adventurer is dead");
                         Destroy(activeAdventurer);
                         GameManager.GetComponent<GameManager>().souls++;
                         break;
                     }
                     activeAdventurer.transform.position = Vector2.MoveTowards(activeAdventurer.transform.position, rooms[r].transform.GetChild(8).transform.position, 5f);
                     facingTrap = true;
                     //check if room has trap
                     if (rooms[r- 1].tag == "hasTrap")
                     {
                         Debug.Log("Facing Trap");
                         Debug.Log("Adv Stats : " + adventurerAgl + " " + adventurerStr + " " + adventurerInt);
                         //compare stats
                         if (adventurerAgl > trapAgl[r -1])
                         {
                             aglPriority = true;
                         }
                         if (adventurerStr > trapStr[r - 1])
                         {
                             strPriority = true;
                         }
                         if (adventurerInt > trapInt[r - 1])
                         {
                             intPriority = true;
                         }
                         // see which is best to roll with
                         if (aglPriority && strPriority && intPriority)
                         {
                             if (adventurerAgl > adventurerStr && adventurerAgl > adventurerInt)
                             {
                                 rollWith = 1;
                             }
                             else if (adventurerStr > adventurerAgl && adventurerStr > adventurerInt)
                             {
                                 rollWith = 2;
                             }
                             else
                             {
                                 rollWith = 3;
                             }
                         }
                         else if (aglPriority && strPriority)
                         {
                             if (adventurerAgl > adventurerStr)
                             {
                                 rollWith = 1;
                             }
                             else
                             {
                                 rollWith = 2;
                             }
                         }
                         else if (aglPriority && intPriority)
                         {
                             if (adventurerAgl > adventurerInt)
                             {
                                 rollWith = 1;
                             }
                             else
                             {
                                 rollWith = 3;
                             }
                         }
                         else if (strPriority && intPriority)
                         {
                             if (adventurerStr > adventurerInt)
                             {
                                 rollWith = 2;
                             }
                             else
                             {
                                 rollWith = 3;
                             }
                         }
                         else if (aglPriority)
                         {
                             rollWith = 1;
                         }
                         else if (strPriority)
                         {
                             rollWith = 2;
                         }
                         else if (intPriority)
                         {
                             rollWith = 3;
                         }
                         else
                         {
                             Debug.Log("No priority");
                             rollWith = Random.Range(1, 4);
                         }
                         //check goal to beat
                         if (rollWith == 1)
                         {
                             if (adventurerAgl > trapAgl[r - 1])
                             {
                                 difficultyCheck = 5;
                             }
                             if (adventurerAgl == trapAgl[r - 1])
                             {
                                 difficultyCheck = 10;
                             }
                             if (adventurerAgl < trapAgl[r - 1])
                             {
                                 difficultyCheck = 15;
                             }
                         }
                         if (rollWith == 2)
                         {
                             if (adventurerStr > trapStr[r - 1])
                             {
                                 difficultyCheck = 5;
                             }
                             if (adventurerStr == trapStr[r - 1])
                             {
                                 difficultyCheck = 10;
                             }
                             if (adventurerStr < trapStr[r - 1])
                             {
                                 difficultyCheck = 15;
                             }
                         }
                         if (rollWith == 3)
                         {
                             if (adventurerInt > trapInt[r - 1])
                             {
                                 difficultyCheck = 5;
                             }
                             if (adventurerInt == trapInt[r - 1])
                             {
                                 difficultyCheck = 10;
                             }
                             if (adventurerInt < trapInt[r - 1])
                             {
                                 difficultyCheck = 15;
                             }
                         }
                         //roll dice
                         while (facingTrap)
                         {
                             int roll = Random.Range(1, 21);
                             Debug.Log("Roll: " + roll);
                             if (roll >= difficultyCheck)
                             {
                                 facingTrap = false;
                                 Debug.Log("Success");
                             }
                             else
                             {
                                 Debug.Log("Failure");
                                 adventurerHp -= 1;
                                 if (adventurerHp <= 0)
                                 {
                                     //kill adventurer
                                     Destroy(activeAdventurer);
                                     GameManager.GetComponent<GameManager>().souls++;
                                     break;
                                 }
                             }
                         }
                     }
                     else
                     {

                     }

                 }
                 //check if adventurer is dead
                 if (adventurerHp <= 0)
                 {
                     Debug.Log("Adventurer is dead");
                     Destroy(activeAdventurer);
                     GameManager.GetComponent<GameManager>().souls++;
                     GameManager.GetComponent<GameManager>().gold += adventurerGreed / 2;
                     break;
                 }
                 else
                 {
                     //move to next room
                     activeAdventurer.transform.position = Vector2.MoveTowards(activeAdventurer.transform.position, rooms[tempR].transform.GetChild(8).transform.position, 5f);
                     Debug.Log("Moving to next room");
                     GameManager.GetComponent<GameManager>().souls--;
                     GameManager.GetComponent<GameManager>().gold -= adventurerGreed;
                 }

             }
         }
         //End of Raid Phase
         GameManager.GetComponent<GameManager>().gameState = 1;
     }*/

    public void SetAdventurer()
    {
        Debug.Log("Setting Adventurer");
        GameObject activeAdventurer = GameObject.FindGameObjectWithTag("Adventurer");
        if (activeAdventurer == null)
        {
            //end raid phase
            GameManager.GetComponent<GameManager>().gameState = 1;
        }
        else
        {
            //set stats
            adventurerAgl = activeAdventurer.GetComponent<adventurer>().agil;
            adventurerStr = activeAdventurer.GetComponent<adventurer>().strg;
            adventurerInt = activeAdventurer.GetComponent<adventurer>().intl;
            adventurerHp = activeAdventurer.GetComponent<adventurer>().hp;
            adventurerGreed = activeAdventurer.GetComponent<adventurer>().greed;
            Debug.Log("Adventurer Stats: " + adventurerAgl + " " + adventurerStr + " " + adventurerInt);
        }
    }




    public void ResetRaid()
    {
        for (int i = 0; i < 4; i++)
        {
            spawnFilled[i] = false;
        }
        facingTrap = false;
        aglPriority = false;
        strPriority = false;
        intPriority = false;
        rollWith = 0;
        difficultyCheck = 0;
    }
}



