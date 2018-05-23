using UnityEngine;
using System.Collections;

public class passScript : MonoBehaviour {
    public GameObject passDialogPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void btnPassClick() {
        GameObject temp; // this dialog is modal so im sure it will not be instantiated again using the same button
        temp = Instantiate(passDialogPrefab);
        temp.transform.SetParent(GameObject.Find("Canvas").transform);
        temp.transform.localPosition = Vector3.zero;
        temp.transform.localScale = Vector3.one;
        temp.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
    }
}
