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

public class correcAndWrongSoundScript : MonoBehaviour {
    public AudioClip Correct;
    public AudioClip Wrong;
	void Start () {
        if (PlayerPrefs.GetInt("SFX") == 1) {
            GetComponent<AudioSource>().mute = true;
            // image is modified on script attached to the button
        }
    }
    public void playSound(bool isCorrect) {
        if (isCorrect == true) {
            gameObject.GetComponent<AudioSource>().clip = Correct;
            
        }
        else{
            gameObject.GetComponent<AudioSource>().clip = Wrong;
        }
        gameObject.GetComponent<AudioSource>().Play();
    }
}
