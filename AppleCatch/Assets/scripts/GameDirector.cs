using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameDirector : MonoBehaviour
{
    [SerializeField]
    private Text txtTime;
    [SerializeField]
    private Text txtScore;

    private float time = 60.0f;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.UpdateScoreUI();
    }

    // Update is called once per frame
    void Update()

    {
        this.time -= Time.deltaTime;
        this.txtTime.text = this.time.ToString("F1");//소수점 1자리까지 표시
    }
    public void UpdateScoreUI()
    {
        this.txtScore.text = string.Format("{0} Point", score);
    }
    public void IncreaseScore(int score)
    {
        this.score += score;
        this.UpdateScoreUI();
    }
    public void DecreaseScore(int score)
    {
        this.score -= score;
        this.UpdateScoreUI();
    }
}
