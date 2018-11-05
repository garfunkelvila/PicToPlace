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
/// Letter and the TextComponent is changed by the questionaireHandler, who is calling the method to generate this on runtime
/// </summary>
public class keyButtonScript : MonoBehaviour {
    public IngameUiHandlerScript Ui;
    currentStatus Status;
    public char Letter;
    questionaireHandler qHandler;
    

    void Start () {
        qHandler = GameObject.Find("logicHandler").GetComponent<questionaireHandler>();
        Status = GameObject.Find("logicHandler").GetComponent<currentStatus>();
        Ui = GameObject.Find("UI Handler").GetComponent<IngameUiHandlerScript>();
    }
    public void btnPressed() {

        gameObject.GetComponent<Button>().interactable = false;
        bool isCorrect = false;
        Status.addToPressedKeys(Letter);

        foreach (var blank in qHandler.blanks) {
            if (Letter.Equals(char.ToUpper(blank.GetComponent<blankScript>().assignedLetter))) {
                blank.GetComponent<blankScript>().showValue();
                isCorrect = true;
                //break;
            }
        }

        if (!isCorrect) {
            GameObject.Find("Correct and Wrong").GetComponent<correcAndWrongSoundScript>().playSound(false);
            //Status.inCrementMistake();
            Status.decrementLives();
            //make button color red.. TEST
            gameObject.GetComponent<Image>().color = new Color(255, 0, 0);
        }
        else {
            // wrong script is in a loop
            GameObject.Find("Correct and Wrong").GetComponent<correcAndWrongSoundScript>().playSound(true);
        }
        if (qHandler.areBlanksCleared() == true) {
            //GameObject.Find("Correct and Wrong").GetComponent<correcAndWrongSoundScript>().playSound(true);
            Status.CorrectRoutine();
            //transfered to status
            //Ui.changeView(IngameUiHandlerScript.Views.NextStageScreen);
        }
    }

    public void btnPressForReload(char key) {
        if (key == Letter) {
            gameObject.GetComponent<Button>().interactable = false;
            bool isCorrect = false;

            foreach (var blank in qHandler.blanks) {
                if (Letter.Equals(char.ToUpper(blank.GetComponent<blankScript>().assignedLetter))) {
                    blank.GetComponent<blankScript>().showValue();
                    isCorrect = true;
                }
            }
            if (isCorrect == false) {
                gameObject.GetComponent<Image>().color = new Color(255, 0, 0);
                //Status.decrementLives();
            }
        }
    }
}
