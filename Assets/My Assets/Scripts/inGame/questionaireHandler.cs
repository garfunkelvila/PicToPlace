using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
#region database related and imported lib
using System;
using System.IO;
//using System.Data.SqlClient;
#endregion
/// <summary>
/// Warning this code is messy !!!!!!!!!!!!!!!!!!
/// This thing should generate question for us
/// Requires keysHandler, Blank Handler
/// Attach this to any gameObject in the scene, preferably handler
/// with name logicHandler, dahil naka base duun yung ibang scripts
/// 
/// #NOTE SqLite is not used, i used TextAsset to grab the datas on the text file located at "/Resources"
/// This thing shoudl use SQLite so i download MySql for
/// Visual Studio to ease up settings and to centralize the code,
/// so well not installing the seperate MySql Standalone ;).
/// We'll be using Visual Studio for setting up the database, adding tables and
/// datas as its fixed and well not use the Insert function of database on runtime
/// 
/// Database will be located at "/StreammingAsset" inside project folder
/// "/lib/Mono.Data.SqliteClient" this library is from monodevelop, we copied it
/// here because we might be using database and for weird reason, I cant use that
/// library (using Mono.Data.SqliteClient; at the top) unless i inclue it in the project
/// 
/// REASON WHY WE CANT USE SQLITE
/// http://forum.unity3d.com/threads/yes-another-dllnotfoundexception-system-data-sqlite-dll-post.66182/
/// </summary>
/// 
public enum QuestionTypes {
    Luzon,
    Visayas,
    Mindanao
}
public class questionaireHandler : MonoBehaviour {
    public IngameUiHandlerScript uiHandler;
    public GameObject QuestionImageContainer;
    public blankHandler bHandler;
    public int QuestionIndex;
    public Sprite currentPic;
    public string currentQuestion;
    public string currentDescription;

    public int TotalQuestions;
    public string[] AllQuestions;
    string[] _Questions;
    Sprite[] _Images;
    string[] _Descriptions;

    public List<String> Questions;
    public List<Sprite> Images;
    public List<String> Descriptions;
    
    public List<GameObject> blanks = new List<GameObject>();

    /// <summary>
    /// converted into bool for the unlocking
    /// Returns false if it cannot generate more
    /// and true if generate is sucessfull
    /// </summary>
    /// <returns></returns>
    public bool GenerateQuestion() {
        QuestionIndex = UnityEngine.Random.Range(0, Questions.Count);
        string Level = PlayerPrefs.GetString("Level");
        
        #region this part is for saving the current question index
        if (Level == "Luzon") {
            PlayerPrefs.SetInt("Current Luzon Index", QuestionIndex + 1);
        }
        else if (Level == "Visayas") {
            PlayerPrefs.SetInt("Current Visayas Index", QuestionIndex + 1);
        }
        else if (Level == "Mindanao") {
            PlayerPrefs.SetInt("Current Mindanao Index", QuestionIndex + 1);
        }
        else {
            Debug.Log("An error occured");
            Application.Quit();
        }
        PlayerPrefs.Save();

        #endregion
        Debug.Log(QuestionIndex);
        currentPic = Images[QuestionIndex];
        currentQuestion = Questions[QuestionIndex];
        currentDescription = Descriptions[QuestionIndex];
        // load image to image canvas
        QuestionImageContainer.GetComponent<Image>().sprite = Images[QuestionIndex];
        gameObject.GetComponent<blankHandler>().GenerateBlanks(currentQuestion);
        uiHandler.changeView(IngameUiHandlerScript.Views.InGameScreen);
        return true;
    }
    /// <summary>
    /// This one loads from prefs and if nothing is there generate new
    /// </summary>
    public bool ReloadQuestion() {
        string Level = PlayerPrefs.GetString("Level");
        if (Level == "Luzon") {
            if (PlayerPrefs.GetInt("Current Luzon Index") == 0) {
                Debug.Log("Generated from scratch");
                QuestionIndex = UnityEngine.Random.Range(0, Questions.Count);
            }
            else {
                QuestionIndex = PlayerPrefs.GetInt("Current Luzon Index") - 1;
            }
        }
        else if (Level == "Visayas") {
            if (PlayerPrefs.GetInt("Current Visayas Index") == 0) {
                QuestionIndex = UnityEngine.Random.Range(0, Questions.Count);
            }
            else {
                QuestionIndex = PlayerPrefs.GetInt("Current Visayas Index") - 1;
            }
        }
        else if (Level == "Mindanao") {
            if (PlayerPrefs.GetInt("Current Mindanao Index") == 0) {
                QuestionIndex = UnityEngine.Random.Range(0, Questions.Count);
            }
            else {
                Debug.Log("Loaded from prefs");
                QuestionIndex = PlayerPrefs.GetInt("Current Mindanao Index") - 1;
            }
        }
        else {

        }
        #region this part is for saving the current question index
        if (Level == "Luzon") {
            PlayerPrefs.SetInt("Current Luzon Index", QuestionIndex + 1);
        }
        else if (Level == "Visayas") {
            PlayerPrefs.SetInt("Current Visayas Index", QuestionIndex + 1);
        }
        else if (Level == "Mindanao") {
            PlayerPrefs.SetInt("Current Mindanao Index", QuestionIndex + 1);
        }
        else {
            Debug.Log("An error occured");
            Application.Quit();
        }
        PlayerPrefs.Save();

        #endregion
        currentPic = Images[QuestionIndex];
        currentQuestion = Questions[QuestionIndex];
        currentDescription = Descriptions[QuestionIndex];

        QuestionImageContainer.GetComponent<Image>().sprite = Images[QuestionIndex];
        gameObject.GetComponent<blankHandler>().GenerateBlanks(currentQuestion);
        uiHandler.changeView(IngameUiHandlerScript.Views.InGameScreen);
        return true;
    }

