using UnityEngine;
using System.Collections;

public class audioStartScript : MonoBehaviour {
    // the proper way is to change the mixers volume
    void Start () {
        if (PlayerPrefs.GetInt("BGM") == 1) {
            // the proper way is to change the mixers volume
            GetComponent<AudioSource>().mute = true;
        }
        else {
            GetComponent<AudioSource>().mute = false;
        }
    }
}
