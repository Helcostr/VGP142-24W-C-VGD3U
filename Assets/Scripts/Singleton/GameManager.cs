using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleoton<GameManager> {
    protected override void Awake() {
        base.Awake();
    }
    public void Cancel() {
        Quit();
    }
    public void Finish() {
        Quit();
    }
    private void Quit() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}