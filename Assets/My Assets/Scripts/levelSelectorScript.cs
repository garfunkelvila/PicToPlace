using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// It only handles the lock
/// </summary>
public class levelSelectorScript : MonoBehaviour {
    public Button Visayas;
    public GameObject vPadLock;
    public Button Mindanao;
    public GameObject mPadLock;
    // Use this for initialization
    void Start () {
	    // unlock stage and destroy lock
        if (PlayerPrefs.GetInt("Visayas") == 1) {
            Visayas.interactable = true;
            Destroy(vPadLock);
        }

        if (PlayerPrefs.GetInt("Mindanao") == 1) {
            Mindanao.interactable = true;
            Destroy(mPadLock);
        }
	}
}
