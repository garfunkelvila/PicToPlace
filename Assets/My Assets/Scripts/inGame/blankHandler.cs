using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
// TODO: this thing needs cleanup after doing the word wrap

/// <summary>
/// Sorrry if this code is messy, 
/// 
/// Short description:
/// Because Update is called once per frame, we can use it to detect
/// if the last worrd makes the container overflow from its parent, if that happen
/// we put the last word and the nexts to the next line
/// </summary>
public class blankHandler : MonoBehaviour {
    public GameObject LetterPrefab;     // Letter Only not a button mode

    public questionaireHandler qeustionHandler; // this is where wel lsave the blanks

    public RectTransform ContainerToCompareOverload;
    public RectTransform ContainerThatOverloads;
    public GameObject QuestionContainer;// Where line container will be placed
    public GameObject BlankBtnPrefab;
    public GameObject BlankSpacePreab;  // used for space
    public GameObject[] blanks;         // public to check if its right

    // things here are related in blank generation
    public RectTransform ParentRect;    // is used for matching the size
    private bool isGenerating = false;  // will be swtched on by the GenerateBlank and switched off in the update after loading all words
    private List<char> charBuffer = new List<char>(); // will save a copy of the answer as character list
    public GameObject LineContainer;    // this prefab carries the words, must have horizontal layout
    public GameObject WordContainer;    // this prefab carries the letters, must have horizontal layout
    private GameObject CurrentLine;
    private GameObject CurrentWord;

    void Start () {
        // just some checks and reminders, nothing to do with the logic
        if (LineContainer == null) Debug.LogError(LineContainer);
        if (WordContainer == null) Debug.LogError(WordContainer);
    }
    /// <summary>
    /// Update is called every frame
    /// </summary>
    void Update () {
        if(isGenerating == true) {

            /// this thing transferes the word to the next line if overflow is detected, this is located under the next if ..
            /// but i put it before because the last word isnt detected
            //Debug.Log(ParentRect.rect.width + " : " + QuestionContainer.GetComponent<RectTransform>().rect.width);
            if (ContainerThatOverloads.rect.width > ContainerToCompareOverload.rect.width) {
            //if (QuestionContainer.GetComponent<RectTransform>().rect.width > ParentRect.rect.width) {
                // if the container is larger than its parent .. transfer the previwew and next words to next line
                CurrentLine = Instantiate(LineContainer);
                CurrentLine.transform.SetParent(QuestionContainer.transform);
                CurrentLine.transform.localScale = Vector3.one;

                CurrentWord.transform.SetParent(CurrentLine.transform);
            }

            /// generate word per frame
            if (charBuffer.Count > 0) {    // check if it is not empty
                #region Generates Word
                GameObject currentChar;
                CurrentWord = Instantiate(WordContainer);
                CurrentWord.transform.SetParent(CurrentLine.transform);
                CurrentWord.transform.localScale = Vector3.one;

                // convert it to WHILE LOOOOOOOP demeeet -_-
                do {
                    if (charBuffer.Count == 0) break;   // i cant get rid of the out of bound
                    //if (charBuffer[0] == '\r' && charBuffer.Count == 1) break;   // for some reason i cant remove the \r on the question handler loop
                    /* // Button Letter
                    currentChar = Instantiate(BlankBtnPrefab);
                    currentChar.transform.SetParent(CurrentWord.transform);
                    currentChar.transform.localScale = Vector3.one;
                    currentChar.GetComponent<blankButtonScript>().Letter = charBuffer[0];
                    */
                    //currentChar.GetComponentInChildren<Text>().text  = charBuffer[0].ToString();
                    currentChar = Instantiate(LetterPrefab);
                    currentChar.transform.SetParent(CurrentWord.transform);
                    currentChar.transform.localScale = Vector3.one;
                    currentChar.GetComponent<blankScript>().assignedLetter = char.ToUpper(charBuffer[0]);

                    if (charBuffer[0] == '\''){
                        currentChar.GetComponent<blankScript>().showValue();
                    }
                    else if (charBuffer[0] == '-') {
                        currentChar.GetComponent<blankScript>().showValue();
                    }
                    else if (charBuffer[0] == '.') {
                        currentChar.GetComponent<blankScript>().showValue();
                    }
                    else {
                        qeustionHandler.blanks.Add(currentChar);
                    }
                    
                    //Debug.Log(charBuffer.Count);
                    charBuffer.RemoveAt(0); // remove what we have put
                    if (charBuffer.Count == 0) break;   // this thing fixed the out of range error above ... weird :\ // FOrgot about while loop XD il lcnvert it and try sooner
                } while (charBuffer[0] != ' ');

                if (charBuffer.Count != 0) charBuffer.RemoveAt(0); // remove the space, because we cant safely remove it within the loop, i think?
                #endregion

                //gameObject.GetComponent<currentStatus>().rePressKeys();
            }
            else {
                gameObject.GetComponent<currentStatus>().rePressKeys();
                isGenerating = false;   /// if we already pulled all of the letters, flip it so isGenerating condition will not run ;)
                CurrentLine = null;     /// just clean it to save some memory :)
                CurrentWord = null;     /// its a best practice to do this when it'll not be used again
            }
            //gameObject.GetComponent<currentStatus>().rePressKeys();
        }
    }
    void LateUpdate() {

    }
    public void GenerateBlanks(string Question) {
        //Debug.Log(Question);
        char[] chAnswer = Question.ToCharArray();   // converts to char array
        charBuffer.AddRange(chAnswer);  // converts to list so we can remove one by one on update
        //Debug.Log(charBuffer.Count);

        CurrentLine = Instantiate(LineContainer);
        CurrentLine.transform.SetParent(QuestionContainer.transform);
        CurrentLine.transform.localScale = Vector3.one;

        isGenerating = true;
    }

    
}
