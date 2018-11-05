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

public class unlockScreenScript : MonoBehaviour {
    public GameObject LogicHandler;
    public IngameUiHandlerScript Ui;
    public nextStageScript nStage;

    public string StageBeingUnlocked;
    public Text Message;
    public Text btnLevel;

    public void UpdateText(string Level) {
        Message.text = "Congratulations " + Level + " unlocked";
        btnLevel.text = "Go to " + Level;
    }

    public void btnContinue() {
        LogicHandler.GetComponent<questionaireHandler>().GenerateQuestion();
        LogicHandler.GetComponent<currentStatus>().UpdateStageText();
        //LogicHandler.GetComponent<currentStatus>().ReloadLives();
        LogicHandler.GetComponent<currentStatus>().refillLives();

        Ui.changeView(IngameUiHandlerScript.Views.InGameScreen);
    }
    public void btnNextLevel() {
        // same logic used in ui handler
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
