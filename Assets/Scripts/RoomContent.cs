using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomContent : MonoBehaviour {

    public GameObject DebugObjectPrefab;
    public bool debugSpaws = true;
    private int gridRoomX = 5;
    private int gridRoomZ = 5;
    private float roomSpacing = 10f;
    private float spawnSpacing = 6f;
    private float offset = 1f;

    // Use this for initialization
    void Start()
    {
        if (debugSpaws == true)
        {
            int count = 0;
            for (int z = 0; z < gridRoomZ; z++)
            {
                for (int x = 0; x < gridRoomX; x++)
                {
                    Vector3 pos1 = new Vector3(((x * roomSpacing) + offset), 1.5f, (z * roomSpacing));
                    Vector3 pos2 = new Vector3(((x * roomSpacing) + offset), 1.5f, (z * roomSpacing) + spawnSpacing);
                    Vector3 pos3 = new Vector3(((x * roomSpacing) + offset + spawnSpacing), 1.5f, (z * roomSpacing) + spawnSpacing);
                    Vector3 pos4 = new Vector3(((x * roomSpacing) + offset + spawnSpacing), 1.5f, (z * roomSpacing));
                    Vector3 pos5 = new Vector3(((x * roomSpacing) + offset + (spawnSpacing / 2)), 1.5f, (z * roomSpacing) + (spawnSpacing / 2));
                    GameObject spawn1 = Instantiate(DebugObjectPrefab, pos1, Quaternion.identity);
                    GameObject spawn2 = Instantiate(DebugObjectPrefab, pos2, Quaternion.identity);
                    GameObject spawn3 = Instantiate(DebugObjectPrefab, pos3, Quaternion.identity);
                    GameObject spawn4 = Instantiate(DebugObjectPrefab, pos4, Quaternion.identity);
                    GameObject spawn5 = Instantiate(DebugObjectPrefab, pos5, Quaternion.identity);
                    spawn1.name = string.Format("spawn:1:room:{0}", count);
                    spawn2.name = string.Format("spawn:2:room:{0}", count);
                    spawn3.name = string.Format("spawn:3:room:{0}", count);
                    spawn4.name = string.Format("spawn:4:room:{0}", count);
                    spawn5.name = string.Format("spawn:5:room:{0}", count);
                    count++;
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
