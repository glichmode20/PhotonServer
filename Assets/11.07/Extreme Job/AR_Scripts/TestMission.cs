using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. 정해진 선에 맞춰 우유 붓기

public class TestMission : MonoBehaviour
{
    
    float amount = 1f;
    public float currentTime;
    public bool isCheck = false;

    public int count = 0;
    int maxcount = 1;

    // Start is called before the first frame update
    void Start()
    {

        transform.GetComponent<Renderer>().material.shader = Shader.Find("BitshiftProgrammer/Liquid");
        float f = transform.GetComponent<Renderer>().material.GetFloat("_FillAmount");
        // transform.GetComponent<Renderer>().material.SetFloat("_FillAmount", 1f);

    }


    // Update is called once per frame
    void Update()
    {
        // StartCoroutine(ReChange());
       //  MissionOne();

    }




#region One

   public void MissionOne()
    {

        // 눌렀을 때
        if (Input.GetKeyDown(KeyCode.K))
        {
            // 눌렀음을 확인
            if (isCheck == true && count < maxcount)
            {
                if (amount > 0.6 && amount < 0.65)
                {
                    print("통과");
                }
                else
                {
                    print("불통");

                    // 점수 깎임
                    ScoreManager.instance.GetOtherScore();
                }

                count++;

                isCheck = false;

            }
            // 한 번더 눌렀을 시 false로 돌아감
            else if (isCheck == false && count < maxcount)
            {
                isCheck = true;

                count = 0;
            }
        }

        // StartCoroutine(fillTime());

        OnClickOne();
    }

    void OnClickOne()
    {
        // 만약 눌렀다면
        if (isCheck == true)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= 0.1f)
            {
                // 차오른다
                fill();

                // 시간 초기화
                currentTime = 0;
            }
        }
    }


    void fill()
    {
        // 최대 0.48f 까지
        if (amount > 0.48f)
        {
            amount -= 0.01f;

        }

        transform.GetComponent<Renderer>().material.SetFloat("_FillAmount", amount);
    }
       
    public void notfill()
    {
        transform.GetComponent<Renderer>().material.SetFloat("_FillAmount", 1);
    }


    #endregion



}