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
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnlockedDialogScript : MonoBehaviour {
    public Text Message;
    public Text btnTxt;
	// Use this for initialization
	void Awake () {
        string Level = PlayerPrefs.GetString("Level");
        if (Level == "Luzon") {
            Debug.Log("Unlocked Visayas");
            PlayerPrefs.SetInt("Visayas", 1);
            //Ui.changeView(IngameUiHandlerScript.Views.UnlockScreen);

            Message.text = "Congratulations!\nVisayas unlocked";
            btnTxt.text = "Go to Visayas";
        }
        else if (Level == "Visayas") {
            Debug.Log("Unlocked Mindanao");
            PlayerPrefs.SetInt("Mindanao", 1);
            //Ui.changeView(IngameUiHandlerScript.Views.UnlockScreen);
            Message.text = "Congratulations!\nMindanao unlocked";
            btnTxt.text = "Go to Mindanao";
        }
        PlayerPrefs.Save();
    }
	
    public void btnContinue() {
        Destroy(gameObject);
    }
    public void btnProceed() {
        string Level = PlayerPrefs.GetString("Level");
        if (Level == "Luzon") {
            PlayerPrefs.SetString("Level", "Visayas");
            SceneManager.LoadScene("In game Scene");
        }
        else if (Level == "Visayas") {
            PlayerPrefs.SetString("Level", "Mindanao");
            SceneManager.LoadScene("In game Scene");
        }
        else {
            Debug.Log("An error occured");
            Application.Quit();
        }
    }
    
}
