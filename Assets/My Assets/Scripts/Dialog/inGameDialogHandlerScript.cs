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
