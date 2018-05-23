using UnityEngine;
using System.Collections;

/// <summary>
/// Ensures only one camera is on the scene because of the dont destroy code
/// </summary>
public class dontDestroy : MonoBehaviour {
    private static dontDestroy _instance;
    // Use this for initialization
    void Awake() {
        //if we don't have an [_instance] set yet
        if (!_instance)
            _instance = this;
        //otherwise, if we do, kill this thing
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
}