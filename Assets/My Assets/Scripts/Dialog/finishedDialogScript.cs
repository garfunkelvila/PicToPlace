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
using UnityEngine.SceneManagement;

public class finishedDialogScript : MonoBehaviour {
    public Text Message;
    // Use this for initialization
    void Start () {
        string Level = PlayerPrefs.GetString("Level");
        if (Level == "Luzon") {
            Message.text="Finished! Luzon Completed";
        }
        else if (Level == "Visayas") {
            Message.text = "Finished! Visayas Completed";
        }
        else if (Level == "Mindanao") {
            Message.text = "Finished! Mindanao Completed";
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void btnReturn() {
        SceneManager.LoadScene("Start Scene");
    }
}
