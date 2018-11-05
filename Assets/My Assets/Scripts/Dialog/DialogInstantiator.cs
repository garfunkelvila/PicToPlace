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

public class DialogInstantiator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void InstantiateDialog(GameObject dialog) {
        GameObject temp;

        temp = Instantiate(dialog);
        temp.transform.SetParent(GameObject.Find("Canvas").transform);
        temp.transform.localPosition = Vector3.zero;
        temp.transform.localScale = Vector3.one;
        temp.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        //Destroy(gameObject);
    }
}
