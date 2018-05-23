using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class clearPlayerPrefsScript : MonoBehaviour {
    public void clearPrefs() {
        PlayerPrefs.DeleteAll();
        Debug.LogWarning("Player Prefs cleared!!");
    }
}
