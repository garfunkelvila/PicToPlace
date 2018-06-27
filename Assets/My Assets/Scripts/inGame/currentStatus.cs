using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
/// <summary>
/// This only contains the current key being pressed XD
/// </summary>
public class currentStatus : MonoBehaviour {
    public Text StageNumber;

    public GameObject MiskakePrefab;
    public GameObject WhereToPutMistakePrefab;
    public GameObject WhereToPutHearts;
    public IngameUiHandlerScript Ui;
    public inGameDialogHandlerScript Dlg;
    public questionaireHandler qHandler;
    public nextStageScript nStage;
    public unlockScreenScript unlkScreen;
    public int CurrentStage = 1;
    public int StageNumberToUnlockNext;

    public char CurrentKey;
    public int CurrentMistakesCount;
    
    public int maxMistakes;
    public int CurrentLives;
    public int maxLives;
    public int coinsPerLevel = 1;
    public bool isInfiniteMode = false;

    public GameObject HeartPrefab;


    public List<char> pressedKeys = new List<char>();
    void Start () {
        GameObject.Find("Coins").GetComponentInChildren<Text>().text = PlayerPrefs.GetInt("Coins").ToString();
    }
	
	void Awake () {


        string Level = PlayerPrefs.GetString("Level");
        if (Level == "Luzon") {
            CurrentStage = PlayerPrefs.GetInt("Luzon Stage");
        }
        else if (Level == "Visayas") {
            CurrentStage = PlayerPrefs.GetInt("Visayas Stage");
        }
        else if (Level == "Mindanao") {
            CurrentStage = PlayerPrefs.GetInt("Mindanao Stage");
        }
        else {
            Debug.LogError("There is no stage on PlayerPrefs");
            Application.Quit();
        }

        PreservedVars vars = GameObject.Find("Main Camera").GetComponent<PreservedVars>();// because main camera holds the script XD
        vars.showPlay = false;
    }
    /// <summary>
    /// I think it is obsolete and never used
    /// </summary>
    /*public void inCrementMistake() {
        if (CurrentMistakesCount < maxMistakes) {
            GameObject tempObj;
            CurrentMistakesCount++;

            tempObj = Instantiate(MiskakePrefab);
            tempObj.transform.SetParent(WhereToPutMistakePrefab.transform);
            tempObj.transform.localScale = Vector3.one;
        }
        else {
            Ui.changeView(IngameUiHandlerScript.Views.GameOverScreen);
        }
    }*/

    public void decrementLives() {
        string Level = PlayerPrefs.GetString("Level");

        if (CurrentLives > 1) {
            CurrentLives--;

            
            if (Level == "Luzon") {
                PlayerPrefs.SetInt("Current Luzon Lives", CurrentLives);
            }
            else if (Level == "Visayas") {
                PlayerPrefs.SetInt("Current Visayas Lives", CurrentLives);
            }
            else if (Level == "Mindanao") {
                PlayerPrefs.SetInt("Current Mindanao Lives", CurrentLives);
            }
            else {
                Debug.Log("An error occured");
                Application.Quit();
            }
            PlayerPrefs.Save();


            GameObject[] temp;
            temp = GameObject.FindGameObjectsWithTag("Heart");
            Destroy(temp[0]);
            //decrease heart
        }
        else { // GAME OVER
            /*if (!isInfiniteMode) {
                resetProgress();
            }*/
            if (Level == "Luzon") {
                PlayerPrefs.SetInt("Current Luzon Lives", 0);
                PlayerPrefs.SetInt("Current Luzon Index", 0); // set it to zero so the generator thinks it needs new
            }
            else if (Level == "Visayas") {
                PlayerPrefs.SetInt("Current Visayas Lives", 0);
                PlayerPrefs.SetInt("Current Visayas Index", 0);
            }
            else if (Level == "Mindanao") {
                PlayerPrefs.SetInt("Current Mindanao Lives", 0);
                PlayerPrefs.SetInt("Current Mindanao Index", 0);
            }
            else {
                Application.Quit();
            }
            PlayerPrefs.Save();


            //pressedKeys.Clear();
            clearPressedKeys();
            Ui.changeView(IngameUiHandlerScript.Views.GameOverScreen);
        }
    }

