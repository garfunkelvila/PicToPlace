using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class finishedDialogScript : MonoBehaviour {
    public Text Message;
    // Use this for initialization
    void Start () {
        string Level = PlayerPrefs.GetString("Level");
        if (Level == "Luzon") {
            Message.text="Finished! Luzon Completed";
        }
        else if (Level == "Visayas") {
            Message.text = "Finished! Visayas Completed";
        }
        else if (Level == "Mindanao") {
            Message.text = "Finished! Mindanao Completed";
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void btnReturn() {
        SceneManager.LoadScene("Start Scene");
    }
}
