using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader
{
   public enum scene
    {
        MainScene,
        GameScene,
        LoadingScene,
        FinishScene
    }
    private static scene tagetScene;
    public static void Load(scene tagetStringScene)
    {
        Loader.tagetScene = tagetStringScene;
        SceneManager.LoadScene(Loader.scene.LoadingScene.ToString());
    }

    public static void LoaderCallBack()
    {
        SceneManager.LoadScene(tagetScene.ToString());
    }
    
}
