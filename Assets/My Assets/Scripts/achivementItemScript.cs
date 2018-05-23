using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// This one changes the color of the star from dark or something into normal if prefs returned 1
/// </summary>
public class achivementItemScript : MonoBehaviour {
    public Image Star;
    public Text Message;
    public string PlayerPrefsName;

	void Start () {
        if (PlayerPrefsName == "") {
            Debug.LogWarning("Player Prefs Name not set");
        }
        else {
            if (PlayerPrefs.GetInt(PlayerPrefsName) == 0) {
                Star.color = new Color(1,1,1,0.25f);
            }
            else {
                Star.color = new Color(1, 1, 1, 1);
            }
        }
	}
}
