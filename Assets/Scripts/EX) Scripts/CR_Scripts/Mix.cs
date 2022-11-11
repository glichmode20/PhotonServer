using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mix : MonoBehaviour
{
    //���ÿ� �ִ»��¸� true, �⸧�� �ִ»��¸� false
    public bool[] moveCKcheck = new bool[3];
    // Start is called before the first frame update
    void Start()
    {
        ck1Color = ck1.GetComponent<Renderer>();
        ck2Color = ck2.GetComponent<Renderer>();
        ck3Color = ck3.GetComponent<Renderer>();

        for (int i = 0; i < moveCKcheck.Length; i++)
        {
            moveCKcheck[i] = true; //ġŲ ���� ��� ���ÿ� ����ִ� ä�� ����
        }
    }

    public GameObject ck1;
    public GameObject ck2;
    public GameObject ck3;

    public GameObject bollCk1Pos;
    public GameObject bollCk2Pos;
    public GameObject bollCk3Pos;

    public GameObject originCk1Pos;
    public GameObject originCk2Pos;
    public GameObject originCk3Pos;

    Renderer ck1Color;
    Renderer ck2Color;
    Renderer ck3Color;

    public GameObject spatulaR;
    public GameObject spatulaL;

    public float rotSpeed;
    public float rotSpeedX;

    public bool isck1 = true;
    public bool isck2 = true;
    public bool isck3 = true;

    public bool isCck1 = true;
    public bool isCck2 = true;
    public bool isCck3 = true;

    public bool isTck1 = true;
    public bool isTck2 = true;
    public bool isTck3 = true;

    public bool isCkTag = true;

    public GameObject rightHand;
    public GameObject ck;

    Transform grabbedObject = null;

    public bool isOne = true;
    public bool isTwo = true;
    public bool isThree = true;

    public bool isMixCheck = true;

    public int count = 0;

    public GameObject cube;

    // Update is called once per frame
    void Update()
    {

        MixChicken();
        //DropObject();
        
    }
    void MixChicken()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        // ���� ���콺 ���� Ŭ���� ���� ��
        if (Input.GetMouseButtonDown(0))
        {
            // ���̸� ���� ��
            if (Physics.Raycast(ray, out hit))
            {
                // ������ ���� ���� ������Ʈ�� �±װ� Btn�̶��
                if (hit.transform.gameObject.tag == "ck1" && isTck1 == true)
                {
                    if (moveCKcheck[0] == true && isCck1 == true)
                    { //�������� �������� ���°� �������� �ִ� ���¿���Vector3��
                        ck1.transform.position = bollCk1Pos.transform.position;
                        cube.SetActive(true);
                        moveCKcheck[0] = false;
                        isCck1 = false; //ġŲ�� ���´� �⸧���� �̵��Ǿ���
                    }
                    else if (moveCKcheck[0] == false && isck1 == true)
                    {
                        //�������� �������� ���°� �⸧�� �ִ� ���¿��ٸ�
                        ck1.transform.position = originCk1Pos.transform.position;
                        //���÷� �̵�
                        isck1 = false;

                        // �±� ������� ��������



                    }
                }

                if (hit.transform.gameObject.tag == "ck2" && isTck2 == true)
                {
                    if (moveCKcheck[1] == true && isCck2 == true)
                    { //�������� �������� ���°� �������� �ִ� ���¿���Vector3��
                        ck2.transform.position = bollCk2Pos.transform.position;
                        moveCKcheck[1] = false;
                        isCck2 = false; //ġŲ�� ���´� �⸧���� �̵��Ǿ���
                    }
                    else if (moveCKcheck[1] == false && isck2 == true)
                    {
                        //�������� �������� ���°� �⸧�� �ִ� ���¿��ٸ�
                        ck2.transform.position = originCk2Pos.transform.position;
                        //���÷� �̵�
                        isck2 = false;
                    }
                }
                if (hit.transform.gameObject.tag == "ck3" && isTck3 == true)
                {
                    if (moveCKcheck[2] == true && isCck3 == true)
                    { //�������� �������� ���°� �������� �ִ� ���¿���Vector3��
                        ck3.transform.position = bollCk3Pos.transform.position;
                        moveCKcheck[2] = false; //ġŲ�� ���´� �⸧���� �̵��Ǿ���
                        isCck3 = false;
                    }
                    else if (moveCKcheck[2] == false && isck3 == true)
                    {
                        //�������� �������� ���°� �⸧�� �ִ� ���¿��ٸ�
                        ck3.transform.position = originCk3Pos.transform.position;
                        //���÷� �̵�
                        isck3 = false;
                    }

                }

                if (hit.transform.gameObject.tag == "SpatulaR")
                {
                    if (count == 0 && isCck1 == false && isCck2 == false && isCck3 == false)
                    {
                        if (isOne == true)
                        {
                            isOne = false;
                            StartCoroutine(OneRot());

                        }
                    }

                    else if (count == 1 && isCck1 == false && isCck2 == false && isCck3 == false)
                    {
                        if (isTwo == true)
                        {
                            isTwo = false;
                            StartCoroutine(OneRot());
                        }
                    }
                    else if (count == 2 && isCck1 == false && isCck2 == false && isCck3 == false)
                    {
                        if (isThree == true)
                        {
                            isThree = false;
                            StartCoroutine(OneRot());

                            ck1Color.material.color = new Color(0.38f, 0.21f, 0, 1);
                            ck2Color.material.color = new Color(0.38f, 0.21f, 0, 1);
                            ck3Color.material.color = new Color(0.38f, 0.21f, 0, 1);
                            cube.SetActive(false);

                            GameObject.FindGameObjectWithTag("ck").transform.tag = "RealCk";
                  
                        }
                    }
                }
            }
        }
    }

   
    IEnumerator OneRot()
    {
        spatulaR.transform.Rotate(-7, 0, 0);
        spatulaL.transform.Rotate(7, 0, 0);

        yield return new WaitForSeconds(1);

        spatulaR.transform.Rotate(7, 0, 0);
        spatulaL.transform.Rotate(-7, 0, 0);

        isOne = true;
        isTwo = true;
        isThree = true;

        count++;
    }

}

