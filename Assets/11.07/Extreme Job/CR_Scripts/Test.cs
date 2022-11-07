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
                    }

                    // 치킨 카운트가 1이고 치킨 1이라는 텍스트가 떠 있다면
                    if (CounterTrigger.count == 1 && customerTxt.text == "치킨 1")
                    {
                        StartCoroutine(AnimTime());
                       
                        print("감사합니다");
                        customerTxt.text = "";
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

                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
                    }

                    // 치킨 카운트가 1이고 치킨 1이라는 텍스트가 떠 있다면
                    if (CounterTrigger.count == 2 && customerTxt.text == "치킨 2")
                    {
                        StartCoroutine(AnimTime());
                        print("감사합니다");
                        customerTxt.text = "";
                        isCustomer = true;
                        anim.SetTrigger("Greetings");
                        CounterTrigger.count = 0;
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
                    }


                    if (CounterTrigger.count == 1 && customerTxt.text == "치킨 3")
                    {
                        print("두 개 더 남았듬");
                        ck.SetActive(false);
                       
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
                    }

                    if (CounterTrigger.count == 2 && customerTxt.text == "치킨 3")
                    {
                        print("하나 더 남았음");
                        ck.SetActive(false);

                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
                    }


                    // 치킨 카운트가 1이고 치킨 1이라는 텍스트가 떠 있다면
                    if (CounterTrigger.count == 3 && customerTxt.text == "치킨 3")
                    {
                        StartCoroutine(AnimTime());
                        print("감사합니다");
                        customerTxt.text = "";
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
        }

        if (customerText[rand] == "치킨 두 마리 주세요")
        {
            customerTxt.text = "치킨 2";
        }

        if (customerText[rand] == "치킨 세 마리 주세요")
        {
            customerTxt.text = "치킨 3";
        }
    }
    
    IEnumerator AnimTime()
    {
        anim.SetTrigger("Greetings");
        yield return new WaitForSeconds(2f);
        // 손님 끄기
        customer.SetActive(false);
        ck.SetActive(false);
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
}
