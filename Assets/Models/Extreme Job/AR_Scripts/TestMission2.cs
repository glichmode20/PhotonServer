using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. ������ ���� ���� �ҽ� �ױ�

public class TestMission2 : MonoBehaviour
{
    public float amount = 0.5f;
    public float currentTime;
    public bool isCheck = false;
    public bool isOne = false;

    // Start is called before the first frame update
    void Start()
    {

        transform.GetComponent<Renderer>().material.shader = Shader.Find("BitshiftProgrammer/Liquid");
        float f = transform.GetComponent<Renderer>().material.GetFloat("_FillAmount");
        // transform.GetComponent<Renderer>().material.SetFloat("_FillAmount", 1f);

    }




#region One

   public void MissionOne()
    {

        // ������ ��
        if (Input.GetKeyDown(KeyCode.K))
        {
            // �������� Ȯ��
            if (isCheck == true)
            {
                isCheck = false;   
            }
            // �� ���� ������ �� false�� ���ư�
            else if (isCheck == false)
            {
                isCheck = true;
            }

        }

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


    public void fill()
    {
        // 0.01 �� �������� �Ѵ�
        amount -= 0.01f;

        transform.GetComponent<Renderer>().material.SetFloat("_FillAmount", amount);

    }

    public void notFill()
    {
        transform.GetComponent<Renderer>().material.SetFloat("_FillAmount", 0.35f);
    }

    #endregion


  


}