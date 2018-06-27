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
