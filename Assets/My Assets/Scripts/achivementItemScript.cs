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
/// This one changes the color of the star from dark or something into normal if prefs returned 1
/// </summary>
public class achivementItemScript : MonoBehaviour {
    public Image Star;
    public Text Message;
    public string PlayerPrefsName;

	void Start () {
        if (PlayerPrefsName == "") {
            Debug.LogWarning("Player Prefs Name not set");
        }
        else {
            if (PlayerPrefs.GetInt(PlayerPrefsName) == 0) {
                Star.color = new Color(1,1,1,0.25f);
            }
            else {
                Star.color = new Color(1, 1, 1, 1);
            }
        }
	}
}
