using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class tryAgainScript : MonoBehaviour {
    public void tryAgainButton() {
        //Application.LoadLevel("Start Scene");
        SceneManager.LoadScene("Start Scene");
    }
}
