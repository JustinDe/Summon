using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildGrid : MonoBehaviour {

    public GameObject RoomPrefab;
    public GameObject DoorPrefab;
    public GameObject DeadendHallPrefab;
    public bool setDoors = true;
    public bool setHalls = true;
    private int gridRoomX = 5;
    private int gridRoomZ = 5;
    private float roomSpacing = 10f;
    private float doorOffset = 3f;
    private float hallLengthHalf = 3f;

    void Start()
    {
        //Spawn the rooms
        int count = 0;
        for (int y = 0; y < gridRoomZ; y++)
        {
            for (int x = 0; x < gridRoomX; x++)
            {
                Vector3 pos = new Vector3(x, 0, y) * roomSpacing;
                GameObject room = Instantiate(RoomPrefab, pos, Quaternion.identity);
                room.name = string.Format("room:{0}", count);
                room.tag = "Room";
                count++;
            }
        }

        if (setDoors == true)
        {
            // Spawn the doors that go North-South
            for (int y = 0; y < gridRoomZ; y++)
            {
                for (int x = 0; x < gridRoomX + 1; x++)
                {
                    Vector3 posNS = new Vector3((x * roomSpacing) - 1.5f, 1f, (y * roomSpacing) + doorOffset);
                    GameObject doorNS = Instantiate(DoorPrefab, posNS, Quaternion.identity);
                    doorNS.name = string.Format("door:ns:{0}:{1}", x, y);
                    if (x == 0 || x == gridRoomX)
                    {
                        doorNS.tag = "DoorN";
                    }
                    else
                    {
                        doorNS.tag = "DoorI";
                    }
                }
            }

            //Spawn the doors that go East-West
            for (int y = 0; y < gridRoomZ + 1; y++)
            {
                for (int x = 0; x < gridRoomX; x++)
                {
                    Vector3 posEW = new Vector3((x * roomSpacing) + 1f + doorOffset, 1, (y * roomSpacing) - 1.5f);
                    GameObject doorEW = Instantiate(DoorPrefab, posEW, Quaternion.Euler(0, 90, 0));
                    doorEW.name = string.Format("door:ew:{0}:{1}", x, y);
                    doorEW.tag = "DoorI";
                    if (y == 0 || y == gridRoomZ)
                    {
                        doorEW.tag = "DoorN";
                    }
                    else
                    {
                        doorEW.tag = "DoorI";
                    }
                }
            }
        }
        if (setHalls == true)
        {
            //Spawn the hallways
            for (int i = 0; i < gridRoomX; i++)
            {
                Vector3 posN = new Vector3((i * roomSpacing) + doorOffset, 0, 1 - hallLengthHalf);
                Vector3 posS = new Vector3((i * roomSpacing) + doorOffset + 2, 0, (1 - hallLengthHalf) + (gridRoomX * roomSpacing));
                GameObject doorN = Instantiate(DeadendHallPrefab, posN, Quaternion.Euler(0, 0, 0));
                GameObject doorS = Instantiate(DeadendHallPrefab, posS, Quaternion.Euler(0, 180, 0));

            }
            for (int i = 0; i < gridRoomZ; i++)
            {
                Vector3 posE = new Vector3(2 - hallLengthHalf, 0, (i * roomSpacing) + (doorOffset + 1));
                Vector3 posW = new Vector3((2 - hallLengthHalf) + (gridRoomZ * roomSpacing), 0, (i * roomSpacing) + (doorOffset - 1));
                GameObject doorE = Instantiate(DeadendHallPrefab, posE, Quaternion.Euler(0, 90, 0));
                GameObject doorW = Instantiate(DeadendHallPrefab, posW, Quaternion.Euler(0, 270, 0));
            }
        }
    }
}
