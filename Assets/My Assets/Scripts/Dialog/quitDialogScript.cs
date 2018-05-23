using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// This Script is for this particular prefab only
/// </summary>
public class quitDialogScript : MonoBehaviour {
    public IngameUiHandlerScript uHandler;  // well disable it on show, also this is set by the caller
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void btnQuitToMenu() {
        SceneManager.LoadScene("Start Scene");
    }

    public void btnQuit() {
        Application.Quit();
    }
    public void btnCancel() {
        uHandler.isPaused = false;
        Destroy(gameObject);
    }
}
