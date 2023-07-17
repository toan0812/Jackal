using TMPro;
using UnityEngine;

public class UIManager : JackalMono
{
    public static UIManager Instance { get; private set; }
    [SerializeField]public TextMeshProUGUI PlayerLiveText;
    [SerializeField]public TextMeshProUGUI PlayerScoreText;
    [SerializeField]public float Score =0;
    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }
    public void UpdateScore(int score)
    {
        this.Score += score;
        PlayerScoreText.text = "" + string.Format("{0:000000}", Score);
    }

}
