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
public class sfxVolumeButtonScript : MonoBehaviour {
    Toggle toggle;
    AudioSource sfx;
    void Awake() {
        sfx = GameObject.Find("Correct and Wrong").GetComponent<AudioSource>();
        toggle = gameObject.GetComponent<Toggle>();

        toggle.isOn = PlayerPrefs.GetInt("SFX")==0 ? true : false;
        toggle.onValueChanged.AddListener(btnSFX);
    }
    public void btnSFX(bool value) {
        if (value == false) {
            sfx.mute = true;
            PlayerPrefs.SetInt("SFX", 1);
        }
        else {
            PlayerPrefs.SetInt("SFX", 0);
            sfx.mute = false;
        }
        PlayerPrefs.Save();
    }
}
