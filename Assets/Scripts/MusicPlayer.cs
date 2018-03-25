using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class MusicPlayer : MonoBehaviour {

    private bool lookedAt = false;
    public bool musicPlay = false;
    private GameObject bgmSource;

    // Use this for initialization
    void Start() {
        SetGazedAt(false); // Neeeded for Google VR gaze command
        lookedAt = false;
        bgmSource = GameObject.FindWithTag("Music");
    }

    // Update is called once per frame
    void Update() {
        if (lookedAt) {
            // Top Trigger on Utopia 360 Controller on PC = 7 Android = 5 (Interact)
            if (Input.GetKeyDown(KeyCode.JoystickButton7) == true || Input.GetKeyDown(KeyCode.JoystickButton5) == true || Input.GetMouseButtonDown(0)) {
                Debug.Log("Played music using the " + gameObject.name);
                toggleMusic();
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

    public void toggleMusic() {
        musicPlay = !musicPlay;
        bgmSource.GetComponent<AudioSource>().enabled = musicPlay;
    }

}
