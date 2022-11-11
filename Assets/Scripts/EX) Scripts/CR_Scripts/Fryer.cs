using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fryer : MonoBehaviour
{
    // 회전 속도
    public float rotSpeed;
    // 기름
    public GameObject oil;

    // 기름 색 변수
    public Renderer oilcolor;

    // 치킨 색 바꾸기
    public Renderer ck1color;
    public Renderer ck2color;
    public Renderer ck3color;

    // 치킨 익은 거 있는 스트립트 변수
    ChickenTrigger ct1;
    ChickenTrigger ct2;
    ChickenTrigger ct3;


    // 매니저 오브젝트
    public GameObject manager;

    // 치킨 조각
    public GameObject ck1;
    public GameObject ck2;
    public GameObject ck3;

    // 치킨 좌표
    public GameObject ck1pos;
    public GameObject ck2pos;
    public GameObject ck3pos;

    // 그릇에서 튀김기로 이동하는 좌표
    public GameObject oilck1Pos;
    public GameObject oilck2Pos;
    public GameObject oilck3Pos;
    // 치킨 
    public GameObject chicken;

    // 치킨 다 만들고 튀김기 없앨 때 체크하는 변수
    public bool isck1 = true;
    public bool isck2 = true;
    public bool isck3 = true;

    // 치킨 태울 때 체크하는 변수
    public bool isckk1 = false;
    public bool isckk2 = false;
    public bool isckk3 = false;

    // 뭐냐 이건... 어쨋든 뭐 체크하는 변수임
    public bool isMoveCk1 = true;
    public bool isMoveCk2 = true;
    public bool isMoveCk3 = true;

    // 튀김기 오브젝트
    public GameObject fiyer;
    public GameObject BtnCube;

    // 시간 변수
    float curTime;
    public float curTime1;

    // 튀김기 버튼 오브젝트
    public GameObject btn;
    // 양념 볼 오브젝트
    public GameObject ckBoll;
    public GameObject cube;
    // 볼 체크 변수
    public bool isbollCheck = true;
    // 점수 한 번만 깎이게
    public bool is1Score = true;
    public bool is2Score = true;

    public bool isAllScore = true;
    public int ckCount = 0;
    public int count = 0;

    //접시에 있는상태면 true, 기름에 있는상태면 false
    public bool[] moveCKcheck = new bool[3];

    // Start is called before the first frame update
    void Start()
    {
        // 기름 못 누르게 막아두기
        cube.SetActive(true);
        print("튀김기 180도로 예열하기");
        // 기름 오브젝트에서 렌더러 찾아오기
        oilcolor = oil.GetComponent<Renderer>();

        // 치킨 오브젝트에서 렌더러 찾아오기
        ck1color = ck1.transform.GetChild(0).GetComponent<Renderer>();
        ck2color = ck2.transform.GetChild(0).GetComponent<Renderer>();
        ck3color = ck3.transform.GetChild(0).GetComponent<Renderer>();

        // 치킨 색 변하는 스크립트 담기(치킨 익은 거)
        ct1 = ck1.GetComponent<ChickenTrigger>();
        ct2 = ck2.GetComponent<ChickenTrigger>();
        ct3 = ck3.GetComponent<ChickenTrigger>();

        // 매니저 오브젝트 안에 있는 MIX 스크립트 끄기
        manager.GetComponent<Mix>().enabled = false;

        for (int i = 0; i < moveCKcheck.Length; i++)
        {
            //치킨 현재 모두 접시에 담겨있는 채로 시작
            moveCKcheck[i] = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
     




        // 카메라 위치에서 레이 쏘기
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        // 만약 마우스 왼쪽 클릭을 했을 때
        if (Input.GetMouseButtonDown(0))
        {
            // 레이를 쐈을 때
            if (Physics.Raycast(ray, out hit))
            {
                // 레이의 끝에 닿은 오브젝트의 태그가 Btn이라면
                if (hit.transform.gameObject.tag == "Btn")
                {
                    count++;
                    // 버튼 회전 
                    if (count == 1)
                    {
                        btn.transform.rotation = Quaternion.Euler(-30f, 0, 0);
                        print("120도");
                    }

                    if (count == 2)
                    {
                        btn.transform.rotation = Quaternion.Euler(-60, 0, 0);
                        print("140도");
                    }

                    if (count == 3)
                    {
                        btn.transform.rotation = Quaternion.Euler(-90, 0, 0);
                        print("180도");
                    }

                    print("예열 완료");
                    // 러프타임 코루틴 실행
                    StartCoroutine(LerpTime());

                }
                // 레이의 끝에 닿은 오브젝트의 태그가 Oil이라면
                else if (hit.transform.gameObject.tag == "Oil")
                {
                    BtnCube.SetActive(true);
                    // 치킨 오브젝트 활성화
                    chicken.SetActive(true);
                    print("조각을 클릭해서 튀김기에 넣으세요");

                    if (count == 1)
                    {
                        print("감점");

                        // 점수 한 번만 감점되게
                        if (is1Score == true)
                        {
                            ScoreManager.instance.GetScore();
                            is1Score = false;
                        }
                    }

                    if (count == 2)
                    {
                        print("감점");
                        if (is2Score == true)
                        {
                            ScoreManager.instance.GetScore();
                            is2Score = false;
                        }

                    }

                    if (count == 3)
                    {
                        print("통과");
                    }

                }

                // 치킨 조각 클릭해서 넣기 == 좌표 값 바꿔주기
                else if (hit.transform.gameObject.tag == "ck1")
                {
                    if (moveCKcheck[0] == true)
                    { //눌렀을때 누르기전 상태가 접시위에 있는 상태였다Vector3면
                        ck1.transform.position = oilck1Pos.transform.position;
                        moveCKcheck[0] = false; //치킨의 상태는 기름으로 이동되었음
                        isck1 = false;
                    }
                    else if (moveCKcheck[0] == false && isck1 == false && isMoveCk1 == true)
                    {
                        //눌렀을때 누르기전 상태가 기름에 있는 상태였다면
                        ck1.transform.position = ck1pos.transform.position;
                        //접시로 이동
                       
                        isckk1 = false;
                        isMoveCk1 = false;
                        StopCoroutine(ct1.CkStop());
                    }

                }

                else if (hit.transform.gameObject.tag == "ck2")
                {
                    if (moveCKcheck[1] == true)
                    {
                        ck2.transform.position = oilck2Pos.transform.position;
                        moveCKcheck[1] = false;
                        isck2 = false;
                    }
                    else if (moveCKcheck[1] == false && isck2 == false && isMoveCk2 == true)
                    {
                        ck2.transform.position = ck2pos.transform.position;
                       
                        isckk2 = false;
                        isMoveCk2 = false;
                        StopCoroutine(ct2.CkStop());
                    }

                }
                else if (hit.transform.gameObject.tag == "ck3")
                {
                    if (moveCKcheck[2] == true)
                    {
                        ck3.transform.position = oilck3Pos.transform.position;
                        moveCKcheck[2] = false;
                         isck3 = false;
                    }
                    else if (moveCKcheck[2] == false && isck3 == false && isMoveCk3 == true)
                    {
                        ck3.transform.position = ck3pos.transform.position;
                       
                        isckk3 = false;
                        isMoveCk3 = false;
                        StopCoroutine(ct3.CkStop());
                    }
                }

                // 볼 체크 변수가 켜져있다면
                if (isbollCheck == true)
                {
                    // 만약 힛에 닿은 태그가 ck이고(그릇) 튀김기에 치킨이 없다면 
                    if (hit.transform.gameObject.tag == "ck" && isck1 == false && isck2 == false && isck3 == false)
                    {
                        // 치킨 그릇 끄기
                        chicken.SetActive(false);
                        // 튀김기 끄기
                        fiyer.SetActive(false);
                        // 양념 볼이랑 치킨 그릇 나오기
                        StartCoroutine(ckBollTime());

                        // 치킨 트리거 스크립트 다 끄기
                        ck1.GetComponent<ChickenTrigger>().enabled = false;
                        ck2.GetComponent<ChickenTrigger>().enabled = false;
                        ck3.GetComponent<ChickenTrigger>().enabled = false;

                        // 매니저 오브젝트 안에 있는 Mix 스크립트 키기
                        manager.GetComponent<Mix>().enabled = true;
                        // 매니저 오브젝트 안에 있는 Fryer 스크립트 끄기
                        manager.GetComponent<Fryer>().enabled = false;

                        // GetComponent<Fryer>().enabled = false;
                        // 볼 체크 변수 꺼 주기
                        isbollCheck = false;
                    }
                }

            }
        }
    }


    // 버튼 회전 코루틴
    IEnumerator LerpTime()
    {  // 기름 색 바꾸기
        oilcolor.material.color = new Color(1, 0.71f, 0, 1);
        print("닭 튀길 준비 완료 기름 클릭하기");
        // 기름 누를 수 있게 하기
        cube.SetActive(false);

        yield return null;

    }


    IEnumerator ckBollTime()
    {
        // 2초 뒤에
        yield return new WaitForSeconds(2);
        // 양념 볼 그릇 켜 주기
        ckBoll.SetActive(true);
        // 치킨 그릇 켜 주기
        chicken.SetActive(true);
        yield return null;
    }
}

