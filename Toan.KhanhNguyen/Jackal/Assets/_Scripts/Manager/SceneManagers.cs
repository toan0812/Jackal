using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{
    [SerializeField] private Button StartPlayer;

    private void Awake()
    {
        StartPlayer.onClick.AddListener(() =>
        {
            Loader.Load(Loader.scene.GameScene);
        });
        Time.timeScale = 1f;
    }
}
