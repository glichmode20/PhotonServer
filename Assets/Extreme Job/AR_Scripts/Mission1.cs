using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission1 : MonoBehaviour
{
    [Header("���� ��ġ")]
    public GameObject position;
    public GameObject bowl;
    public GameObject water;
    public GameObject pot;

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

    [Header("������Ʈ")]
    public GameObject potObject;
    public GameObject Source;

    [Header("���� �ؽ�Ʈ")]
    public Text itemName;
    public Text Menual;
    public Text Menual2;
    public Text Menual3;
    public Text Menual4;

    [Header("��� �̸� ���� �迭")]
    // �ҽ�
    public bool[] Ingredient = new bool[5];
    // ����
    public bool[] Dough = new bool[1];

    public bool isCheck = false;

    [Header("��ư Ŭ�� ����")]
    public int count = 0;
    int maxcount = 1;

    //��ũ��Ʈ �ҷ�����
    TestMission mission;
    TestMission2 mission2;
    TestMission3 mission3;
    TestMission4 mission4;
    MenualUI menual;

    Button button;

    // ���� ������Ʈ
    public Transform grabbedObject = null;
    public Transform ChickenObject = null;
    // public Transform CKObject = null;



    // Start is called before the first frame update
    void Start()
    {
       
        mission3 = GameObject.Find("Water").GetComponentInChildren<TestMission3>();
        // ******** �±׸� �ٲ������ ***********
        button = GameObject.FindGameObjectWithTag("Button").GetComponent<Button>();
        menual = GameObject.Find("@Canvas").GetComponent<MenualUI>();

  
    }

    #region Finding
    public void FindBowl()
    {
        // ���� ã��
        mission = GameObject.FindGameObjectWithTag("Bowl").GetComponentInChildren<TestMission>();
        // ���ױ� ã��
        mission4 = GameObject.FindGameObjectWithTag("Bowl").GetComponentInChildren<TestMission4>();
      
        // �� ��ġ
        bowl = GameObject.FindGameObjectWithTag("BowlPos");
        print(bowl);
    }

    public void FindPot()
    {
        // ���� ã��
        mission2 = GameObject.FindGameObjectWithTag("Pot").GetComponentInChildren<TestMission2>();

        // ���� ��ġ (ã�Ƽ� ������ ����)
        potObject = GameObject.FindGameObjectWithTag("Pot");
    }

    public void FindSauce()
    {
        // �ҽ� ������Ʈ ã��
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
            itemName.text = "���� : " + hit.collider.name;
            //********* �޴� �ϱ� **********
            //menual.leImage();

            #region Mission One

            // ������ ��
            if (Input.GetButtonDown("Fire1"))
            {
                if (hit.transform.CompareTag("Chicken"))
                {
                    bowl = GameObject.FindGameObjectWithTag("BowlPos");
                    hit.transform.parent = bowl.transform;
                    hit.transform.SetAsFirstSibling();
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;


                    //�ٽ� ��ư�±׸� ������� ���� ����
                    GameObject.FindGameObjectWithTag("Btn").tag = "FryerBtn";
                    GameObject.FindGameObjectWithTag("Oil").tag = "StartOil";
                    //grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                }

                if (hit.transform.CompareTag("OtherChicken"))
                {
                    // �� �ȿ� ���� �Ѵ�
                    hit.transform.parent = water.transform;

                    hit.transform.SetAsFirstSibling();

                    hit.transform.localPosition = Vector3.zero;

                    // ���� ��ü ������ ����
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                }

                if (hit.transform.CompareTag("Bowl"))
                {
                    // ���� �� �ȿ� ġŲ�̶� �±װ� �޷��ִ� ������Ʈ�� �ִٸ�

                    hit.transform.parent = position.transform;

                    hit.transform.SetAsFirstSibling();

                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;

                    // ���� ��ü ������ ����
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                 
                }

                if (hit.transform.CompareTag("Milk"))
                {
                    Menual4.text = "K�� ���� ���� ���� ������ ä��ÿ�";

                    hit.transform.parent = position.transform;
                    hit.transform.SetAsFirstSibling();
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;
                    // ��� �ִ� ���� �������� 
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }

            }
            // ���� ġŲ�� �ְ� �տ� ������ ���ڸ���
            //if (position.transform.GetChild(0).CompareTag("Milk") && bowl.transform.GetChild(0).CompareTag("Chicken"))
            //{
            //    //GameObject.FindGameObjectWithTag("Chicken").transform.tag = "OtherChicken";

            //    //GameObject.FindGameObjectWithTag("Bowl").transform.tag = "OtherBowl";
            //}

            // ���� ���� ���̰� �տ� �������� �ִٸ�
            if (hit.transform.CompareTag("Bowl") && position.transform.GetChild(0).CompareTag("Milk") && bowl.transform.GetChild(0).CompareTag("Chicken"))// grabbedObject.transform.CompareTag("Milk"))
            {
                // K�� ���� �����ϰ� �Ѵ�
                mission.MissionOne();

                //  GameObject.FindGameObjectWithTag("Chicken").transform.tag = "OtherChicken";

                // GameObject.FindGameObjectWithTag("Bowl").transform.tag = "OtherBowl";

                print("���� �ֱ� ���� ������ ����");
            }



            #endregion

            #region Mission Two
            if (Input.GetButtonDown("Fire1"))
            {
                if (hit.transform.CompareTag("Pot"))
                {
                    Menual.text = "K�� ���� �ҽ��� ä��ÿ�";
                    
                    hit.transform.parent = pot.transform;
                    // hit.transform.SetAsFirstSibling();
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;
                    // ���� ��ü ������ ����
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                    GameObject.FindGameObjectWithTag("Button").transform.gameObject.tag = "TimeBtn";

                }

                if (hit.transform.CompareTag("OtherPot"))
                {
                    hit.transform.parent = position.transform;
                    // hit.transform.SetAsFirstSibling();
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;
                    // ���� ��ü ������ ����
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;



                }

                if (hit.transform.CompareTag("Soy"))
                {
                    hit.transform.parent = position.transform;

                    hit.transform.SetAsFirstSibling();
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;
                    // ���� ��ü ������ ����
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;


                }
                if (hit.transform.CompareTag("Sugar"))
                {

                    hit.transform.parent = position.transform;

                    hit.transform.SetAsFirstSibling();
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;
                    // ���� ��ü ������ ����
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                }
                if (hit.transform.CompareTag("Pepper"))
                {

                    hit.transform.parent = position.transform;

                    hit.transform.SetAsFirstSibling();
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;
                    // ���� ��ü ������ ����
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                }
                if (hit.transform.CompareTag("Garlic"))
                {
                    hit.transform.parent = position.transform;

                    hit.transform.SetAsFirstSibling();
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;
                    // ���� ��ü ������ ����
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;


                }

                if (hit.transform.CompareTag("Syrup"))
                {
                    hit.transform.parent = position.transform;

                    hit.transform.SetAsFirstSibling();
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;
                    // ���� ��ü ������ ����
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;


                }

                if (hit.transform.CompareTag("Vinegar"))
                {
                    hit.transform.parent = position.transform;

                    hit.transform.SetAsFirstSibling();
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;
                    // ���� ��ü ������ ����
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }

                if (hit.transform.CompareTag("Chilli"))
                {
                    hit.transform.parent = position.transform;

                    hit.transform.SetAsFirstSibling();

                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;
                    // ���� ��ü ������ ����
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                }

                // ���� ���� Button �϶�
                if (hit.transform.CompareTag("TimeBtn") && count < maxcount)
                {
                    #region ����
                    count++;

                    if (Ingredient[0] && Ingredient[1] && Ingredient[2] && Ingredient[3] && Ingredient[4])
                    {
                        print("����");
                    }
                    else
                    {
                        print("����");

                        ScoreManager.instance.GetScore();
                    }
                    #endregion

                    print("��ư ������ ��");

                    // ��ư�� ���ư���
                    button.start();

                    // �ҽ��� �پ���
                    mission2.notFill();

                    // ��� ��ȣ False
                    DestoryNum1();

                    // 5�� �ڿ� ������� *** Destory �ϱ� ***
                    // ���� 5�ʵ� ����
                    potObject = GameObject.FindGameObjectWithTag("Pot");

                    Destroy(potObject, 1f);

                    // �ҽ��� ���� �ѵ� ���ڸ��� ���ƿ���
                    // GameManager.instance.DestorySauce();
                    DestorySauce();

                    E_GameManager.instance.ProduceSauce();


                    // 3�ܰ�� �Ѿ� �� �� �ְ�
                    GameObject.FindGameObjectWithTag("Chicken").transform.tag = "OtherChicken";

                    GameObject.FindGameObjectWithTag("Bowl").transform.tag = "OtherBowl";

                }
            }
            else if (count < maxcount)
            {
                count = 0;
            }

            // ���� ����� (���� or ���� or ���� or ���� or ���� or ���� or ���߰���) ���� ������ ����
            // ���� ����� �������� ���� ��Ḧ �־��� �� ������ ��, (�ٸ�, ����)
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

                print("�ҽ� ���� �غ� �Ϸ�");

                // ��� ��ȣ
                testNumber1();

            }

            #endregion

            #region Mission Three


            // ������ ��� ���� �İ�, Ƣ�� ����� �� �ְ� ����

            // �ٶ󺸸� K�� ���� �� �� ������
            if (hit.transform.CompareTag("Water"))
            {
                Menual2.text = "K�� ���� ���� ä��ÿ�";

                print("�� �������� ����");

                // k Ű�� ���� �� ���� ������
                mission3.MissionOne();

                // grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                // ���� ġŲ�� ���ȿ� OtherChicken�� �ִٸ�
                if (GameObject.FindGameObjectWithTag("WaterPoint").transform.GetChild(0).tag == "OtherChicken")
                {
                    // OtherChicken -> NextChicken�� �ٲ۴�
                    GameObject.FindGameObjectWithTag("OtherChicken").transform.tag = "NextChicken";
                    // OtherBowl -> NextBowl�� �ٲ۴�
                    GameObject.FindGameObjectWithTag("OtherBowl").transform.tag = "NextBowl";

                    // ���� ���ֱ�
                    mission.notfill();


                }


            }

            if (Input.GetButtonDown("Fire1"))
            {

                // ġŲ�� �Ĵ´�

                // ���� ���� NextChicken �϶�
                if (hit.transform.CompareTag("NextChicken"))
                {
                    hit.transform.parent = bowl.transform;

                    hit.transform.SetAsFirstSibling();
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;

                    // 5�� �ڿ� �� ���ֱ�
                    Invoke("notwater", 7f);

                    GameObject.FindGameObjectWithTag("NextChicken").GetComponent<Rigidbody>().isKinematic = true;


                }

                // ���ο� �� �±׷� �ٲ� (���� ġŲ�� ���� �����)
                if (hit.transform.CompareTag("NextBowl") && GameObject.Find("Bowl").transform.GetChild(0).tag == "NextChicken")
                {
                    hit.transform.parent = position.transform;
                    hit.transform.SetAsFirstSibling();
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;

                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                    // ġŲ �±� �ٲ������
                    if (Dough[0] && Dough[1])
                    {
                        print("����");
                    }
                    else
                    {
                        print("����");

                        ScoreManager.instance.GetScore();
                    }

                }

                // Ƣ�谡��
                if (hit.transform.CompareTag("Powder"))
                {
                    hit.transform.parent = position.transform;

                    hit.transform.SetAsFirstSibling();
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;

                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }

                // ��
                if (hit.transform.CompareTag("Liquid"))
                {
                    hit.transform.parent = position.transform;

                    hit.transform.SetAsFirstSibling();
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;

                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }


                // Next Bowl�� �տ� ��� �ְ� Btn �� Ŭ���ϸ�
                if (GameObject.FindGameObjectWithTag("NextBowl") && hit.transform.CompareTag("FryerBtn"))
                {
                    // bool ���� false��
                    DestoryNum2();

                    // ***** NewBowl �� Destory �Ѵ� *******
                    GameObject Bowl = GameObject.FindGameObjectWithTag("NextBowl");

                    Destroy(Bowl);

                    // ***** Bowl ���� ***********
                    E_GameManager.instance.Produce();

                    // ******** ���������� ��ư ���� ���� ************
                    GameObject.FindGameObjectWithTag("TimeBtn").transform.gameObject.tag = "Button";
                    // ********** ��ư ���� ��ġ�� �̵� ***********
                    button.Restart();
                    // ********** ��ư ������ Ƚ�� �ʱ�ȭ ***********
                    count = 0;

                    // Mix���� ������� ���� ����
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
                Menual3.text = "K�� ���� ������ ä��ÿ�";

                print("���� ���� �غ� �Ϸ�");

                // �迭��ȣ
                testNumber2();

                // �� ä���
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

                    // ���� ��ü ������ ����
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
        #region �迭 ��ȣ

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
                    print("����");

                    // ���� ���� ���´�
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
                // ���� ���� ���´�
                grabbedObject.parent = null;
                grabbedObject = null;
            }

        }
        
       
    }


    

    void notwater()
    {
        // �� ���ֱ�
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