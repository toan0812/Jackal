using UnityEngine.UI;
using UnityEngine;

public class RestartUI : MonoBehaviour
{
    [SerializeField] private Button Yes;
    [SerializeField] private Button No;

    private void Awake()
    {
        Yes.onClick.AddListener(() =>
        {
            Loader.Load(Loader.scene.GameScene);
        });
        No.onClick.AddListener(() =>
        {
            Loader.Load(Loader.scene.MainScene);
        });

    }
}
