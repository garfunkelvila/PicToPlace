//  Copyright (C) 2017  Garfunkel Vila
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  any later version.
//  
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
//  
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see<http://www.gnu.org/licenses/>.
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
