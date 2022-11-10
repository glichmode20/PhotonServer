using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class E_GameManager : MonoBehaviourPunCallbacks
{
    public static E_GameManager instance;


    [Header("생성할 오브젝트")]
    public GameObject Bowl;
    public GameObject Chicken;
    public GameObject Pot;

    [Header("생성할 오브젝트 위치")]
    public Transform BowlPos;
    public Transform ChickenPos;
    public Transform PotPos;

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

    [Header("생성할 소스 오브젝트 위치")]
    public Transform SoyPos;
    public Transform SugarPos;
    public Transform PepperPos;
    public Transform GarlicPos;
    public Transform SyrupPos;
    public Transform VinegarPos;
    public Transform ChilliPos;
    public Transform LiquidPos;
    public Transform PowderPos;
    public Transform MilkPos;


    // 성공
    [Header("시간")]
    public Text timeText;
    
    // 플레이 시간
    public int min = 5;
    public float sec;

    [Header("엔딩")]
    public bool isEnd = false;

    public bool isCheck = false;

    private void Awake()
    {
        if (!instance) instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        ProduceSauce();
        Produce();


        // timeText.text = string.Format("{0:D2}:{1:D2}", min, (int)sec);
    }

    // Update is called once per frame
    void Update()
    {
        CheckCountTime();
        // Ending();

    }

    // 플레이 시간
    float test = 1f;
    void CheckCountTime()
    {
        if(min < 0f)
        {
            min = 0;
            sec = 0;

            //if(isCheck == true)
            //{
                Ending();
            //}

            return;
        }
        else
        {
            sec -= Time.deltaTime * test;
            if (sec <= 0)
            {
                min--;
                sec = 60;
            }
        }

        if (Input.GetKey(KeyCode.P)) test++;
        else if (Input.GetKeyUp(KeyCode.P)) test = 1f;

        timeText.text = string.Format("{0:D2}:{1:D2}", min, (int)sec);
    }


    // 다시 새롭게 시작
    public void Produce()
    {
  

        GameObject bowl = Instantiate(Bowl, BowlPos.position, Quaternion.Euler(270f, 0f,0f));
        
        GameObject pot = Instantiate(Pot, PotPos.position, Quaternion.Euler(270f, 0f,0f));

        GameObject chicken = Instantiate(Chicken, ChickenPos.position, Quaternion.Euler(90f, 0f, 0f));

        // @Manager 안에 있는 Mission 스크립트에서 Bowl과 Pot을 찾는다
        gameObject.GetComponent<Mission1>().FindBowl();

        gameObject.GetComponent<Mission1>().FindPot();

    }

    public void ProduceSauce()
    {
       // FindSauce();
        GameObject soy = Instantiate(Soy, SoyPos.position, Quaternion.identity);
        GameObject sugar = Instantiate(Sugar, SugarPos.position, Quaternion.identity);
        GameObject pepper = Instantiate(Pepper, PepperPos.position, Quaternion.identity);
        GameObject garlic = Instantiate(Garlic, GarlicPos.position, Quaternion.identity);
        GameObject syrup = Instantiate(Syrup, SyrupPos.position, Quaternion.identity);
        GameObject chilli = Instantiate(Chilli, ChilliPos.position, Quaternion.identity);
        GameObject vinegar = Instantiate(Vinegar, VinegarPos.position, Quaternion.identity);  
        GameObject liquid = Instantiate(Liquid, LiquidPos.position, Quaternion.Euler(90f, 0f, 0f));
        GameObject powder = Instantiate(Powder, PowderPos.position, Quaternion.Euler(90f, 0f, 0f));
        GameObject milk = Instantiate(Milk, MilkPos.position, Quaternion.Euler(90f, 0f, 0f));


        gameObject.GetComponent<Mission1>().FindSauce();

    }



    //엔딩
    public void Ending()  
    {
        //isEnd = true;

        if (!isEnd)
        {

            returnRoomName = "극한 직업";
            PhotonNetwork.LeaveRoom(false);
            
            isEnd = true;
        }

    }

    string returnRoomName;

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
        print("Master Master Master Master Master ");
    }
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        PhotonNetwork.JoinRoom(returnRoomName);

        print("Lobby Lobby Lobby Lobby Lobby ");
    }



    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("Room Room Room Room Room : " + returnRoomName);

        if (returnRoomName == "보이는 어둠")
        {
            PhotonNetwork.LoadLevel("Photon");
        }
        else if (returnRoomName == "극한 직업")
        {
            PhotonNetwork.LoadLevel("Photon2");
        }
    }

}
