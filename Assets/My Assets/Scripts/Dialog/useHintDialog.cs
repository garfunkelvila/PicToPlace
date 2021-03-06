﻿//  Copyright (C) 2017  Garfunkel Vila
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
using System.Collections.Generic;
using UnityEngine.UI;
public class useHintDialog : MonoBehaviour {
    public questionaireHandler qHandler;
    public Button okButton;
    public Text message;

    public int hintCost = 0;
	// Use this for initialization
	void Awake () {
        // check for coins
        qHandler = GameObject.Find("logicHandler").GetComponent<questionaireHandler>();
        if (PlayerPrefs.GetInt("Coins") >= hintCost) {
            message.text = "Use hint?\nUsing hint will show a correct letter\nThat will be 2 coins.";
            okButton.interactable = true;
        }
        else {
            message.text = "You do not have enought coins\nUsing hint needs at least 2 coins";
            okButton.interactable = false;
        }
    }

    public void btnOk() {
        // decrease coin
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 2);
        GameObject.Find("Coins").GetComponentInChildren<Text>().text = PlayerPrefs.GetInt("Coins").ToString();

        // the more the letter the more chance it will be choosen as one letter can be inserted on the list multiple times

        // get the unanswered letters from the array of blanks in the qhandler
        List<char> unanswered = new List<char>();
        GameObject[] btn;
        char selectedChar;

        foreach (GameObject item in qHandler.blanks) {
            if (item.GetComponent<blankScript>().isAnswered == false) {
                unanswered.Add(item.GetComponent<blankScript>().assignedLetter);
            }
        }
        // after getting the unanswered lettes
        // randomly select a character
        selectedChar = unanswered[Random.Range(0, unanswered.Count)];
        // get the interactible blanks, find the matching generated randomly created character
        btn = GameObject.FindGameObjectsWithTag("Key");
        foreach (GameObject item in btn) {
            if (item.GetComponent<keyButtonScript>().Letter == selectedChar) {
                // execute the click function for that particular button
                item.GetComponent<keyButtonScript>().btnPressed();
            }
        }
        Destroy(gameObject);
    }
    public void btnCancel() {
        Destroy(gameObject);
    }
}
