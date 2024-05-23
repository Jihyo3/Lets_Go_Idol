using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    public static BestScore instance;   
    [SerializeField] private Text ScoreNow;
    [SerializeField] private Text ScoreBest;
    private string id;


    void Start()
    {
        id = ScoreManager.instance.id;
        float currentScore = ScoreManager.instance.score; // 현재 스코어 점수를 받아온뒤 currentScore 값에 저장한다.
        string bestScore = "" + id; //최고 점수를 기록해두기위한 string
        ScoreNow.text = ScoreManager.instance.score.ToString("N2"); // 현재 점수값을 받아온뒤 text 에 기입한다.

        if (PlayerPrefs.HasKey(bestScore)) // 만약 플레이어 최고값이 있을시 실행
        {
            float score = PlayerPrefs.GetFloat(bestScore);

            if (score < currentScore)
            {
                PlayerPrefs.SetFloat(bestScore, currentScore);
                ScoreBest.text = currentScore.ToString("N2");
            }
            else
            {
                ScoreBest.text = score.ToString("N2");
            }
        }
        else // 플레이어 최고값이 없을시 실행.
        {
            PlayerPrefs.SetFloat(bestScore, currentScore); // 현재 스코어를 최고스코어로 저장한다.
            ScoreBest.text = currentScore.ToString("N2"); // 현재스코어를 최고 스코어로 출력한다.
        }
    }

    
}
