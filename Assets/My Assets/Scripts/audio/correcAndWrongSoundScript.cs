using UnityEngine;
using System.Collections;

public class correcAndWrongSoundScript : MonoBehaviour {
    public AudioClip Correct;
    public AudioClip Wrong;
	void Start () {
        if (PlayerPrefs.GetInt("SFX") == 1) {
            GetComponent<AudioSource>().mute = true;
            // image is modified on script attached to the button
        }
    }
    public void playSound(bool isCorrect) {
        if (isCorrect == true) {
            gameObject.GetComponent<AudioSource>().clip = Correct;
            
        }
        else{
            gameObject.GetComponent<AudioSource>().clip = Wrong;
        }
        gameObject.GetComponent<AudioSource>().Play();
    }
}