    /// <summary>
    /// this method loads lives from player prefs and if is infinite reset lives to 3
    /// </summary>
    public void ReloadLives() {
        string Level = PlayerPrefs.GetString("Level");
        if (Level == "Luzon") {
            CurrentLives = PlayerPrefs.GetInt("Current Luzon Lives");
        }
        else if (Level == "Visayas") {
            CurrentLives = PlayerPrefs.GetInt("Current Visayas Lives");
        }
        else if (Level == "Mindanao") {
            CurrentLives = PlayerPrefs.GetInt("Current Mindanao Lives");
        }
        else {
            Application.Quit();
        }
        //if (CurrentLives == 0) CurrentLives = maxLives;
        if (CurrentLives == 0) {
            refillLives();
            return;
        }

        if (isInfiniteMode == true) {
            if (CurrentLives == 0) {
                refillLives();
                return;
            }
        }
        GameObject[] temp;
        temp = GameObject.FindGameObjectsWithTag("Heart");
        foreach (GameObject item in temp) {
            Destroy(item);
        }

        int i = 0;
        GameObject tempObj;
        do {
            tempObj = Instantiate(HeartPrefab);
            tempObj.transform.SetParent(WhereToPutHearts.transform);
            tempObj.transform.localScale = Vector3.one;
            i++;
        } while (i < CurrentLives);
        //HeartPrefab
    }
    /// <summary>
    /// This method resets lives to max
    /// </summary>
    public void refillLives() {
        Debug.Log("Lives REFIL");
        CurrentLives = maxLives;
        string Level = PlayerPrefs.GetString("Level");
        if (Level == "Luzon") {
            PlayerPrefs.SetInt("Current Luzon Lives", CurrentLives);
        }
        else if (Level == "Visayas") {
            PlayerPrefs.SetInt("Current Visayas Lives", CurrentLives);
        }
        else if (Level == "Mindanao") {
            PlayerPrefs.SetInt("Current Mindanao Lives", CurrentLives);
        }
        else {
            Debug.Log("An error occured");
            Application.Quit();
        }
        PlayerPrefs.Save();



        GameObject[] temp;
        temp = GameObject.FindGameObjectsWithTag("Heart");
        foreach (GameObject item in temp) {
            Destroy(item);
        }

        int i = 0;
        GameObject tempObj;
        do {
            tempObj = Instantiate(HeartPrefab);
            tempObj.transform.SetParent(WhereToPutHearts.transform);
            tempObj.transform.localScale = Vector3.one;
            i++;
        } while (i < maxLives);

        //pressedKeys.Clear();
        clearPressedKeys();
    }

    /// <summary>
    /// Corect Code
    /// </summary>
    public void CorrectRoutine() {
        //remove the answered question to the list of questions currently loaded

        // sets the current question to answered
        PlayerPrefs.SetInt(qHandler.Questions[qHandler.QuestionIndex], 1);  

        if (isInfiniteMode == false) {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + coinsPerLevel);     // Increments the coins
            GameObject.Find("Coins").GetComponentInChildren<Text>().text = PlayerPrefs.GetInt("Coins").ToString();// dirty fix
        }
        
        //PlayerPrefs.Save();

        // if infinite mode dont delete
        if (isInfiniteMode == false) {
            qHandler.Questions.RemoveAt(qHandler.QuestionIndex);
            qHandler.Images.RemoveAt(qHandler.QuestionIndex);
            qHandler.Descriptions.RemoveAt(qHandler.QuestionIndex);
        }
        //--------- Cleanup
        qHandler.blanks.Clear();
        GameObject[] gamObj;
        gamObj = GameObject.FindGameObjectsWithTag("Key");
        //keys = GetComponentInChildren<Button>().interactable = true;
        foreach (GameObject key in gamObj) {
            key.GetComponent<Button>().interactable = true;
            key.GetComponent<Image>().color = new Color32(0,101,8,255);
        }
        gamObj = GameObject.FindGameObjectsWithTag("Blank");
        //keys = GetComponentInChildren<Button>().interactable = true;
        foreach (GameObject key in gamObj) {
            Destroy(key);
        }
        gamObj = GameObject.FindGameObjectsWithTag("Xmark");
        foreach (GameObject key in gamObj) {
            Destroy(key);
        }
        //---------------------------- saves the stage 
        string Level = PlayerPrefs.GetString("Level");

        if (isInfiniteMode == false) {
            CurrentStage++;

            
            if (Level == "Luzon") {
                PlayerPrefs.SetInt("Luzon Stage", CurrentStage);
            }
            else if (Level == "Visayas") {
                PlayerPrefs.SetInt("Visayas Stage", CurrentStage);
            }
            else if (Level == "Mindanao") {
                PlayerPrefs.SetInt("Mindanao Stage", CurrentStage);
            }
            else {
                Debug.Log("An error occured");
                Application.Quit();
            }
        }
        else {

        }
        clearPressedKeys();
        //---------------------------

