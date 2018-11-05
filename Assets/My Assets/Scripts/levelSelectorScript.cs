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
/// It only handles the lock
/// </summary>
public class levelSelectorScript : MonoBehaviour {
    public Button Visayas;
    public GameObject vPadLock;
    public Button Mindanao;
    public GameObject mPadLock;
    // Use this for initialization
    void Start () {
	    // unlock stage and destroy lock
        if (PlayerPrefs.GetInt("Visayas") == 1) {
            Visayas.interactable = true;
            Destroy(vPadLock);
        }

        if (PlayerPrefs.GetInt("Mindanao") == 1) {
            Mindanao.interactable = true;
            Destroy(mPadLock);
        }
	}
}
