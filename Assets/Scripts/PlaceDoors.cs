using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDoors : MonoBehaviour {

    public GameObject prefab;
    private int gridXns = 6;
    private int gridYns = 5;
    private int gridXew = 5;
    private int gridYew = 6;
    private float spacing = 10f;
    private float offset = 3f;

    void Start()
    {
        for (int y = 0; y < gridYns; y++)
        {
            for (int x = 0; x < gridXns; x++)
            {
                Vector3 posNS = new Vector3((x * spacing) - 1.5f, 1f, (y * spacing) + offset);
                GameObject doorNS = Instantiate(prefab, posNS, Quaternion.identity);
                doorNS.name = string.Format("door:ns:{0}:{1}", x, y);
                doorNS.tag = "DoorI";
                //TODO - Update this so outer doors except exit door has the tag "DoorN"
            }
        }

        for (int y = 0; y < gridYew; y++)
        {
            for (int x = 0; x < gridXew; x++)
            {
                Vector3 posEW = new Vector3((x * spacing) + 1f + offset, 1, (y * spacing) - 1.5f);
                GameObject doorEW = Instantiate(prefab, posEW, Quaternion.Euler(0, 90, 0));
                doorEW.name = string.Format("door:ew:{0}:{1}", x, y);
                doorEW.tag = "DoorI";
                //TODO - Update this so outer doors except exit door has the tag "DoorN"
            }
        }
    }
}
