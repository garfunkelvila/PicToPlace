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
public class bgmVolumeButtonScript : MonoBehaviour {
    Toggle toggle;
    AudioSource bgm;
    void Awake() {
        bgm = GameObject.Find("BGM").GetComponent<AudioSource>();
        toggle = gameObject.GetComponent<Toggle>();

        toggle.isOn = PlayerPrefs.GetInt("BGM") == 0 ? true : false;
        toggle.onValueChanged.AddListener(btnBGM);
    }
    public void btnBGM(bool value) {
        if (value == false) {
            PlayerPrefs.SetInt("BGM", 1);
            bgm.mute = true;
        }
        else {
            PlayerPrefs.SetInt("BGM", 0);
            bgm.mute = false;
        }
        PlayerPrefs.Save();
    }
}
