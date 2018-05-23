using UnityEngine;
using System.Collections;

/// <summary>
/// OK so i started again XD
/// </summary>
public class questionaireHandlerTxt : MonoBehaviour {
    public enum QuestionTypes {
        Luzon,
        Visayas,
        Mindanao
    }

	/// Use this for initialization
	void Start () {
	
	}
	
	/// Update is called once per frame
	void Update () {
	
	}

    public void LoadQuestions(QuestionTypes Type) {
        TextAsset temp1 = Resources.Load("aa") as TextAsset;
        string temp = temp1.text;
        Debug.Log(temp);
    }
}
