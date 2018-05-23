using UnityEngine;
using System.Collections;

public class hintScript : MonoBehaviour {
    public GameObject hintDialogPrefab;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void btnHint() {
        // TODO: make a condition to check for coin and show the not enough coins dialog

        GameObject temp; // this dialog is modal so im sure it will not be instantiated again using the same button
        temp = Instantiate(hintDialogPrefab);
        temp.transform.SetParent(GameObject.Find("Canvas").transform);
        temp.transform.localPosition = Vector3.zero;
        temp.transform.localScale = Vector3.one;
        temp.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
    }
}
