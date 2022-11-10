using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 게임 다시 시작
public class Restart : MonoBehaviour
{
    public Button restartBtn;
    public Button ClearBtn;
    ScoreManager scoreManager;

    E_GameManager EManager;

    public GameObject scoreObj;
    public GameObject gameOverImg;
    public GameObject gameSucessImg;

    public VideoPlayer Ending;
    public GameObject EndingVideo;

    // Start is called before the first frame update
    void Start()
    {
        restartBtn.onClick.AddListener(ReStart);

        ClearBtn.onClick.AddListener(EndMovie);

        scoreManager = scoreObj.GetComponent<ScoreManager>();

        EManager = GetComponent<E_GameManager>();

        Ending.loopPointReached += CheckVideoTime;

    }

    void ReStart()
    {
        SceneManager.LoadScene("FinalGameScene");
        gameOverImg.SetActive(false);
    }

    void EndMovie()
    {
        Debug.Log("비디오 실행");
        Ending.Play();

        EndingVideo.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        gameOver();
        gameClear();
    }

    void gameOver()
    {
        if (scoreManager.Maxscore == 0)
        {
            gameOverImg.SetActive(true);
            Time.timeScale = 0;
        }
    }



    void gameClear()
    {
        if (scoreManager.Maxscore >= 80 && EManager.min == 0 && EManager.sec == 0)
        {
            gameSucessImg.SetActive(true);
            Time.timeScale = 0;
        }

    }

    void CheckVideoTime(UnityEngine.Video.VideoPlayer vp)
    {
        print("비디오 끝");
        EManager.isCheck = true;
    }

}
