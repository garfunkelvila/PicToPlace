using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class finishedScreenScript : MonoBehaviour {
    public Text Message;
	// Use this for initialization
	void Start () {
        Message.text = "Congratulation!! You finished " + PlayerPrefs.GetString("Level");
    }
    public void btnReturn() {
        SceneManager.LoadScene("Start Scene");
    }
}
