using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fryer : MonoBehaviour
{
    // ȸ�� �ӵ�
    public float rotSpeed;
    // �⸧
    public GameObject oil;

    // �⸧ �� ����
    public Renderer oilcolor;

    // ġŲ �� �ٲٱ�
    public Renderer ck1color;
    public Renderer ck2color;
    public Renderer ck3color;

    // ġŲ ���� �� �ִ� ��Ʈ��Ʈ ����
    ChickenTrigger ct1;
    ChickenTrigger ct2;
    ChickenTrigger ct3;


    // �Ŵ��� ������Ʈ
    public GameObject manager;

    // ġŲ ����
    public GameObject ck1;
    public GameObject ck2;
    public GameObject ck3;

    // ġŲ ��ǥ
    public GameObject ck1pos;
    public GameObject ck2pos;
    public GameObject ck3pos;

    // �׸����� Ƣ���� �̵��ϴ� ��ǥ
    public GameObject oilck1Pos;
    public GameObject oilck2Pos;
    public GameObject oilck3Pos;
    // ġŲ 
    public GameObject chicken;

    // ġŲ �� ����� Ƣ��� ���� �� üũ�ϴ� ����
    public bool isck1 = true;
    public bool isck2 = true;
    public bool isck3 = true;

    // ġŲ �¿� �� üũ�ϴ� ����
    public bool isckk1 = false;
    public bool isckk2 = false;
    public bool isckk3 = false;

    // ���� �̰�... ��¶�� �� üũ�ϴ� ������
    public bool isMoveCk1 = true;
    public bool isMoveCk2 = true;
    public bool isMoveCk3 = true;

    // Ƣ��� ������Ʈ
    public GameObject fiyer;
    public GameObject BtnCube;

    // �ð� ����
    float curTime;
    public float curTime1;

    // Ƣ��� ��ư ������Ʈ
    public GameObject btn;
    // ��� �� ������Ʈ
    public GameObject ckBoll;
    public GameObject cube;
    // �� üũ ����
    public bool isbollCheck = true;
    // ���� �� ���� ���̰�
    public bool is1Score = true;
    public bool is2Score = true;

    public bool isAllScore = true;
    public int ckCount = 0;
    public int count = 0;

    //���ÿ� �ִ»��¸� true, �⸧�� �ִ»��¸� false
    public bool[] moveCKcheck = new bool[3];

    // Start is called before the first frame update
    void Start()
    {
        // �⸧ �� ������ ���Ƶα�
        cube.SetActive(true);
        print("Ƣ��� 180���� �����ϱ�");
        // �⸧ ������Ʈ���� ������ ã�ƿ���
        oilcolor = oil.GetComponent<Renderer>();

        // ġŲ ������Ʈ���� ������ ã�ƿ���
        ck1color = ck1.transform.GetChild(0).GetComponent<Renderer>();
        ck2color = ck2.transform.GetChild(0).GetComponent<Renderer>();
        ck3color = ck3.transform.GetChild(0).GetComponent<Renderer>();

        // ġŲ �� ���ϴ� ��ũ��Ʈ ���(ġŲ ���� ��)
        ct1 = ck1.GetComponent<ChickenTrigger>();
        ct2 = ck2.GetComponent<ChickenTrigger>();
        ct3 = ck3.GetComponent<ChickenTrigger>();

        // �Ŵ��� ������Ʈ �ȿ� �ִ� MIX ��ũ��Ʈ ����
        manager.GetComponent<Mix>().enabled = false;

        for (int i = 0; i < moveCKcheck.Length; i++)
        {
            //ġŲ ���� ��� ���ÿ� ����ִ� ä�� ����
            moveCKcheck[i] = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
     




        // ī�޶� ��ġ���� ���� ���
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        // ���� ���콺 ���� Ŭ���� ���� ��
        if (Input.GetMouseButtonDown(0))
        {
            // ���̸� ���� ��
            if (Physics.Raycast(ray, out hit))
            {
                // ������ ���� ���� ������Ʈ�� �±װ� Btn�̶��
                if (hit.transform.gameObject.tag == "Btn")
                {
                    count++;
                    // ��ư ȸ�� 
                    if (count == 1)
                    {
                        btn.transform.rotation = Quaternion.Euler(-30f, 0, 0);
                        print("120��");
                    }

                    if (count == 2)
                    {
                        btn.transform.rotation = Quaternion.Euler(-60, 0, 0);
                        print("140��");
                    }

                    if (count == 3)
                    {
                        btn.transform.rotation = Quaternion.Euler(-90, 0, 0);
                        print("180��");
                    }

                    print("���� �Ϸ�");
                    // ����Ÿ�� �ڷ�ƾ ����
                    StartCoroutine(LerpTime());

                }
                // ������ ���� ���� ������Ʈ�� �±װ� Oil�̶��
                else if (hit.transform.gameObject.tag == "Oil")
                {
                    BtnCube.SetActive(true);
                    // ġŲ ������Ʈ Ȱ��ȭ
                    chicken.SetActive(true);
                    print("������ Ŭ���ؼ� Ƣ��⿡ ��������");

                    if (count == 1)
                    {
                        print("����");

                        // ���� �� ���� �����ǰ�
                        if (is1Score == true)
                        {
                            ScoreManager.instance.GetScore();
                            is1Score = false;
                        }
                    }

                    if (count == 2)
                    {
                        print("����");
                        if (is2Score == true)
                        {
                            ScoreManager.instance.GetScore();
                            is2Score = false;
                        }

                    }

                    if (count == 3)
                    {
                        print("���");
                    }

                }

                // ġŲ ���� Ŭ���ؼ� �ֱ� == ��ǥ �� �ٲ��ֱ�
                else if (hit.transform.gameObject.tag == "ck1")
                {
                    if (moveCKcheck[0] == true)
                    { //�������� �������� ���°� �������� �ִ� ���¿���Vector3��
                        ck1.transform.position = oilck1Pos.transform.position;
                        moveCKcheck[0] = false; //ġŲ�� ���´� �⸧���� �̵��Ǿ���
                        isck1 = false;
                    }
                    else if (moveCKcheck[0] == false && isck1 == false && isMoveCk1 == true)
                    {
                        //�������� �������� ���°� �⸧�� �ִ� ���¿��ٸ�
                        ck1.transform.position = ck1pos.transform.position;
                        //���÷� �̵�
                       
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

                // �� üũ ������ �����ִٸ�
                if (isbollCheck == true)
                {
                    // ���� ���� ���� �±װ� ck�̰�(�׸�) Ƣ��⿡ ġŲ�� ���ٸ� 
                    if (hit.transform.gameObject.tag == "ck" && isck1 == false && isck2 == false && isck3 == false)
                    {
                        // ġŲ �׸� ����
                        chicken.SetActive(false);
                        // Ƣ��� ����
                        fiyer.SetActive(false);
                        // ��� ���̶� ġŲ �׸� ������
                        StartCoroutine(ckBollTime());

                        // ġŲ Ʈ���� ��ũ��Ʈ �� ����
                        ck1.GetComponent<ChickenTrigger>().enabled = false;
                        ck2.GetComponent<ChickenTrigger>().enabled = false;
                        ck3.GetComponent<ChickenTrigger>().enabled = false;

                        // �Ŵ��� ������Ʈ �ȿ� �ִ� Mix ��ũ��Ʈ Ű��
                        manager.GetComponent<Mix>().enabled = true;
                        // �Ŵ��� ������Ʈ �ȿ� �ִ� Fryer ��ũ��Ʈ ����
                        manager.GetComponent<Fryer>().enabled = false;

                        // GetComponent<Fryer>().enabled = false;
                        // �� üũ ���� �� �ֱ�
                        isbollCheck = false;
                    }
                }

            }
        }
    }


    // ��ư ȸ�� �ڷ�ƾ
    IEnumerator LerpTime()
    {  // �⸧ �� �ٲٱ�
        oilcolor.material.color = new Color(1, 0.71f, 0, 1);
        print("�� Ƣ�� �غ� �Ϸ� �⸧ Ŭ���ϱ�");
        // �⸧ ���� �� �ְ� �ϱ�
        cube.SetActive(false);

        yield return null;

    }


    IEnumerator ckBollTime()
    {
        // 2�� �ڿ�
        yield return new WaitForSeconds(2);
        // ��� �� �׸� �� �ֱ�
        ckBoll.SetActive(true);
        // ġŲ �׸� �� �ֱ�
        chicken.SetActive(true);
        yield return null;
    }
}

