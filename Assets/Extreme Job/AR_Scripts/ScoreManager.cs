using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // 현재 점수는 100이다
    // 만약 플레이어가 잘못된 레시피를 만들경우
    // -20씩 깎는다


    public static ScoreManager instance;
    public Text CurScoreUI;
    public int Maxscore = 100;

    private void Awake()
    {
        instance = this;
    }

    public int CurScore
    {
        get
        {
            return Maxscore;
        }
        set
        {
            Maxscore = value;


            CurScoreUI.text = "치킨 완성도 : " + CurScore + "";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CurScore = Maxscore;

    }

 

    public void GetScore()
    {
        CurScore = CurScore - 20;

    }
    public void GetOtherScore()
    {
        CurScore = CurScore - 10;

    }


}
