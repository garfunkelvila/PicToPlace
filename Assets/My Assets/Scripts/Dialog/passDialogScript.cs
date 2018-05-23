using UnityEngine;
using System.Collections;

public class passDialogScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void btnOk() {
        Destroy(gameObject);
    }
    public void btnCancel() {
        Destroy(gameObject);
    }
}
