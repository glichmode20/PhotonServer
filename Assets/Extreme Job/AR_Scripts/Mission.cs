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

    // ���� ������Ʈ
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
            itemName.text = "���� : " + hit.collider.name;

            #region Mission One

            // ������ ��
            if (Input.GetButtonDown("Fire1"))
            {
                if (hit.transform.CompareTag("Chicken"))
                {
                    hit.transform.parent = bowl.transform;
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;
                    //grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
              
                }

                if (hit.transform.CompareTag("OtherChicken"))
                {
                    // �� �ȿ� ���� �Ѵ�
                    hit.transform.parent = water.transform;
                   
                    hit.transform.localPosition = Vector3.zero;

                    // ���� ��ü ������ ����
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                }

                if (hit.transform.CompareTag("Bowl"))
                {
                    // ���� �� �ȿ� ġŲ�̶� �±װ� �޷��ִ� ������Ʈ�� �ִٸ�

                    hit.transform.parent = position.transform;
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;
                    
                    // ���� ��ü ������ ����
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                    //// �� �ȿ� �ڽ� ������Ʈ 0��° ġŲ�� �տ� ���� �ִٸ�
     

                }

                if (hit.transform.CompareTag("Milk"))
                {
                    hit.transform.parent = position.transform;
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;
                    // ��� �ִ� ���� �������� 
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }

            }

            // ���� ���� ���̰� �տ� �������� �ִٸ�
            if (hit.transform.CompareTag("OtherBowl") && GameObject.Find("Get").transform.GetChild(0).name == "MilkCarton")// grabbedObject.transform.CompareTag("Milk"))
            {
                // K�� ���� �����ϰ� �Ѵ�
                mission.MissionOne();

                print("���� �ֱ� ���� ������ ����");

            }

            // �� �ȿ� �ڽ� ������Ʈ 0��° ġŲ�� �տ� ���� �ִٸ�
            if (GameObject.Find("Bowl").transform.GetChild(0).tag == "Chicken" && GameObject.Find("Get").transform.GetChild(0).tag == "Milk")
            {
                print("�ٲ��");

                // ġŲ �±׸� otherchicken�� �ٲ۴�
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
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;
                    // ���� ��ü ������ ����
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                }

                if (hit.transform.CompareTag("Soy"))
                {
                    hit.transform.parent = position.transform;
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;
                    // ���� ��ü ������ ����
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                }
                if (hit.transform.CompareTag("Sugar"))
                {
                    hit.transform.parent = position.transform;
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;
                    // ���� ��ü ������ ����
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }
                if (hit.transform.CompareTag("Pepper"))
                {
                    hit.transform.parent = position.transform;
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;
                    // ���� ��ü ������ ����
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }
                if (hit.transform.CompareTag("Garlic"))
                {
                    hit.transform.parent = position.transform;
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;
                    // ���� ��ü ������ ����
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }
                if (hit.transform.CompareTag("Syrup"))
                {
                    hit.transform.parent = position.transform;
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;
                    // ���� ��ü ������ ����
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }
                       
                if (hit.transform.CompareTag("Vinegar"))
                {
                    hit.transform.parent = position.transform;
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;
                    // ���� ��ü ������ ����
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }
                       
                if (hit.transform.CompareTag("Chilli"))
                {
                    hit.transform.parent = position.transform;
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;
                    // ���� ��ü ������ ����
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }

                // ���� ���� Button �϶�
                if (hit.transform.CompareTag("Button"))
                {
                    print("��ư ������ ��");

                    // ��ư�� ���ư���
                    button.start();

                    // �ҽ��� �پ���
                    mission2.notFill();

                }
            }
         

            // ���� ����� (���� or ���� or ���� or ���� or ���� or ���� or ���߰���) ���� ������ ����
            // ���� ����� �������� ���� ��Ḧ �־��� �� ������ ��, (�ٸ�, ����)
            if (hit.transform.CompareTag("Pot") && (GameObject.Find("Get").transform.GetChild(0).name == "Soy" || GameObject.Find("Get").transform.GetChild(0).name == "Sugar"
                || GameObject.Find("Get").transform.GetChild(0).name == "Pepper" || GameObject.Find("Get").transform.GetChild(0).name == "Garlic" || GameObject.Find("Get").transform.GetChild(0).name == "Syrup"
                || GameObject.Find("Get").transform.GetChild(0).name == "Vinegar" || GameObject.Find("Get").transform.GetChild(0).name == "Chilli"))
            {

                mission2.MissionOne();

                print("�ҽ� ���� �غ� �Ϸ�");

                // ���� ���� or ���߰��簡 ���� ������ �ִٸ�
                if(grabbedObject.transform.CompareTag("Vinegar") || grabbedObject.transform.CompareTag("Chilli") && Input.GetKeyDown(KeyCode.K))
                {
                    // ���� ���!
                    print("���� ����");
                }

            }


            #endregion

            #region Mission Three
            // ������ ��� ���� �İ�, Ƣ�� ����� �� �ְ� ����

            // �ٶ󺸸� K�� ���� �� �� ������
            if (hit.transform.CompareTag("Water"))
            {
                print("�� �������� �غ� �Ϸ�");

                // k Ű�� ���� �� ���� ������
                mission3.MissionOne();

                // grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                // ġŲ�� �ı涧, ���� ����Ʈ �ȿ� otherChicken�� �ִٸ�
                if (GameObject.Find("waterPoint").transform.GetChild(0).gameObject.tag == "OtherChicken")
                {
                    // ���� ���ֱ�
                    // mission.notfill();

                    // OtherChicken -> NextChicken�� �ٲ۴�
                    GameObject.Find("Chicken").transform.tag = "NextChicken";
                    // OtherBowl -> NextBowl�� �ٲ۴�
                    GameObject.Find("Glass bowl").transform.tag = "NextBowl";

                }


            }

            if (Input.GetButtonDown("Fire1"))
            {

                // ġŲ�� �Ĵ´�

                // ���� ���� NextChicken �϶�
                if (hit.transform.CompareTag("NextChicken"))
                {
                    hit.transform.parent = bowl.transform;
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;
                    //���� ��ü ������ ����
                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                }
                
                // ġŲ�� ��� ���ؼ� ���ο� Bowl�� �ʿ�
                // Bowl �ȿ� �ִ� ������ ������ ���� ���� ä���
                if (hit.transform.CompareTag("OtherBowl"))
                {
                    hit.transform.parent = position.transform;
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;

                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;


                }    
                // ���ο� �� �±׷� �ٲ�
                if (hit.transform.CompareTag("NextBowl"))
                {
                    hit.transform.parent = position.transform;
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;

                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                }

                // Ƣ�谡��
                if (hit.transform.CompareTag("Powder"))
                {
                    hit.transform.parent = position.transform;
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;

                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }                
                
                // ��
                if (hit.transform.CompareTag("Liquid"))
                {
                    hit.transform.parent = position.transform;
                    //�� �ȿ� ���� �Ѵ�
                    hit.transform.localPosition = Vector3.zero;

                    grabbedObject = hit.transform;

                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }


            }

         
        
            //  ��� �ִ� ���� Ƣ�谡�簡 ���� ������
            if (hit.transform.CompareTag("NextBowl") && (GameObject.Find("Get").transform.GetChild(0).tag == "Liquid" || GameObject.Find("Get").transform.GetChild(0).tag == "Powder")) //grabbedObject.transform.CompareTag("Liquid"))//GameObject.Find("Get").transform.GetChild(0).name == "Liquid")
            {
                print("���� ���� �غ� �Ϸ�");

                // �� ä���
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
                // ���� ���� ���´�
                grabbedObject.parent = null;
                grabbedObject = null;
            }

      }
    }



}


