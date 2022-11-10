using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerUI : MonoBehaviour
{
    // 손님
    public GameObject customer;
    // customerUI 오브젝트
    public GameObject customerUI;
    // 우측 상단 손님 문구 가져오는 변수
    public GameObject customerUIText;

    public GameObject ck;

    // 손님 텍스트
    Text customerText;

    // 손님 색
    Renderer curstomerColor;
    // Start is called before the first frame update
    void Start()
    {
        // 손님 나오는 코루틴 실행
        StartCoroutine(CustomerTime());
        // 캔버스에서 텍스트 찾기
        customerUIText = customerUI.transform.GetChild(0).gameObject;
        // customerUI에 있는 텍스트 불러오기
        customerText = customerUIText.GetComponent<Text>();
        // 손님 색 불러오기
        curstomerColor = customer.GetComponent<Renderer>();
    }

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
                    print("치킨 한 마리 주세요");

                    // 원래 손님 왔음이란 텍스트를 치킨 1로 바꾸기
                    customerText.text = "치킨 한 마리 주세요";

                    TextPlay();
                }
            }
        }
    }
    IEnumerator CustomerTime()
    {
        // 2초 뒤에
        yield return new WaitForSeconds(2f);
        // 손님 켜지기
        customer.SetActive(true);
    }

    void TextPlay()
    {
        // 치킨 카운트가 1이고 치킨 1이라는 텍스트가 떠 있다면
        if (CounterTrigger.count == 1 && customerText.text == "치킨 한 마리 주세요")
        {
            // 손님 끄기
            customer.SetActive(false);
            ck.SetActive(false);
            print("감사합니다");
            customerText.text = "";
            GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
            GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
        }
       
        // 치킨 카운트가 1보다 크고 치킨 1이라는 텍스트가 떠 있다면
        else if (CounterTrigger.count > 1 && customerText.text == "치킨 한 마리 주세요")
        {
            print("이거 아니잖아요!");
            ck.SetActive(false);
            customer.SetActive(false);
            // 손님 색 바뀌기(화내기)
            curstomerColor.material.color = new Color(1, 0, 0, 1);
            GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
            GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
        }

    }
}


