using UnityEngine;
using System.Collections;
public class inGameDialogHandlerScript : MonoBehaviour {
    public IngameUiHandlerScript uiHandler;
    public GameObject HintDialog;
    public GameObject FinishedDialog;
    public GameObject UnlockedDialog;
    public GameObject QuitDialog;
    public enum Dialogs {
        HintDialog,
        UnlockedDialog,
        FinishedDialog,
        QuitDialog
    }

    public void showDialog(Dialogs dlg) {
        GameObject temp;
        switch (dlg) { 
            case Dialogs.HintDialog:
                temp = Instantiate(HintDialog);
                temp.transform.SetParent(GameObject.Find("Canvas").transform);
                temp.transform.localPosition = Vector3.zero;
                temp.transform.localScale = Vector3.one;
                temp.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
                break;
            case Dialogs.UnlockedDialog:
                temp = Instantiate(UnlockedDialog);
                temp.transform.SetParent(GameObject.Find("Canvas").transform);
                temp.transform.localPosition = Vector3.zero;
                temp.transform.localScale = Vector3.one;
                temp.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
                break;
            case Dialogs.FinishedDialog:
                temp = Instantiate(FinishedDialog);
                temp.transform.SetParent(GameObject.Find("Canvas").transform);
                temp.transform.localPosition = Vector3.zero;
                temp.transform.localScale = Vector3.one;
                temp.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
                break;
            case Dialogs.QuitDialog:
                temp = Instantiate(QuitDialog);
                temp.GetComponent<quitDialogScript>().uHandler = uiHandler; // not safe
                temp.transform.SetParent(GameObject.Find("Canvas").transform);
                temp.transform.localPosition = Vector3.zero;
                temp.transform.localScale = Vector3.one;
                temp.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);

                uiHandler.isPaused = true;
                break;
            default:
                break;
        }
    }
}
