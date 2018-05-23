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
