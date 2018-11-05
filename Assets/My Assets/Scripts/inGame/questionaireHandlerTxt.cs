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
