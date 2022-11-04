using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public List<string> customerText = new List<string>() { "ġŲ �� ���� �ּ���", "ġŲ �� ���� �ּ���", "ġŲ �� ���� �ּ���" };
    public GameObject customerUI;
    // ���� ��� �մ� ���� �������� ����
    public GameObject customerUIText;

    public GameObject customer;
    public GameObject ck;


    Text customerTxt;
    // �մ� ��
    Renderer curstomerColor;
    // Start is called before the first frame update
    void Start()
    {
        // ĵ�������� �ؽ�Ʈ ã��
        customerUIText = customerUI.transform.GetChild(0).gameObject;
        // customerUI�� �ִ� �ؽ�Ʈ �ҷ�����
        customerTxt = customerUIText.GetComponent<Text>();
        // �մ� �� �ҷ�����
        curstomerColor = customer.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    { 

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        // ���� ���콺 ���� Ŭ���� ���� ��
        if (Input.GetMouseButtonDown(0))
        {
            // ���̸� ���� ��
            if (Physics.Raycast(ray, out hit))
            {
                // ������ ���� ���� ������Ʈ�� �±װ� Customer���
                if (hit.transform.gameObject.tag == "Customer")
                {
                    CustomerText();
                    // ġŲ ī��Ʈ�� 1�̰� ġŲ 1�̶�� �ؽ�Ʈ�� �� �ִٸ�
                    if (CounterTrigger.count == 1 && customerTxt.text == "ġŲ 1")
                    {
                        // �մ� ����
                        customer.SetActive(false);
                        ck.SetActive(false);
                        print("�����մϴ�");
                        CounterTrigger.count = 0;
                        print(CounterTrigger.count + "ġŲ ī��Ʈ �ʱ�ȭ �ߴ���");
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
                    }

                    if (CounterTrigger.count == 1 && customerTxt.text == "ġŲ 2")
                    {
                        print("�ϳ� �� ���ҵ�");
                        ck.SetActive(false);

                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();

                    }


                    if (CounterTrigger.count == 1 && customerTxt.text == "ġŲ 3")
                    {
                        print("�� �� �� ���ҵ�");
                        ck.SetActive(false);

                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
                    }

                    // ġŲ ī��Ʈ�� 1�̰� ġŲ 1�̶�� �ؽ�Ʈ�� �� �ִٸ�
                    if (CounterTrigger.count == 2 && customerTxt.text == "ġŲ 2")
                    {
                        // �մ� ����
                        customer.SetActive(false);
                        ck.SetActive(false);
                        print("�����մϴ�");
                        CounterTrigger.count = 0;
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
                    }

                    // ġŲ ī��Ʈ�� 1�̰� ġŲ 1�̶�� �ؽ�Ʈ�� �� �ִٸ�
                    if (CounterTrigger.count == 3 && customerTxt.text == "ġŲ 3")
                    {
                        // �մ� ����
                        customer.SetActive(false);
                        ck.SetActive(false);
                        print("�����մϴ�");
                        CounterTrigger.count = 0;
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
                    }

                    //// ġŲ ī��Ʈ�� 1���� ũ�� ġŲ 1�̶�� �ؽ�Ʈ�� �� �ִٸ�
                    //if (CounterTrigger.count > 1 && customerTxt.text == "ġŲ 1")
                    //{
                    //    print("�̰� �ƴ��ݾƿ�!");
                    //    ck.SetActive(false);
                    //    customer.SetActive(false);
                    //    // �մ� �� �ٲ��(ȭ����)
                    //    curstomerColor.material.color = new Color(1, 0, 0, 1);
                    //    CounterTrigger.count = 0;
                    //    GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
                    //    GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
                    //}

                    //// ġŲ ī��Ʈ�� 2���� ũ�� ġŲ 2�̶�� �ؽ�Ʈ�� �� �ִٸ�
                    //if (CounterTrigger.count > 2 && customerTxt.text == "ġŲ 2")
                    //{
                    //    print("�̰� �ƴ��ݾƿ�!");
                    //    ck.SetActive(false);
                    //    curstomerColor.material.color = new Color(1, 0, 0, 1);
                    //    CounterTrigger.count = 0;
                    //    GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
                    //    GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
                    //}

                    //// ġŲ ī��Ʈ�� 3���� ũ�� ġŲ 3�̶�� �ؽ�Ʈ�� �� �ִٸ�
                    //if (CounterTrigger.count > 3 && customerTxt.text == "ġŲ 3")
                    //{
                    //    print("�̰� �ƴ��ݾƿ�!");
                    //    ck.SetActive(false);
                    //    curstomerColor.material.color = new Color(1, 0, 0, 1);
                    //    CounterTrigger.count = 0;
                    //    GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
                    //    GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
                    //}
                }
            }
        }


        StartCoroutine(CustomerTime());
    }

    public void CustomerText()
    {
        int rand = Random.Range(0, customerText.Count);
        print(customerText[rand]);
        //customerText.RemoveAt(rand);

        if(customerText[rand] == "ġŲ �� ���� �ּ���")
        {
            customerTxt.text = "ġŲ 1";
        }

        if (customerText[rand] == "ġŲ �� ���� �ּ���")
        {
            customerTxt.text = "ġŲ 2";
        }

        if (customerText[rand] == "ġŲ �� ���� �ּ���")
        {
            customerTxt.text = "ġŲ 3";
        }
    }

    public void CustomerCk()
    {
        
    }

    IEnumerator CustomerTime()
    {
        if(customer.activeSelf == false)
        {
            // 2�� �ڿ�
            yield return new WaitForSeconds(2f);
            // �մ� ������
            customer.SetActive(true);
        }
       
    }
}
