using UnityEngine;
using System.Collections;

public class menuUIScript : MonoBehaviour {
    public GameObject StartUI;
    public GameObject LevelUI;

    void Awake() {
        gameObject.GetComponent<backHandler>().backHistory.Push(StartUI);
        PreservedVars vars = GameObject.Find("Main Camera").GetComponent<PreservedVars>();// because main camera holds the script XD
        if (vars.showPlay == false) {
            gameObject.GetComponent<backHandler>().btnForward(LevelUI);
        }
    }
}
