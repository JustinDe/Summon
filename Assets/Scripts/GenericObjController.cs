using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(Collider))]
public class GenericObjController : MonoBehaviour {
    GameObject mainCamera;
    GameObject carriedObject;
    private bool lookedAt = false;
    public  bool carrying;
    public float distance = 1f;
    public float smooth = 4f;
    
    void Start() {
        SetGazedAt(false); // Neeeded for Google VR gaze command
        lookedAt = false;
        mainCamera = GameObject.FindWithTag("MainCamera");
    }

    void Update() {
        if (carrying == true) {
            carry();
            checkDrop();
        }
        else {
            if (lookedAt == true) {
                if (Input.GetKeyDown(KeyCode.JoystickButton6) == true || Input.GetKeyDown(KeyCode.JoystickButton4) == true || Input.GetMouseButtonDown(1) == true) {
                    if (gameObject.tag == "Pickupable") {
                        carrying = true;
                        carriedObject = gameObject;
                        //carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    }
                }
            }
        }
    }

    public void SetGazedAt(bool gazedAt) {
        Debug.Log("Looked at " + gameObject.name);
        lookedAt = true;
    }

    public void UnsetGazedAt(bool gazedAt) {
        Debug.Log("Looked away from " + gameObject.name);
        lookedAt = false;
    }

    public bool lookCheck() {
        return lookedAt;
    }

    private void carry() {
        Debug.Log(mainCamera.name);
        carriedObject.transform.position = Vector3.Lerp(carriedObject.transform.position, Camera.main.transform.position + Camera.main.transform.forward * distance, Time.deltaTime * smooth);
        carriedObject.transform.rotation = Quaternion.identity;
    }

    private void checkDrop() {
        if (Input.GetKeyUp(KeyCode.JoystickButton6) == true || Input.GetKeyUp(KeyCode.JoystickButton4) == true || Input.GetMouseButtonUp(1) == true) {
            dropObject();
        }
    }

    private void dropObject() {
        carrying = false;
        //carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
        carriedObject = null;
    }
}
  
