using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class resetDialogScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void btnYes() {
        PlayerPrefs.DeleteAll();
        GameObject.Find("Main Camera").GetComponent<PreservedVars>().showPlay = true;
        GameObject.Find("BGM").GetComponent<AudioSource>().mute = false;
        GameObject.Find("Correct and Wrong").GetComponent<AudioSource>().mute = false;
        Debug.LogWarning("Player Prefs cleared!!");
        //Destroy(gameObject);
        SceneManager.LoadScene("Start Scene");
    }
    public void btnNo() {
        Destroy(gameObject);
    }
}
