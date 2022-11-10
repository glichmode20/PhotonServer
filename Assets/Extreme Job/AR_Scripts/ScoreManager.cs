using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // ���� ������ 100�̴�
    // ���� �÷��̾ �߸��� �����Ǹ� ������
    // -20�� ��´�


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


            CurScoreUI.text = "ġŲ �ϼ��� : " + CurScore + "";
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
