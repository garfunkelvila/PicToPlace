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
/// I think this class i obsolete
/// 
/// Attach this to keys, aaand i thingk this class suld named blankkeyscript
/// </summary>
public class blankButtonScript : MonoBehaviour {
    public currentStatus status;

    public char Letter;

	// Use this for initialization
	void Start () {
        status = GameObject.Find("logicHandler").GetComponent<currentStatus>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update () {
	
	}

    /// <summary>
    /// Call this on button pressed
    /// </summary>
    public void btnPressed() {
        if (Letter.Equals(status.CurrentKey)) {
            gameObject.GetComponentInChildren<Text>().text = Letter.ToString();
        }
        else {
            //status.CurrentMistakesCount++;
            // reason why well not using this is because we want to status to do this and the instanitate
            //status.inCrementMistake();
            status.decrementLives();
        }
    }

    public void reEnableKeys() {
        GameObject[] keys;
        keys = GameObject.FindGameObjectsWithTag("Key");
        //keys = GetComponentInChildren<Button>().interactable = true;
        foreach (var key in keys) {
            key.GetComponent<Button>().interactable = true;
        }
    }
}