        /*if (CurrentStage == qHandler.TotalQuestions) {
            // if all are answered
            //Ui.changeView(IngameUiHandlerScript.Views.FinishedScreen);
            Debug.Log("Stage Cleared!!");
            Dlg.showDialog(inGameDialogHandlerScript.Dialogs.FinishedDialog);
            return;
        }*/

        //---------------------
        CurrentMistakesCount = 0;
        CurrentLives = maxLives;
        //ReloadLives();
        refillLives();
        //pressedKeys.Clear();
        clearPressedKeys();
        nStage.fillInfo();
        Ui.changeView(IngameUiHandlerScript.Views.NextStageScreen);

//        nStage.fillInfo();
        
    }
    public void UpdateStageText() {
        if (isInfiniteMode == false) {
            StageNumber.text = CurrentStage + " of " + qHandler.TotalQuestions;
        }
        else {
            StageNumber.text = "Infinite";
        }
    }

    /// <summary>
    /// Call this on game over
    /// </summary>
    public void resetProgress() {
        string Level = PlayerPrefs.GetString("Level");
        if (Level == "Luzon") {
            PlayerPrefs.SetInt("Luzon Stage", 0);
            PlayerPrefs.SetInt("Current Luzon Stage",0);
            PlayerPrefs.SetInt("Current Luzon Lives", 0);

        }
        else if (Level == "Visayas") {
            PlayerPrefs.SetInt("Visayas Stage", 0);
            PlayerPrefs.SetInt("Current Visayas Stage", 0);
            PlayerPrefs.SetInt("Current Visayas Lives", 0);
        }
        else if (Level == "Mindanao") {
            PlayerPrefs.SetInt("Mindanao Stage", 0);
            PlayerPrefs.SetInt("Current Mindanao Stage", 0);
            PlayerPrefs.SetInt("Current Mindanao Lives", 0);
        }
        else {
            Debug.Log("An error occured");
            Application.Quit();
        }
        clearPressedKeys();

        for (int i = 0; i < qHandler.AllQuestions.Length ; i++) {
            PlayerPrefs.SetInt(qHandler.AllQuestions[i], 0);
        }
        PlayerPrefs.Save();
    }

    public void addToPressedKeys(char key) {
        pressedKeys.Add(key);

        string Level = PlayerPrefs.GetString("Level");
        if (Level == "Luzon") {
            PlayerPrefs.SetString("Luzon Pressed",PlayerPrefs.GetString("Luzon Pressed") + key);
        }
        else if (Level == "Visayas") {
            PlayerPrefs.SetString("Visayas Pressed", PlayerPrefs.GetString("Visayas Pressed") + key);
        }
        else if (Level == "Mindanao") {
            PlayerPrefs.SetString("Mindanao Pressed", PlayerPrefs.GetString("Mindanao Pressed") + key);
        }
        else {
            Debug.Log("An error occured");
            Application.Quit();
        }
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Use this to clear kerpyess, now also clears current question used in Keys
    /// </summary>
    public void clearPressedKeys() {
        Debug.Log("Keys Cleared");
        pressedKeys.Clear();

        string Level = PlayerPrefs.GetString("Level");
        if (Level == "Luzon") {
            PlayerPrefs.SetString("Luzon Pressed", "");
        }
        else if (Level == "Visayas") {
            PlayerPrefs.SetString("Visayas Pressed", "");
        }
        else if (Level == "Mindanao") {
            PlayerPrefs.SetString("Mindanao Pressed", "");
        }
        else {
            Debug.Log("An error occured");
            Application.Quit();
        }
        PlayerPrefs.Save();
    }

    public void rePressKeys() {
        GameObject[] btns;
        char[] pressedLetters = null;

        string Level = PlayerPrefs.GetString("Level");
        if (Level == "Luzon") {
            pressedLetters = PlayerPrefs.GetString("Luzon Pressed").ToCharArray();
        }
        else if (Level == "Visayas") {
            pressedLetters = PlayerPrefs.GetString("Visayas Pressed").ToCharArray();
        }
        else if (Level == "Mindanao") {
            pressedLetters = PlayerPrefs.GetString("Mindanao Pressed").ToCharArray();
        }
        else {
            Debug.Log("An error occured");
            Application.Quit();
        }
        //----- RELOAD KEYS FROM PREFS
        btns = GameObject.FindGameObjectsWithTag("Key");
        foreach (char letter in pressedLetters) {
            foreach (GameObject button in btns) {
                button.GetComponent<keyButtonScript>().btnPressForReload(letter);// btnpressed for reload match the lette
            }
        }
        pressedKeys.Clear();
        pressedKeys.AddRange(pressedLetters);

        Debug.Log("Pressed Letters: " + pressedLetters.Length);
    }
}