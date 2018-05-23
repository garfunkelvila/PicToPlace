using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// I think this class i obsolete
/// 
/// Attach this to keys, aaand i thingk this class suld named blankkeyscript
/// </summary>
public class blankButtonScript : MonoBehaviour {
    public currentStatus status;

    public char Letter;

	// Use this for initialization
	void Start () {
        status = GameObject.Find("logicHandler").GetComponent<currentStatus>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update () {
	
	}

    /// <summary>
    /// Call this on button pressed
    /// </summary>
    public void btnPressed() {
        if (Letter.Equals(status.CurrentKey)) {
            gameObject.GetComponentInChildren<Text>().text = Letter.ToString();
        }
        else {
            //status.CurrentMistakesCount++;
            // reason why well not using this is because we want to status to do this and the instanitate
            //status.inCrementMistake();
            status.decrementLives();
        }
    }

    public void reEnableKeys() {
        GameObject[] keys;
        keys = GameObject.FindGameObjectsWithTag("Key");
        //keys = GetComponentInChildren<Button>().interactable = true;
        foreach (var key in keys) {
            key.GetComponent<Button>().interactable = true;
        }
    }
}
