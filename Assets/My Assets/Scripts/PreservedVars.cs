using UnityEngine;
using System.Collections;
/// <summary>
/// This thing cheats a bit the loader because the main menu script dont support bypassing the first view
/// </summary>
public class PreservedVars : MonoBehaviour {
    // condition to show the very start ... it fixes the back button on ingame going to start instead of map
    public bool showPlay = false; 
}
