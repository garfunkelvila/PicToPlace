using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// Attach this to blanks that carry the text component
/// </summary>

// [RequireComponent(typeof(Text))] // removed for a while, but this line enforces unity to put Text Component with this script
public class blankScript : MonoBehaviour {
    public char assignedLetter;
    public bool isAnswered = false;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// call this to show assigned value, before calling it compare it first using assignedLetter;)
    /// </summary>
    public void showValue() {
        this.GetComponentInChildren<Text>().text = assignedLetter.ToString();
        isAnswered = true;
    }
}
