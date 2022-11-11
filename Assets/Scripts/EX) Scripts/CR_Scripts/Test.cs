using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public List<string> customerText = new List<string>() { "치킨 한 마리 주세요", "치킨 두 마리 주세요", "치킨 세 마리 주세요" };
    public GameObject customerUI;
    // 우측 상단 손님 문구 가져오는 변수
    public GameObject customerUIText;

    public GameObject UIChicken1;
    public GameObject UIChicken2;
    public GameObject UIChicken3;    
    
    public GameObject UIChickenbg1;
    public GameObject UIChickenbg2;
    public GameObject UIChickenbg3;

    public GameObject customer;
    public GameObject ck;
    public Animator anim;

    Text customerTxt;
    
    // 손님 색
    Renderer curstomerColor;
    // Start is called before the first frame update
    void Start()
    {
        // 캔버스에서 텍스트 찾기
        customerUIText = customerUI.transform.GetChild(0).gameObject;
        // customerUI에 있는 텍스트 불러오기
        customerTxt = customerUIText.GetComponent<Text>();
        // 손님 색 불러오기
        curstomerColor = customer.GetComponent<Renderer>();
        
    }

    bool isCustomer = true;

   
    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        // 만약 마우스 왼쪽 클릭을 했을 때
        if (Input.GetMouseButtonDown(0))
        {
            // 레이를 쐈을 때
            if (Physics.Raycast(ray, out hit))
            {
                // 레이의 끝에 닿은 오브젝트의 태그가 Customer라면
                if (hit.transform.gameObject.tag == "Customer")
                {
                    if(isCustomer == true)
                    {
                        CustomerText();
                        isCustomer = false;
                        // 손님 대화창 켜기
                        customerUI.SetActive(true);
                        // 대화창 끄기
                        Invoke("invokeUI", 3f);
                    }

                    // 치킨 카운트가 1이고 치킨 1이라는 텍스트가 떠 있다면
                    if (CounterTrigger.count == 1 && customerTxt.text == "치킨 1")
                    {
                        StartCoroutine(AnimTime());

                        // 손님 대화창 켜기
                        customerUI.SetActive(true);
                        // 대화창 끄기
                        Invoke("invokeUI", 3f);

                        // 치킨 카운트가 1이 되면 켜기
                        if(CounterTrigger.count == 1)
                        {
                            UIChicken1.SetActive(true);
                        }
                        
                  
                        print("감사합니다");
                        customerTxt.text = "감사합니다";
                        isCustomer = true;
                        CounterTrigger.count = 0;
                        print(CounterTrigger.count + "치킨 카운트 초기화 했는지");
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
                    }

                    if (CounterTrigger.count == 1 && customerTxt.text == "치킨 2")
                    {
                        print("하나 더 남았듬");
                        ck.SetActive(false);

                        // 치킨 카운트가 1이 되면 UIChicken1 켜기
                        if (CounterTrigger.count == 1)
                        {
                            UIChicken1.SetActive(true);
                        }
              

                      
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
                    }

                    // 치킨 카운트가 1이고 치킨 1이라는 텍스트가 떠 있다면
                    if (CounterTrigger.count == 2 && customerTxt.text == "치킨 2")
                    {
                        StartCoroutine(AnimTime());

                        // 치킨 카운트가 1이면 UIChicken1 켜기
                        if (CounterTrigger.count == 1)
                        {
                            UIChicken1.SetActive(true);
                        }
  
                        // 치킨 카운트가 2이면 UIChicken2 켜기
                        if (CounterTrigger.count == 2)
                        {
                            UIChicken2.SetActive(true);
                        }
    
                    

                        // 손님 대화창 켜기
                        customerUI.SetActive(true);
                        // 대화창 끄기
                        Invoke("invokeUI", 3f);

                        print("감사합니다");
                        customerTxt.text = "감사합니다";
                        isCustomer = true;
                        anim.SetTrigger("Greetings");
                        CounterTrigger.count = 0;
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
                    }


                    if (CounterTrigger.count == 1 && customerTxt.text == "치킨 3")
                    {
                        // 치킨 카운트가 1이면 UIChicken1 켜기
                        if (CounterTrigger.count == 1)
                        {
                            UIChicken1.SetActive(true);
                        }


                        print("두 개 더 남았듬");
                        ck.SetActive(false);
                       
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
                    }

                    if (CounterTrigger.count == 2 && customerTxt.text == "치킨 3")
                    {

                        // 치킨 카운트가 2이면 UIChicken2 켜기
                        if (CounterTrigger.count == 2)
                        {
                            UIChicken2.SetActive(true);
                        }



                        print("하나 더 남았음");
                        ck.SetActive(false);

                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
                    }


                    // 치킨 카운트가 1이고 치킨 1이라는 텍스트가 떠 있다면
                    if (CounterTrigger.count == 3 && customerTxt.text == "치킨 3")
                    {
                        StartCoroutine(AnimTime());

                        
                        // 치킨 카운트가 3이면 UIChicken3 켜기
                        if (CounterTrigger.count == 3)
                        {
                            UIChicken3.SetActive(true);
                        }


                        // 손님 대화창 켜기
                        customerUI.SetActive(true);
                        // 대화창 끄기
                        Invoke("invokeUI", 3f);

                        print("감사합니다");
                        customerTxt.text = "감사합니다";
                        isCustomer = true;
                        CounterTrigger.count = 0;
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
                    }
                }
            }
        }

        StartCoroutine(CustomerTime());
    }

    public void CustomerText()
    {
        int rand = Random.Range(0, customerText.Count);
        print(customerText[rand]);

        if(customerText[rand] == "치킨 한 마리 주세요")
        {
            customerTxt.text = "치킨 1";

            UIChickenbg1.SetActive(true);
        }

        if (customerText[rand] == "치킨 두 마리 주세요")
        {
            customerTxt.text = "치킨 2";

            UIChickenbg1.SetActive(true);
            UIChickenbg2.SetActive(true);
        }

        if (customerText[rand] == "치킨 세 마리 주세요")
        {
            customerTxt.text = "치킨 3";

            UIChickenbg1.SetActive(true);
            UIChickenbg2.SetActive(true);
            UIChickenbg3.SetActive(true);
        }
    }
    
    IEnumerator AnimTime()
    {
        anim.SetTrigger("Greetings");
        yield return new WaitForSeconds(2f);
        // 손님 끄기
        customer.SetActive(false);
        ck.SetActive(false);

        // UI 끄기(빨간 불)
        UIChicken1.SetActive(false);
        UIChicken2.SetActive(false);
        UIChicken3.SetActive(false);

        // UI 끄기(검은 불)
        UIChickenbg1.SetActive(false);
        UIChickenbg2.SetActive(false);
        UIChickenbg3.SetActive(false);
    }
    
    IEnumerator CustomerTime()
    {
        if(customer.activeSelf == false)
        {
            // 2초 뒤에
            yield return new WaitForSeconds(2f);
            // 손님 켜지기
            customer.SetActive(true);

            //customerTxt.text = "손님 왔음";
        }
       
    }


    void invokeUI()
    {
        customerUI.SetActive(false);
    }
}
