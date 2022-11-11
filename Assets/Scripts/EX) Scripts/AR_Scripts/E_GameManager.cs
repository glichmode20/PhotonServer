using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class E_GameManager : MonoBehaviourPunCallbacks
{
    public static E_GameManager instance;

    [Header("������ ������Ʈ")]
    public GameObject Bowl;
    public GameObject Chicken;
    public GameObject Pot;

    [Header("������ ������Ʈ ��ġ")]
    public Transform BowlPos;
    public Transform ChickenPos;
    public Transform PotPos;

    [Header("�ҽ� ������Ʈ")]
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

    [Header("������ �ҽ� ������Ʈ ��ġ")]
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


    // ����
    [Header("�ð�")]
    public Text timeText;
    [SerializeField]
    // �÷��� �ð�
    int min = 1;
    [SerializeField]
    float sec;

    [Header("����")]
    public bool isEnd = false;


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

    // �÷��� �ð�
    float test = 1f;
    void CheckCountTime()
    {
        if(min < 0f)
        {
            min = 0;
            sec = 0;
            Ending();

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


    //public void FindSauce()
    //{
    //    // �ҽ� ������Ʈ ã��
    //    Soy = GameObject.FindGameObjectWithTag("Soy");
    //    Sugar = GameObject.FindGameObjectWithTag("Sugar");
    //    Pepper = GameObject.FindGameObjectWithTag("Pepper");
    //    Garlic = GameObject.FindGameObjectWithTag("Garlic");
    //    Syrup = GameObject.FindGameObjectWithTag("Syrup");
    //    Vinegar = GameObject.FindGameObjectWithTag("Vinegar");
    //    Chilli = GameObject.FindGameObjectWithTag("Chilli");
    //    Liquid = GameObject.FindGameObjectWithTag("Liquid");
    //    Powder = GameObject.FindGameObjectWithTag("Powder");
    //    Milk = GameObject.FindGameObjectWithTag("Milk");

    //}

    // �ٽ� ���Ӱ� ����
    public void Produce()
    {
  

        GameObject bowl = Instantiate(Bowl, BowlPos.position, Quaternion.Euler(270f, 0f,0f));
        
        GameObject pot = Instantiate(Pot, PotPos.position, Quaternion.Euler(270f, 0f,0f));

        GameObject chicken = Instantiate(Chicken, ChickenPos.position, Quaternion.Euler(90f, 0f, 0f));

        // @Manager �ȿ� �ִ� Mission ��ũ��Ʈ���� Bowl�� Pot�� ã�´�
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

    //public void DestorySauce()
    //{
    //    // ���̾��Űâ�� �ִ� �ҽ����� ã�� ����
    //    gameObject.GetComponent<Mission1>().FindSauce();

    //    Destroy(Soy, 3f);
    //    Destroy(Sugar, 3f);
    //    Destroy(Pepper, 3f);
    //    Destroy(Garlic, 3f);
    //    Destroy(Syrup, 3f);
    //    Destroy(Vinegar, 3f);
    //    Destroy(Chilli, 3f);
    //    Destroy(Liquid, 3f);
    //    Destroy(Powder, 3f);
    //    Destroy(Milk, 3f);


    //}

    // ����
    void Ending()
    {
        isEnd = true;
        
        if(isEnd)
        {

            PhotonNetwork.LoadLevel("Photon2");
        }

    }

}
