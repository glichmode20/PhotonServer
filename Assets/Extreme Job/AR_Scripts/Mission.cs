using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission : MonoBehaviour
{
    public GameObject position;
    public GameObject bowl;
    public GameObject water;
    public GameObject Pot;

    public Text itemName;
    public Text Menual;

    TestMission mission;
    TestMission2 mission2;
    TestMission3 mission3;
    TestMission4 mission4;

    Button button;

    // 잡힌 오브젝트
    Transform grabbedObject = null;




    // Start is called before the first frame update
    void Start()
    {
        mission = GameObject.Find("Glass bowl").GetComponentInChildren<TestMission>();
        mission2 = GameObject.Find("Pot").GetComponentInChildren<TestMission2>();
        mission3 = GameObject.Find("Water").GetComponentInChildren<TestMission3>();
        mission4 = GameObject.Find("Glass bowl").GetComponentInChildren<TestMission4>();
        button = GameObject.FindGameObjectWithTag("Button").GetComponent<Button>();
    
    }


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

            #region Mission One

            // 눌렀을 때
            if (Input.GetButtonDown("Fire1"))
            {
                if (hit.transform.CompareTag("Chicken"))
                {
                    hit.transform.parent = bowl.transform;
                    //볼 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;
                    //grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
              
                }

                if (hit.transform.CompareTag("OtherChicken"))
                {
                    // 물 안에 들어가게 한다
                    hit.transform.parent = water.transform;
                   
                    hit.transform.localPosition = Vector3.zero;

                    // 닿은 물체 뭐인지 저장
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                }

                if (hit.transform.CompareTag("Bowl"))
                {
                    // 만약 볼 안에 치킨이란 태그가 달려있는 오브젝트가 있다면

                    hit.transform.parent = position.transform;
                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;
                    
                    // 닿은 물체 뭐인지 저장
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                    //// 볼 안에 자식 오브젝트 0번째 치킨과 손에 볼이 있다면
     

                }

                if (hit.transform.CompareTag("Milk"))
                {
                    hit.transform.parent = position.transform;
                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;
                    // 들고 있는 물건 무엇인지 
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }

            }

            // 닿은 것이 볼이고 손엔 우유곽이 있다면
            if (hit.transform.CompareTag("OtherBowl") && GameObject.Find("Get").transform.GetChild(0).name == "MilkCarton")// grabbedObject.transform.CompareTag("Milk"))
            {
                // K를 눌러 실행하게 한다
                mission.MissionOne();

                print("우유 넣기 실행 가능한 상태");

            }

            // 볼 안에 자식 오브젝트 0번째 치킨과 손에 볼이 있다면
            if (GameObject.Find("Bowl").transform.GetChild(0).tag == "Chicken" && GameObject.Find("Get").transform.GetChild(0).tag == "Milk")
            {
                print("바뀌였다");

                // 치킨 태그를 otherchicken로 바꾼다
                GameObject.FindGameObjectWithTag("Chicken").transform.tag = "OtherChicken";

                GameObject.FindGameObjectWithTag("Bowl").transform.tag = "OtherBowl";
            }

            #endregion

            #region Mission Two
            if (Input.GetButtonDown("Fire1"))
            {
                if (hit.transform.CompareTag("Pot"))
                {
                    hit.transform.parent = position.transform;
                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;
                    // 닿은 물체 뭐인지 저장
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                }

                if (hit.transform.CompareTag("Soy"))
                {
                    hit.transform.parent = position.transform;
                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;
                    // 닿은 물체 뭐인지 저장
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                }
                if (hit.transform.CompareTag("Sugar"))
                {
                    hit.transform.parent = position.transform;
                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;
                    // 닿은 물체 뭐인지 저장
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }
                if (hit.transform.CompareTag("Pepper"))
                {
                    hit.transform.parent = position.transform;
                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;
                    // 닿은 물체 뭐인지 저장
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }
                if (hit.transform.CompareTag("Garlic"))
                {
                    hit.transform.parent = position.transform;
                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;
                    // 닿은 물체 뭐인지 저장
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }
                if (hit.transform.CompareTag("Syrup"))
                {
                    hit.transform.parent = position.transform;
                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;
                    // 닿은 물체 뭐인지 저장
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }
                       
                if (hit.transform.CompareTag("Vinegar"))
                {
                    hit.transform.parent = position.transform;
                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;
                    // 닿은 물체 뭐인지 저장
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }
                       
                if (hit.transform.CompareTag("Chilli"))
                {
                    hit.transform.parent = position.transform;
                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;
                    // 닿은 물체 뭐인지 저장
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }

                // 맞은 것이 Button 일때
                if (hit.transform.CompareTag("Button"))
                {
                    print("버튼 누르기 전");

                    // 버튼이 돌아간다
                    button.start();

                    // 소스가 줄어든다
                    mission2.notFill();

                }
            }
         

            // 만약 냄비와 (간장 or 설탕 or 후추 or 마늘 or 물엿 or 식초 or 고추가루) 넣을 때마다 실행
            // 만약 냄비와 정해지지 않은 재료를 넣었을 시 실행은 함, (다만, 실패)
            if (hit.transform.CompareTag("Pot") && (GameObject.Find("Get").transform.GetChild(0).name == "Soy" || GameObject.Find("Get").transform.GetChild(0).name == "Sugar"
                || GameObject.Find("Get").transform.GetChild(0).name == "Pepper" || GameObject.Find("Get").transform.GetChild(0).name == "Garlic" || GameObject.Find("Get").transform.GetChild(0).name == "Syrup"
                || GameObject.Find("Get").transform.GetChild(0).name == "Vinegar" || GameObject.Find("Get").transform.GetChild(0).name == "Chilli"))
            {

                mission2.MissionOne();

                print("소스 넣을 준비 완료");

                // 냄비에 식초 or 고추가루가 넣은 전적이 있다면
                if(grabbedObject.transform.CompareTag("Vinegar") || grabbedObject.transform.CompareTag("Chilli") && Input.GetKeyDown(KeyCode.K))
                {
                    // 점수 까였다!
                    print("점수 까임");
                }

            }


            #endregion

            #region Mission Three
            // 우유에 담긴 닭을 씻고, 튀김 가루와 물 넣고 섞기

            // 바라보며 K를 누를 시 물 차오름
            if (hit.transform.CompareTag("Water"))
            {
                print("물 차오르기 준비 완료");

                // k 키를 누를 시 물이 차오름
                mission3.MissionOne();

                // grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                // 치킨을 씻길때, 워터 포인트 안에 otherChicken이 있다면
                if (GameObject.Find("waterPoint").transform.GetChild(0).gameObject.tag == "OtherChicken")
                {
                    // 우유 없애기
                    // mission.notfill();

                    // OtherChicken -> NextChicken로 바꾼다
                    GameObject.Find("Chicken").transform.tag = "NextChicken";
                    // OtherBowl -> NextBowl로 바꾼다
                    GameObject.Find("Glass bowl").transform.tag = "NextBowl";

                }


            }

            if (Input.GetButtonDown("Fire1"))
            {

                // 치킨을 씻는다

                // 맞은 것이 NextChicken 일때
                if (hit.transform.CompareTag("NextChicken"))
                {
                    hit.transform.parent = bowl.transform;
                    //볼 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;
                    //닿은 물체 뭐인지 저장
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                }
                
                // 치킨을 담기 위해서 새로운 Bowl이 필요
                // Bowl 안에 있는 우유를 버리고 물을 새로 채운다
                if (hit.transform.CompareTag("OtherBowl"))
                {
                    hit.transform.parent = position.transform;
                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;

                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;


                }    
                // 새로운 볼 태그로 바뀐
                if (hit.transform.CompareTag("NextBowl"))
                {
                    hit.transform.parent = position.transform;
                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;

                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                }

                // 튀김가루
                if (hit.transform.CompareTag("Powder"))
                {
                    hit.transform.parent = position.transform;
                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;

                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }                
                
                // 물
                if (hit.transform.CompareTag("Liquid"))
                {
                    hit.transform.parent = position.transform;
                    //손 안에 들어가게 한다
                    hit.transform.localPosition = Vector3.zero;

                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }


            }

         
        
            //  들고 있는 물과 튀김가루가 볼이 있으면
            if (hit.transform.CompareTag("NextBowl") && (GameObject.Find("Get").transform.GetChild(0).tag == "Liquid" || GameObject.Find("Get").transform.GetChild(0).tag == "Powder")) //grabbedObject.transform.CompareTag("Liquid"))//GameObject.Find("Get").transform.GetChild(0).name == "Liquid")
            {
                print("반죽 넣을 준비 완료");

                // 물 채우기
                mission4.MissionOne();

            }  

            #endregion

        }
    }

    void DropObject()
    {
        
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



}


