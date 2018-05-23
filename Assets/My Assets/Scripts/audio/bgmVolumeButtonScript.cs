using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class bgmVolumeButtonScript : MonoBehaviour {
    Toggle toggle;
    AudioSource bgm;
    void Awake() {
        bgm = GameObject.Find("BGM").GetComponent<AudioSource>();
        toggle = gameObject.GetComponent<Toggle>();

        toggle.isOn = PlayerPrefs.GetInt("BGM") == 0 ? true : false;
        toggle.onValueChanged.AddListener(btnBGM);
    }
    public void btnBGM(bool value) {
        if (value == false) {
            PlayerPrefs.SetInt("BGM", 1);
            bgm.mute = true;
        }
        else {
            PlayerPrefs.SetInt("BGM", 0);
            bgm.mute = false;
        }
        PlayerPrefs.Save();
    }
}
