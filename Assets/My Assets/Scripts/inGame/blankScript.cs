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
/// Attach this to blanks that carry the text component
/// </summary>

// [RequireComponent(typeof(Text))] // removed for a while, but this line enforces unity to put Text Component with this script
public class blankScript : MonoBehaviour {
    public char assignedLetter;
    public bool isAnswered = false;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// call this to show assigned value, before calling it compare it first using assignedLetter;)
    /// </summary>
    public void showValue() {
        this.GetComponentInChildren<Text>().text = assignedLetter.ToString();
        isAnswered = true;
    }
}
