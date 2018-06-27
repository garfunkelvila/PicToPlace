using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// TODO for this to work .. change rect to rectTransform..
/// I flipped it -___-
/// </summary>
public class keyboradModeSwitcher : MonoBehaviour {
    public GameObject Container;
    // Use this for initialization
    bool isAligned;
    public enum Mode {
        Wide,   // 35x40
        Narrow, // 30x40
    }
	void Start () {
        isAligned = false;
	}
	
	// Update is called once per frame
    void Update() {
        if (isAligned == false) {
            Rect a = Container.GetComponent<Rect>();
            Rect b = gameObject.GetComponent<Rect>();


            if (a.width > b.width){
                changeMode(Mode.Narrow);
            }
            
        }
        isAligned = true;
    }

    void changeMode(Mode mode) {
        GameObject[] allKeys;
        allKeys = GameObject.FindGameObjectsWithTag("Key");

        switch (mode) {
            case Mode.Narrow:
                foreach (var key in allKeys) {
                    key.GetComponent<LayoutElement>().preferredWidth = 30;
                }
                break;
            default:
                break;
        }
    }
}
