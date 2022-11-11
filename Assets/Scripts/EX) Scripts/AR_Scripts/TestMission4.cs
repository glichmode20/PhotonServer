using UnityEngine;

// 1. 정해진 선에 맞춰 우유 붓기

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

        // 눌렀을 때
        if (Input.GetKeyDown(KeyCode.K))
        {
            // 눌렀음을 확인
            if (isCheck == true)
            {
                // 만약 물 / 반죽 각각 한번씩만 클릭가능 하게
                count++;

                isCheck = false;
            
               
            }
            // 한 번더 눌렀을 시 false로 돌아감
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
    
 
    public void fill()
    {
        // 0.01 씩 차오르게 한다
        amount -= 0.01f;

        transform.GetComponent<Renderer>().material.SetFloat("_FillAmount", amount);
    }

    
   

    #endregion


}