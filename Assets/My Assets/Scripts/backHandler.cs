using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
/// <summary>
/// This thing needs a full cleanup and needs to seperate into 2 parts
/// one for ingame and one for menu
/// </summary>
public class backHandler : MonoBehaviour {
    public IngameUiHandlerScript uiHandler;
    public inGameDialogHandlerScript dlgHandler;
    public enum backModes {
        Menu,   // menu goes back
        InGame  // ingame goes to menu
    }
    public GameObject quitConfirm;
    public backModes BackMode;
    public GameObject startUI;
    public GameObject levelUI;
    public Stack<GameObject> backHistory = new Stack<GameObject>();
    public string MainMenuSceneName;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start() {
        //backHistory.Push(startUI);
    }
    void Awake() {
        backHistory.Clear();
        backHistory.Push(startUI);
    }
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update() {
        if (Input.GetKeyUp("escape")) {
            switch (BackMode) {
                case backModes.Menu:
                    btnBack();
                    break;
                case backModes.InGame:
                    //if (uiHandler.isPaused == false) {
                    //    /*GameObject temp;
                    //    temp = Instantiate(quitConfirm);
                    //    temp.GetComponent<quitDialogScript>().uHandler = uiHandler; // not safe
                    //    temp.transform.SetParent(GameObject.Find("Canvas").transform);
                    //    temp.transform.localPosition = Vector3.zero;
                    //    temp.transform.localScale = Vector3.one;
                    //    temp.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);

                    //    uiHandler.isPaused = true;*/
                    //    dlgHandler.showDialog(inGameDialogHandlerScript.Dialogs.QuitDialog);
                    //}
                    //else {
                    //    //uiHandler.isPaused = false;
                    //}

                    loadScene("Start Scene");
                    break;
                default:
                    Debug.Log("Back mode not set");
                    break;
            }
        }
    }

    /// <summary>
    /// Attach this to buttons scripts
    /// </summary>
    /// <param name="objectToShow">The thing will be shown next</param>
    public void btnForward(GameObject objectToShow) {
        backHistory.Peek().SetActive(false);
        backHistory.Push(objectToShow);
        objectToShow.SetActive(true);
        //Debug.Log(backHistory.Count);
    }
    /// <summary>
    /// Call this on press of escape or back or any to go back
    /// </summary>
    public void btnBack() {
        if (backHistory.Count != 1) {
            backHistory.Pop().SetActive(false);
            backHistory.Peek().SetActive(true);
        }
        Debug.Log(backHistory.Count);
        Debug.Log(backHistory.Peek());
    }
    /// <summary>
    /// Call this to call a scene by its name
    /// </summary>
    /// <param name="SceneName">Name of scnene on build settings</param>
    public void loadScene(string SceneName) {
        //Application.LoadLevel(SceneName);
        SceneManager.LoadScene(SceneName); // this is a new featutre in 5.3
    }
    public void SetLevel(string LevelName) {
           // I want to convert it to int for faster processing but longer code
           PlayerPrefs.SetString("Level", LevelName);
    }

    public void Quit() {
        Application.Quit();
    }
}
