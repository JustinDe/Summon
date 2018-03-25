using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class IshaoriInteraction : MonoBehaviour {
    private bool lookedAt = false;
    public Text subtitles;
	// Use this for initialization
	void Start () {
        SetGazedAt(false); // Neeeded for Google VR gaze command
        lookedAt = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetGazedAt(bool gazedAt) {
        Debug.Log("Looked at " + gameObject.name);
        lookedAt = true;
    }

    public void UnsetGazedAt(bool gazedAt) {
        Debug.Log("Looked away from " + gameObject.name);
        lookedAt = false;
    }

    public void SubtitleSend() {
        subtitles.text = "Oh yeah hey dog. Hey what's up?";
    }

    public void SubtitleExit() {
        subtitles.text = "";
    }
}
