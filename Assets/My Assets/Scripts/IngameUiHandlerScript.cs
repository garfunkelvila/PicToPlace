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
/// This one calls the question loader and the generate question on start 
/// </summary>
public class IngameUiHandlerScript : MonoBehaviour {
    public bool isPaused = false;
    public GameObject logicHandler;

    public GameObject InGameScreen;
    public GameObject NextStageScreen;
    public GameObject GameOverScreen;
    public enum Views {
        InGameScreen,
        NextStageScreen,
        GameOverScreen,
    }
    public Views CurrentView = 0;

	void Start () {
        //PlayerPrefs.DeleteAll();

        string Level = PlayerPrefs.GetString("Level");
        if(Level == "Luzon") {
            logicHandler.GetComponent<questionaireHandler>().LoadQuestion(QuestionTypes.Luzon);
            //logicHandler.GetComponent<questionaireHandler>().GenerateQuestion();
            logicHandler.GetComponent<questionaireHandler>().ReloadQuestion();
            logicHandler.GetComponent<currentStatus>().ReloadLives();
        }
        else if (Level == "Visayas") {
            logicHandler.GetComponent<questionaireHandler>().LoadQuestion(QuestionTypes.Visayas);
            //logicHandler.GetComponent<questionaireHandler>().GenerateQuestion();
            logicHandler.GetComponent<questionaireHandler>().ReloadQuestion();
            logicHandler.GetComponent<currentStatus>().ReloadLives();
        }
        else if (Level == "Mindanao") {
            logicHandler.GetComponent<questionaireHandler>().LoadQuestion(QuestionTypes.Mindanao);
            //logicHandler.GetComponent<questionaireHandler>().GenerateQuestion();
            logicHandler.GetComponent<questionaireHandler>().ReloadQuestion();
            logicHandler.GetComponent<currentStatus>().ReloadLives();
        }
        else {
            Debug.Log("An error occured");
            Application.Quit();
        }
        InGameScreen.SetActive(true);
        logicHandler.GetComponent<currentStatus>().UpdateStageText();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void changeView(Views a) {
        InGameScreen.SetActive(false);
        NextStageScreen.SetActive(false);
        GameOverScreen.SetActive(false);

        switch (a) {
            case Views.InGameScreen:
                InGameScreen.SetActive(true);
                break;
            case Views.NextStageScreen:
                NextStageScreen.SetActive(true);
                break;
            case Views.GameOverScreen:
                GameOverScreen.SetActive(true);
                break;
            default:
                break;
        }
    }

    
}
