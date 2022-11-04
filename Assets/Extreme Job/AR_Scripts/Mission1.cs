using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission1 : MonoBehaviour
{
    [Header("물건 위치")]
    public GameObject position;
    public GameObject bowl;
    public GameObject water;
    public GameObject pot;

    [Header("소스 오브젝트")]
    public GameObject Soy;
    public GameObject Sugar;
    public GameObject Pepper;
    public GameObject Garlic;
    public GameObject Syrup;
    public GameObject Vinegar;
    public GameObject Chilli;
    public GameObject Liquid;
    public GameObject Powder;
    public GameObject Milk;

    [Header("오브젝트")]
    public GameObject potObject;
    public GameObject Source;

    [Header("설명 텍스트")]
    public Text itemName;
    public Text Menual;
    public Text Menual2;
    public Text Menual3;
    public Text Menual4;

    [Header("재료 이름 저장 배열")]
    // 소스
    public bool[] Ingredient = new bool[5];
    // 반죽
    public bool[] Dough = new bool[1];

    public bool isCheck = false;

    [Header("버튼 클릭 제한")]
    public int count = 0;
    int maxcount = 1;

    //스크립트 불러오기
    TestMission mission;
    TestMission2 mission2;
    TestMission3 mission3;
    TestMission4 mission4;
    MenualUI menual;

    Button button;

    // 잡힌 오브젝트
    public Transform grabbedObject = null;
    public Transform ChickenObject = null;
    // public Transform CKObject = null;



    // Start is called before the first frame update
    void Start()
    {
       
        mission3 = GameObject.Find("Water").GetComponentInChildren<TestMission3>();
        // ******** 태그를 바꿔줘야함 ***********
        button = GameObject.FindGameObjectWithTag("Button").GetComponent<Button>();
        menual = GameObject.Find("@Canvas").GetComponent<MenualUI>();

  
    }

    #region Finding
    public void FindBowl()
    {
        // 우유 찾기
        mission = GameObject.FindGameObjectWithTag("Bowl").GetComponentInChildren<TestMission>();
        // 반죽기 찾기
        mission4 = GameObject.FindGameObjectWithTag("Bowl").GetComponentInChildren<TestMission4>();
      
        // 볼 위치
        bowl = GameObject.FindGameObjectWithTag("BowlPos");
        print(bowl);
    }

    public void FindPot()
    {
        // 냄비 찾기
        mission2 = GameObject.FindGameObjectWithTag("Pot").GetComponentInChildren<TestMission2>();

        // 냄비 위치 (찾아서 삭제할 예정)
        potObject = GameObject.FindGameObjectWithTag("Pot");
    }

    public void FindSauce()
    {
        // 소스 오브젝트 찾기
        Soy = GameObject.FindGameObjectWithTag("Soy");
        Sugar = GameObject.FindGameObjectWithTag("Sugar");
        Pepper = GameObject.FindGameObjectWithTag("Pepper");
        Garlic = GameObject.FindGameObjectWithTag("Garlic");
        Syrup = GameObject.FindGameObjectWithTag("Syrup");
        Vinegar = GameObject.FindGameObjectWithTag("Vinegar");
        Chilli = GameObject.FindGameObjectWithTag("Chilli");
        Liquid = GameObject.FindGameObjectWithTag("Liquid");
        Powder = GameObject.FindGameObjectWithTag("Powder");
        Milk = GameObject.FindGameObjectWithTag("Milk");

    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        DropObject();
        CatchObject();
    }


    void CatchObject()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        int layer = 1 << LayerMask.NameToLayer("Item");

        if (Physics.Raycast(ray, out hit, 10, layer))
        {
            itemName.text = "정보 : " + hit.collider.name;
            //********* 메뉴 암기 **********
            //menual.leImage();

            #region Mission One

            // 눌렀을 때
            if (Input.GetButtonDown("Fire1"))
            {
                if (hit.transform.CompareTag("Chicken"))
                {
                    bowl = GameObject.FindGameObjectWithTag("BowlPos");
                    hit.transform.parent = bowl.transform;
                    hit.transform.SetAsFirstSibling();
                    //볼 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;


                    //다시 버튼태그를 원래대로 돌려 놓기
                    GameObject.FindGameObjectWithTag("Btn").tag = "FryerBtn";
                    GameObject.FindGameObjectWithTag("Oil").tag = "StartOil";
                    //grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                }

                if (hit.transform.CompareTag("OtherChicken"))
                {
                    // 물 안에 들어가게 한다
                    hit.transform.parent = water.transform;

                    hit.transform.SetAsFirstSibling();

                    hit.transform.localPosition = Vector3.zero;

                    // 닿은 물체 뭐인지 저장
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                }

                if (hit.transform.CompareTag("Bowl"))
                {
                    // 만약 볼 안에 치킨이란 태그가 달려있는 오브젝트가 있다면

                    hit.transform.parent = position.transform;

                    hit.transform.SetAsFirstSibling();

                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;

                    // 닿은 물체 뭐인지 저장
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                 
                }

                if (hit.transform.CompareTag("Milk"))
                {
                    Menual4.text = "K를 눌러 선에 맞춰 우유를 채우시오";

                    hit.transform.parent = position.transform;
                    hit.transform.SetAsFirstSibling();
                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;
                    // 들고 있는 물건 무엇인지 
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }

            }
            // 볼엔 치킨이 있고 손에 우유가 들자마자
            //if (position.transform.GetChild(0).CompareTag("Milk") && bowl.transform.GetChild(0).CompareTag("Chicken"))
            //{
            //    //GameObject.FindGameObjectWithTag("Chicken").transform.tag = "OtherChicken";

            //    //GameObject.FindGameObjectWithTag("Bowl").transform.tag = "OtherBowl";
            //}

            // 닿은 것이 볼이고 손엔 우유곽이 있다면
            if (hit.transform.CompareTag("Bowl") && position.transform.GetChild(0).CompareTag("Milk") && bowl.transform.GetChild(0).CompareTag("Chicken"))// grabbedObject.transform.CompareTag("Milk"))
            {
                // K를 눌러 실행하게 한다
                mission.MissionOne();

                //  GameObject.FindGameObjectWithTag("Chicken").transform.tag = "OtherChicken";

                // GameObject.FindGameObjectWithTag("Bowl").transform.tag = "OtherBowl";

                print("우유 넣기 실행 가능한 상태");
            }



            #endregion

            #region Mission Two
            if (Input.GetButtonDown("Fire1"))
            {
                if (hit.transform.CompareTag("Pot"))
                {
                    Menual.text = "K를 눌러 소스를 채우시오";
                    
                    hit.transform.parent = pot.transform;
                    // hit.transform.SetAsFirstSibling();
                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;
                    // 닿은 물체 뭐인지 저장
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                    GameObject.FindGameObjectWithTag("Button").transform.gameObject.tag = "TimeBtn";

                }

                if (hit.transform.CompareTag("OtherPot"))
                {
                    hit.transform.parent = position.transform;
                    // hit.transform.SetAsFirstSibling();
                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;
                    // 닿은 물체 뭐인지 저장
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;



                }

                if (hit.transform.CompareTag("Soy"))
                {
                    hit.transform.parent = position.transform;

                    hit.transform.SetAsFirstSibling();
                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;
                    // 닿은 물체 뭐인지 저장
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;


                }
                if (hit.transform.CompareTag("Sugar"))
                {

                    hit.transform.parent = position.transform;

                    hit.transform.SetAsFirstSibling();
                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;
                    // 닿은 물체 뭐인지 저장
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                }
                if (hit.transform.CompareTag("Pepper"))
                {

                    hit.transform.parent = position.transform;

                    hit.transform.SetAsFirstSibling();
                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;
                    // 닿은 물체 뭐인지 저장
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                }
                if (hit.transform.CompareTag("Garlic"))
                {
                    hit.transform.parent = position.transform;

                    hit.transform.SetAsFirstSibling();
                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;
                    // 닿은 물체 뭐인지 저장
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;


                }

                if (hit.transform.CompareTag("Syrup"))
                {
                    hit.transform.parent = position.transform;

                    hit.transform.SetAsFirstSibling();
                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;
                    // 닿은 물체 뭐인지 저장
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;


                }

                if (hit.transform.CompareTag("Vinegar"))
                {
                    hit.transform.parent = position.transform;

                    hit.transform.SetAsFirstSibling();
                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;
                    // 닿은 물체 뭐인지 저장
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }

                if (hit.transform.CompareTag("Chilli"))
                {
                    hit.transform.parent = position.transform;

                    hit.transform.SetAsFirstSibling();

                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;
                    // 닿은 물체 뭐인지 저장
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                }

                // 맞은 것이 Button 일때
                if (hit.transform.CompareTag("TimeBtn") && count < maxcount)
                {
                    #region 성공
                    count++;

                    if (Ingredient[0] && Ingredient[1] && Ingredient[2] && Ingredient[3] && Ingredient[4])
                    {
                        print("성공");
                    }
                    else
                    {
                        print("실패");

                        ScoreManager.instance.GetScore();
                    }
                    #endregion

                    print("버튼 누르기 전");

                    // 버튼이 돌아간다
                    button.start();

                    // 소스가 줄어든다
                    mission2.notFill();

                    // 모든 번호 False
                    DestoryNum1();

                    // 5초 뒤에 사라진다 *** Destory 하기 ***
                    // 냄비를 5초뒤 삭제
                    potObject = GameObject.FindGameObjectWithTag("Pot");

                    Destroy(potObject, 1f);

                    // 소스를 삭제 한뒤 제자리로 돌아오게
                    // GameManager.instance.DestorySauce();
                    DestorySauce();

                    E_GameManager.instance.ProduceSauce();


                    // 3단계로 넘어 갈 수 있게
                    GameObject.FindGameObjectWithTag("Chicken").transform.tag = "OtherChicken";

                    GameObject.FindGameObjectWithTag("Bowl").transform.tag = "OtherBowl";

                }
            }
            else if (count < maxcount)
            {
                count = 0;
            }

            // 만약 냄비와 (간장 or 설탕 or 후추 or 마늘 or 물엿 or 식초 or 고추가루) 넣을 때마다 실행
            // 만약 냄비와 정해지지 않은 재료를 넣었을 시 실행은 함, (다만, 실패)
            if (hit.transform.CompareTag("Pot") &&
               (GameObject.FindGameObjectWithTag("Get").transform.GetChild(0).tag == "Liquid"
                || GameObject.FindGameObjectWithTag("Get").transform.GetChild(0).tag == "Powder"
                || GameObject.FindGameObjectWithTag("Get").transform.GetChild(0).gameObject.tag == "Soy"
                || GameObject.FindGameObjectWithTag("Get").transform.GetChild(0).gameObject.tag == "Sugar"
                || GameObject.FindGameObjectWithTag("Get").transform.GetChild(0).gameObject.tag == "Pepper"
                || GameObject.FindGameObjectWithTag("Get").transform.GetChild(0).gameObject.tag == "Garlic"
                || GameObject.FindGameObjectWithTag("Get").transform.GetChild(0).gameObject.tag == "Syrup"
                || GameObject.FindGameObjectWithTag("Get").transform.GetChild(0).gameObject.tag == "Vinegar"
                || GameObject.FindGameObjectWithTag("Get").transform.GetChild(0).gameObject.tag == "Chilli"))
            {

                mission2.MissionOne();

                print("소스 넣을 준비 완료");

                // 재료 번호
                testNumber1();

            }

            #endregion

            #region Mission Three


            // 우유에 담긴 닭을 씻고, 튀김 가루와 물 넣고 섞기

            // 바라보며 K를 누를 시 물 차오름
            if (hit.transform.CompareTag("Water"))
            {
                Menual2.text = "K를 눌러 물을 채우시오";

                print("물 차오르는 상태");

                // k 키를 누를 시 물이 차오름
                mission3.MissionOne();

                // grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                // 만약 치킨이 물안에 OtherChicken이 있다면
                if (GameObject.FindGameObjectWithTag("WaterPoint").transform.GetChild(0).tag == "OtherChicken")
                {
                    // OtherChicken -> NextChicken로 바꾼다
                    GameObject.FindGameObjectWithTag("OtherChicken").transform.tag = "NextChicken";
                    // OtherBowl -> NextBowl로 바꾼다
                    GameObject.FindGameObjectWithTag("OtherBowl").transform.tag = "NextBowl";

                    // 우유 없애기
                    mission.notfill();


                }


            }

            if (Input.GetButtonDown("Fire1"))
            {

                // 치킨을 씻는다

                // 맞은 것이 NextChicken 일때
                if (hit.transform.CompareTag("NextChicken"))
                {
                    hit.transform.parent = bowl.transform;

                    hit.transform.SetAsFirstSibling();
                    //볼 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;

                    // 5초 뒤에 물 없애기
                    Invoke("notwater", 7f);

                    GameObject.FindGameObjectWithTag("NextChicken").GetComponent<Rigidbody>().isKinematic = true;


                }

                // 새로운 볼 태그로 바뀐 (볼과 치킨이 있음 들게함)
                if (hit.transform.CompareTag("NextBowl") && GameObject.Find("Bowl").transform.GetChild(0).tag == "NextChicken")
                {
                    hit.transform.parent = position.transform;
                    hit.transform.SetAsFirstSibling();
                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;

                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                    // 치킨 태그 바꿔줘야함
                    if (Dough[0] && Dough[1])
                    {
                        print("성공");
                    }
                    else
                    {
                        print("실패");

                        ScoreManager.instance.GetScore();
                    }

                }

                // 튀김가루
                if (hit.transform.CompareTag("Powder"))
                {
                    hit.transform.parent = position.transform;

                    hit.transform.SetAsFirstSibling();
                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;

                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }

                // 물
                if (hit.transform.CompareTag("Liquid"))
                {
                    hit.transform.parent = position.transform;

                    hit.transform.SetAsFirstSibling();
                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;

                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }


                // Next Bowl이 손에 들고 있고 Btn 을 클릭하면
                if (GameObject.FindGameObjectWithTag("NextBowl") && hit.transform.CompareTag("FryerBtn"))
                {
                    // bool 변수 false로
                    DestoryNum2();

                    // ***** NewBowl 을 Destory 한다 *******
                    GameObject Bowl = GameObject.FindGameObjectWithTag("NextBowl");

                    Destroy(Bowl);

                    // ***** Bowl 생성 ***********
                    E_GameManager.instance.Produce();

                    // ******** 가스레인지 버튼 원상 복귀 ************
                    GameObject.FindGameObjectWithTag("TimeBtn").transform.gameObject.tag = "Button";
                    // ********** 버튼 원래 위치로 이동 ***********
                    button.Restart();
                    // ********** 버튼 누르는 횟수 초기화 ***********
                    count = 0;

                    // Mix에서 원래대로 돌려 놓기
                    GameObject.FindGameObjectWithTag("FryerBtn").tag = "Btn";
                    GameObject.FindGameObjectWithTag("StartOil").tag = "Oil";
                }

            }



            if (hit.transform.CompareTag("NextBowl")
                && (GameObject.FindGameObjectWithTag("Get").transform.GetChild(0).tag == "Liquid"
                || GameObject.FindGameObjectWithTag("Get").transform.GetChild(0).tag == "Powder"
                || GameObject.FindGameObjectWithTag("Get").transform.GetChild(0).gameObject.tag == "Soy"
                || GameObject.FindGameObjectWithTag("Get").transform.GetChild(0).gameObject.tag == "Sugar"
                || GameObject.FindGameObjectWithTag("Get").transform.GetChild(0).gameObject.tag == "Pepper"
                || GameObject.FindGameObjectWithTag("Get").transform.GetChild(0).gameObject.tag == "Garlic"
                || GameObject.FindGameObjectWithTag("Get").transform.GetChild(0).gameObject.tag == "Syrup"
                || GameObject.FindGameObjectWithTag("Get").transform.GetChild(0).gameObject.tag == "Vinegar"
                || GameObject.FindGameObjectWithTag("Get").transform.GetChild(0).gameObject.tag == "Chilli"))
            {
                Menual3.text = "K를 눌러 반죽을 채우시오";

                print("반죽 넣을 준비 완료");

                // 배열번호
                testNumber2();

                // 물 채우기
                mission4.MissionOne();

            }

            #endregion

            #region Mission Last
            if (Input.GetButtonDown("Fire1"))
            {
                if (hit.transform.CompareTag("RealCk"))
                {
                    hit.transform.parent = position.transform;

                    hit.transform.SetAsFirstSibling();

                    hit.transform.localPosition = Vector3.zero;

                    // 닿은 물체 뭐인지 저장
                    ChickenObject = hit.transform;

                    ChickenObject.GetComponent<Rigidbody>().isKinematic = true;

                    isCheck = true;

                }
            }
            #endregion


        }
    }

    void testNumber1()
    {
        #region 배열 번호

        if (grabbedObject.transform.CompareTag("Soy") && Input.GetKeyDown(KeyCode.K))
        {
            Ingredient[0] = true;
        }
        if (grabbedObject.transform.CompareTag("Sugar") && Input.GetKeyDown(KeyCode.K))
        {
            Ingredient[1] = true;
        }
        if (grabbedObject.transform.CompareTag("Pepper") && Input.GetKeyDown(KeyCode.K))
        {
            Ingredient[2] = true;
        }
        if (grabbedObject.transform.CompareTag("Garlic") && Input.GetKeyDown(KeyCode.K))
        {
            Ingredient[3] = true;
        }
        if (grabbedObject.transform.CompareTag("Syrup") && Input.GetKeyDown(KeyCode.K))
        {
            Ingredient[4] = true;
        }
        #endregion

    }

    void DestoryNum1()
    {
        Ingredient[0] = false;
        Ingredient[1] = false;
        Ingredient[2] = false;
        Ingredient[3] = false;
        Ingredient[4] = false;
        
    }

    void testNumber2()
    {
        if (grabbedObject.transform.CompareTag("Powder") && Input.GetKeyDown(KeyCode.K))
        {
            Dough[0] = true;
        }
        if (grabbedObject.transform.CompareTag("Liquid") && Input.GetKeyDown(KeyCode.K))
        {
            Dough[1] = true;
        }

    }

    void DestoryNum2()
    {
      
         Dough[0] = false;
         Dough[1] = false;
      
    }



    void DropObject()
    {

        if (Input.GetButtonDown("Fire1"))
        {

            if (isCheck == true)
            {
                if (ChickenObject != null)
                {
                    print("실행");

                    // 잡은 것을 놓는다
                    ChickenObject.parent = null;
                    ChickenObject = null;

                    GameObject.FindGameObjectWithTag("RealCk").GetComponent<BoxCollider>().isTrigger = false;
                }

                isCheck = false;
            }


        }
       
       
        if (Input.GetButtonDown("Fire1"))
        {
            if (grabbedObject != null)
            {
                grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                // 잡은 것을 놓는다
                grabbedObject.parent = null;
                grabbedObject = null;
            }

        }
        
       
    }


    

    void notwater()
    {
        // 물 없애기
        mission3.notfill();
    }


    public void DestorySauce()
    {
        FindSauce();

        print("241325345q424q5q");
        Destroy(Soy, 1f);
        Destroy(Sugar, 1f);
        Destroy(Pepper, 1f);
        Destroy(Garlic, 1f);
        Destroy(Syrup, 1f);
        Destroy(Vinegar, 1f);
        Destroy(Chilli, 1f);
        Destroy(Liquid, 1f);
        Destroy(Powder, 1f);
        Destroy(Milk, 1f);

    }
}