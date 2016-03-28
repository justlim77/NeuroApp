using UnityEngine;
using System.Collections;

[System.Serializable]
public class InputManager : Singleton<InputManager> {

    // Set to protected to prevent calling constructor
    protected InputManager() { }

    public KeyCode restartKey;
    public KeyCode quitKey;
}
