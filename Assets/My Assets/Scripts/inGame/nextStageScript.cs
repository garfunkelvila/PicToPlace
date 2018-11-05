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
public class nextStageScript : MonoBehaviour {
    public currentStatus curStatus;
    public questionaireHandler qHandler;
    public IngameUiHandlerScript Ui;
    public inGameDialogHandlerScript Dlg;
    public Text Title;
    public Text Description;

    public void fillInfo() {
        GetComponent<Image>().sprite = qHandler.currentPic;
        Title.text = qHandler.currentQuestion;
        Description.text = qHandler.currentDescription;
    }

    public void btnNextClick() {
        if (curStatus.isInfiniteMode == false) {
            if (curStatus.CurrentStage == qHandler.TotalQuestions) {
                // if all are answered
                Debug.Log("Stage Cleared!!");
                Dlg.showDialog(inGameDialogHandlerScript.Dialogs.FinishedDialog);
                return;
            }
            
            if (curStatus.CurrentStage == curStatus.StageNumberToUnlockNext) {
                // If not yet all answered
                string Level = PlayerPrefs.GetString("Level");
                if ((Level == "Luzon")&&(PlayerPrefs.GetInt("Visayas") == 0)) {
                    Dlg.showDialog(inGameDialogHandlerScript.Dialogs.UnlockedDialog);
                }
                else if ((Level == "Visayas")&&(PlayerPrefs.GetInt("Mindanao")==0)) {
                    Dlg.showDialog(inGameDialogHandlerScript.Dialogs.UnlockedDialog);
                }
            }
        }
        // these method increments stages and unlocks maps
        qHandler.GenerateQuestion();
        curStatus.UpdateStageText();
        //curStatus.ReloadLives();
    }
}
