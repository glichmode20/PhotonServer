using UnityEngine;

// 1. ������ ���� ���� ���� �ױ�

public class TestMission4 : MonoBehaviour
{
    public float amount = 0.7f;
    public float currentTime;
    public float currentTime1;
    public bool isCheck = false;
    public bool isChecked = false;

    public int count = 0;
    int maxcount = 1;    
    

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
                // ���� �� / ���� ���� �ѹ����� Ŭ������ �ϰ�
                count++;

                isCheck = false;
            
               
            }
            // �� ���� ������ �� false�� ���ư�
            else if (isCheck == false)
            {
                isCheck = true;
                count = 0;
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

    
   

    #endregion


}