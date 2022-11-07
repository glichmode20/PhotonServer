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

    // ���� ġŲ ���� Ȯ��
    public GameObject ChickenBtn1;
    public GameObject ChickenBtn2;
    public GameObject ChickenBtn3;
    

    public GameObject customer;
    public GameObject ck;
    public Animator anim;

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

    bool isCustomer = true;

   
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

                print(hit.transform.name);

                // ������ ���� ���� ������Ʈ�� �±װ� Customer���
                if (hit.transform.gameObject.tag == "Customer")
                {
                    if(isCustomer == true)
                    {
                        CustomerText();
                        isCustomer = false;

                        customerUI.SetActive(true);
                        // �մ� ��ȭ â �ѱ�
                       Invoke("UISetActive", 3f);
                    }

                    // ġŲ ī��Ʈ�� 1�̰� ġŲ 1�̶�� �ؽ�Ʈ�� �� �ִٸ�
                    if (CounterTrigger.count == 1 && customerTxt.text == "ġŲ 1")
                    {
                        StartCoroutine(AnimTime());
                       
                        print("�����մϴ�");

                        
                        customerTxt.text = "�����մϴ�";
                        isCustomer = true;
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

                    // ġŲ ī��Ʈ�� 1�̰� ġŲ 1�̶�� �ؽ�Ʈ�� �� �ִٸ�
                    if (CounterTrigger.count == 2 && customerTxt.text == "ġŲ 2")
                    {
                        StartCoroutine(AnimTime());
                        print("�����մϴ�");
                        customerTxt.text = "�����մϴ�";
                        isCustomer = true;
                        anim.SetTrigger("Greetings");
                        CounterTrigger.count = 0;
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

                    if (CounterTrigger.count == 2 && customerTxt.text == "ġŲ 3")
                    {
                        print("�ϳ� �� ������");
                        ck.SetActive(false);

                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
                    }


                    // ġŲ ī��Ʈ�� 1�̰� ġŲ 1�̶�� �ؽ�Ʈ�� �� �ִٸ�
                    if (CounterTrigger.count == 3 && customerTxt.text == "ġŲ 3")
                    {
                        StartCoroutine(AnimTime());
                        print("�����մϴ�");
                        customerTxt.text = "�����մϴ�";
                        isCustomer = true;
                        CounterTrigger.count = 0;
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
                    }
                }
            }
        }

        StartCoroutine(CustomerTime());
    }

    public void CustomerText()
    {
        int rand = Random.Range(0, customerText.Count);
        print(customerText[rand]);

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
    
    IEnumerator AnimTime()
    {
        anim.SetTrigger("Greetings");
        yield return new WaitForSeconds(2f);
        // �մ� ����
        customer.SetActive(false);
        ck.SetActive(false);
    }
    
    IEnumerator CustomerTime()
    {
        if(customer.activeSelf == false)
        {
            // 2�� �ڿ�
            yield return new WaitForSeconds(2f);
            // �մ� ������
            customer.SetActive(true);

            customerTxt.text = "�մ� ����";
        }
       
    }

    void UISetActive()
    {
        //UI �ѱ�
        customerUI.SetActive(false);
    }
}