    public void LoadQuestion(QuestionTypes Type) {
        TextAsset Question = null;
        TextAsset ImagePaths = null;
		TextAsset Description = null;
        string[] strImagePaths;
        
        List<Sprite> ImagesBuffer = new List<Sprite>();

        switch (Type) {
			case QuestionTypes.Luzon:
				Question = Resources.Load<TextAsset> ("Luzon Questions");
				Description = Resources.Load<TextAsset> ("Luzon Descriptions");
				ImagePaths = Resources.Load<TextAsset> ("Luzon Image Names");
				//Debug.Log (Description);
                break;
            case QuestionTypes.Visayas:
				Question = Resources.Load<TextAsset> ("Visayas Questions");
				Description = Resources.Load<TextAsset> ("Visayas Descriptions");
                ImagePaths = Resources.Load<TextAsset>("Visayas Image Names");
                break;
            case QuestionTypes.Mindanao:
				Question = Resources.Load<TextAsset> ("Mindanao Questions");
				Description = Resources.Load<TextAsset> ("Mindanao Descriptions");
                ImagePaths = Resources.Load<TextAsset> ("Mindanao Image Names");
                break;
            default:
                break;
        }
        _Questions = removeNewLines(Question.text.Split('\n'));
        Debug.Log(_Questions.Length + " questions loaded");

        _Descriptions = removeNewLines(Description.text.Split('\n'));
        Debug.Log(_Descriptions.Length + " descriptions loaded");

        strImagePaths = removeNewLines(ImagePaths.text.Split('\n'));

		switch (Type) {
            case QuestionTypes.Luzon:
                foreach (string item in strImagePaths) {
                    ImagesBuffer.Add(Resources.Load<Sprite>("Luzon/" + item));
                }
                break;
            case QuestionTypes.Visayas:
                foreach (string item in strImagePaths) {
                    ImagesBuffer.Add(Resources.Load<Sprite>("Visayas/" + item));
                }
                break;
            case QuestionTypes.Mindanao:
                foreach (string item in strImagePaths) {
                    ImagesBuffer.Add(Resources.Load<Sprite>("Mindanao/" + item));
                }
                break;
            default:
                Debug.LogError("I just put it here but i know it is unreachable, just in case XD");
                break;
        }

        _Images = ImagesBuffer.ToArray();
        Debug.Log(_Images.Length + " images loaded");
        /// just some checks, does nothing to the logic
        if (_Questions.Length != _Descriptions.Length) {
            Debug.LogError("Questions and Descriptions are not equal " + _Questions.Length + ":" + _Descriptions.Length);
        }

        TotalQuestions = _Questions.Length;
        AllQuestions = _Questions;
        pushItemsToList();  // this method also deltes the items in the array so we ned to get the total before here

    }
    private string[] removeNewLines(string[] aa) {
        List<String> a = new List<string>();
        foreach (var item in aa) {
            a.Add(item.Trim('\r', '\n'));
        }
        return a.ToArray();
    }
    /// <summary>
    /// If is infinite is on ... this allows to load answered questions, should only be on if run out of answers
    /// </summary>
    /// <param name="isInfinite"></param>
    private void pushItemsToList() {
        Questions.Clear();
        Images.Clear();
        Descriptions.Clear();
        int i = 0;

		//Debug.Log(_Questions.Length);
		//Debug.Log(_Images.Length);
        do {
            // because PlayerPrefs dont support boolean, I used int, 0 for un-answerd and 1 for answered;
            if (PlayerPrefs.GetInt(_Questions[i]) == 0) {
				Debug.Log(_Descriptions.Length);
                Questions.Add(_Questions[i]);
                Images.Add(_Images[i]);
                Descriptions.Add(_Descriptions[i]); // Just Added
            }
            i++;
        } while (i < _Questions.Length);
        Debug.Log(Questions.Count + " Questions Unanswered");

        if (Questions.Count == 0) {
            gameObject.GetComponent<currentStatus>().isInfiniteMode = true;
            //Debug.Log("All questions are answered, reloading all for infinite mode");
            i = 0;
            do {
                // because PlayerPrefs dont support boolean, I used int, 0 for un-answerd and 1 for answered;
                // same trick is used on audio
                Questions.Add(_Questions[i]);
                Images.Add(_Images[i]);
                Descriptions.Add(_Descriptions[i]);
                i++;
            } while (i < _Questions.Length);
        }
        // jsut to save some memory as well not use it again
        _Questions = null;
        _Images = null;
        _Descriptions = null;
    }

    public bool areBlanksCleared() {
        foreach (var blank in blanks) {
            if (blank.GetComponent<blankScript>().isAnswered == false){
                return false;
            }
        }
        return true;
    }
}