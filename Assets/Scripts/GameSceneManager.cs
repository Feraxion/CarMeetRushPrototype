using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameSceneManager {

    public enum Scene {
        Level1,
        Level2,
        Level3,
    }

    public static void Load(Scene scene) {
        SceneManager.LoadScene(scene.ToString());
    }

}