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

/// <summary>
/// This Script is for this particular prefab only
/// </summary>
public class quitDialogScript : MonoBehaviour {
    public IngameUiHandlerScript uHandler;  // well disable it on show, also this is set by the caller
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void btnQuitToMenu() {
        SceneManager.LoadScene("Start Scene");
    }

    public void btnQuit() {
        Application.Quit();
    }
    public void btnCancel() {
        uHandler.isPaused = false;
        Destroy(gameObject);
    }
}
