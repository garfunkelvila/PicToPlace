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
using UnityEngine.UI;

using System.Collections.Generic;
/// <summary>
/// This thing carries the key to compare
/// </summary>
public class keysHandler : MonoBehaviour {
    public GameObject KeysContainer;
    public GameObject KeyPrefab;

    List<char> AllCharacters = new List<char>(); /// this thing contains answers and extra letters, might be removed if using "qwerty"
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GenerateKeys(string Question) {
        GameObject tempObj;
        /// this thing converts the string to character array then add them to the character list called AllCharacter;
        char[] chAnswer = Question.ToCharArray();

        foreach (var letter in chAnswer) {
            if (!letter.Equals(' ') && !letter.Equals('\r')) AllCharacters.Add(letter);
        }

        do {
            int i;
            i = Random.Range(0, AllCharacters.Count);

            tempObj = Instantiate(KeyPrefab);
            tempObj.transform.SetParent(KeysContainer.transform);
            tempObj.transform.localScale = Vector3.one;
            tempObj.GetComponent<keyButtonScript>().Letter = AllCharacters[i];
            ///tempObj.GetComponentInChildren<Text>().text = AllCharacters[i].ToString();

            AllCharacters.RemoveAt(i);
        } while (AllCharacters.Count != 0);
    }
}
