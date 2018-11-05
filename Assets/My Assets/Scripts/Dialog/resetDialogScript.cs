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
using UnityEngine.SceneManagement;

public class resetDialogScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void btnYes() {
        PlayerPrefs.DeleteAll();
        GameObject.Find("Main Camera").GetComponent<PreservedVars>().showPlay = true;
        GameObject.Find("BGM").GetComponent<AudioSource>().mute = false;
        GameObject.Find("Correct and Wrong").GetComponent<AudioSource>().mute = false;
        Debug.LogWarning("Player Prefs cleared!!");
        //Destroy(gameObject);
        SceneManager.LoadScene("Start Scene");
    }
    public void btnNo() {
        Destroy(gameObject);
    }
}
