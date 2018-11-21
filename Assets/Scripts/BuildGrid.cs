using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildGrid : MonoBehaviour {

    public GameObject RoomPrefab;
    public GameObject DoorPrefab;
    public bool setDoors;
    private int gridRoomX = 5;
    private int gridRoomY = 5;
    private float roomSpacing = 10f;
    private float doorOffset = 3f;

    void Start()
    {
        //Spawn the rooms
        int count = 0;
        for (int y = 0; y < gridRoomY; y++)
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
            for (int y = 0; y < gridRoomY; y++)
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
            for (int y = 0; y < gridRoomY + 1; y++)
            {
                for (int x = 0; x < gridRoomX; x++)
                {
                    Vector3 posEW = new Vector3((x * roomSpacing) + 1f + doorOffset, 1, (y * roomSpacing) - 1.5f);
                    GameObject doorEW = Instantiate(DoorPrefab, posEW, Quaternion.Euler(0, 90, 0));
                    doorEW.name = string.Format("door:ew:{0}:{1}", x, y);
                    doorEW.tag = "DoorI";
                    if (y == 0 || y == gridRoomY)
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
    }
}
