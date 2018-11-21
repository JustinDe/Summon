using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorInteractions : MonoBehaviour {
    public GenericObjController goc;
    private bool doorOpen = false;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Top Trigger on Utopia 360 Controller on PC = 7 Android = 5 (Interact)
        if (Input.GetKeyDown(KeyCode.JoystickButton7) == true || Input.GetKeyDown(KeyCode.JoystickButton5) == true || Input.GetMouseButtonDown(0))
        {
            if (goc.lookCheck() == true && gameObject.tag == "DoorI")
            {
                Debug.Log("Interacted with " + gameObject.name);
                if (doorOpen == false)
                {
                    Vector3 openPos = new Vector3(0, 3.0f, 0);
                    gameObject.transform.position += openPos;
                    doorOpen = true;
                }
                else
                {
                    Vector3 openPos = new Vector3(0, -3.0f, 0);
                    gameObject.transform.position += openPos;
                    doorOpen = false;
                }

            }
        }

    }
}
