using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class sfxVolumeButtonScript : MonoBehaviour {
    Toggle toggle;
    AudioSource sfx;
    void Awake() {
        sfx = GameObject.Find("Correct and Wrong").GetComponent<AudioSource>();
        toggle = gameObject.GetComponent<Toggle>();

        toggle.isOn = PlayerPrefs.GetInt("SFX")==0 ? true : false;
        toggle.onValueChanged.AddListener(btnSFX);
    }
    public void btnSFX(bool value) {
        if (value == false) {
            sfx.mute = true;
            PlayerPrefs.SetInt("SFX", 1);
        }
        else {
            PlayerPrefs.SetInt("SFX", 0);
            sfx.mute = false;
        }
        PlayerPrefs.Save();
    }
}
