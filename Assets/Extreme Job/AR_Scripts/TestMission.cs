using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. ������ ���� ���� ���� �ױ�

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

        // ������ ��
        if (Input.GetKeyDown(KeyCode.K))
        {
            // �������� Ȯ��
            if (isCheck == true && count < maxcount)
            {
                if (amount > 0.6 && amount < 0.65)
                {
                    print("���");
                }
                else
                {
                    print("����");

                    // ���� ����
                    ScoreManager.instance.GetOtherScore();
                }

                count++;

                isCheck = false;

            }
            // �� ���� ������ �� false�� ���ư�
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
        // ���� �����ٸ�
        if (isCheck == true)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= 0.1f)
            {
                // ��������
                fill();

                // �ð� �ʱ�ȭ
                currentTime = 0;
            }
        }
    }


    void fill()
    {
        // �ִ� 0.48f ����
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