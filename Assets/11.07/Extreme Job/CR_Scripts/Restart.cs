using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 게임 다시 시작
public class Restart : MonoBehaviour
{
    public Button restartBtn;
    ScoreManager scoreManager;
    public GameObject scoreObj;
    public GameObject gameOverImg;

    // Start is called before the first frame update
    void Start()
    {
        restartBtn.onClick.AddListener(ReStart);

        scoreManager = scoreObj.GetComponent<ScoreManager>();
    }

    void ReStart()
    {
        SceneManager.LoadScene("FinalGameScene");
        gameOverImg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        gameOver();
    }

    void gameOver()
    {
        if (scoreManager.Maxscore == 0)
        {
            gameOverImg.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
