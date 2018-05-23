using UnityEngine;
using System.Collections;

public class DialogInstantiator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void InstantiateDialog(GameObject dialog) {
        GameObject temp;

        temp = Instantiate(dialog);
        temp.transform.SetParent(GameObject.Find("Canvas").transform);
        temp.transform.localPosition = Vector3.zero;
        temp.transform.localScale = Vector3.one;
        temp.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        //Destroy(gameObject);
    }
}
