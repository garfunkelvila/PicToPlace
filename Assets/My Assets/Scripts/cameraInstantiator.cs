using UnityEngine;
using System.Collections;

/// <summary>
/// Cant remember where i used this -___-"
/// </summary>
public class cameraInstantiator : MonoBehaviour {
    public GameObject cameraPrefab;
	void Awake () {
        GameObject temp = GameObject.Find("Main Camera");
        if (temp == null) {
            Instantiate(cameraPrefab);
        }
	}
}
