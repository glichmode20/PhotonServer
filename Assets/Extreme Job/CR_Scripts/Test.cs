using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public List<string> customerText = new List<string>() { "ġŲ �� ���� �ּ���", "ġŲ �� ���� �ּ���", "ġŲ �� ���� �ּ���" };
    public GameObject customerUI;

    public GameObject menuImage1;
    public GameObject menuImage2;

    // ���� ��� �մ� ���� �������� ����
    public GameObject customerUIText;


    // ����, �մԿ��� ���� UI
    public Text startQuest;

    public GameObject UIChicken1;
    public GameObject UIChicken2;
    public GameObject UIChicken3;

    public GameObject UIChickenbg1;
    public GameObject UIChickenbg2;
    public GameObject UIChickenbg3;

    public GameObject customer;
    public GameObject ck;
    public Animator anim;

    Text customerTxt;

    int InvokeCount = 0;

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

        startQuest.text = "�մԿ��� �ֹ��� �����ÿ�.";

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
                // ������ ���� ���� ������Ʈ�� �±װ� Customer���
                if (hit.transform.gameObject.tag == "Customer")
                {
                    if(isCustomer == true)
                    {
                        CustomerText();
                        isCustomer = false;
                        // �մ� ��ȭâ �ѱ�
                        customerUI.SetActive(true);
                        // ��ȭâ ����
                        Invoke("invokeUI", 2f);
                        startQuest.text = "";

                        //********* �޴� �ϱ� **********

                        Invoke("OnMenuImage", 3f);
                        Invoke("menuImage", 8f);
                     

                    }

                    // ġŲ ī��Ʈ�� 1�̰� ġŲ 1�̶�� �ؽ�Ʈ�� �� �ִٸ�
                    if (CounterTrigger.count == 1 && customerTxt.text == "ġŲ �� ���� �ּ���")
                    {
                        StartCoroutine(AnimTime());

                        // �մ� ��ȭâ �ѱ�
                        customerUI.SetActive(true);
                        // ��ȭâ ����
                        Invoke("invokeUI", 2f);

                        // ġŲ ī��Ʈ�� 1�� �Ǹ� �ѱ�
                        if(CounterTrigger.count == 1)
                        {
                            UIChicken1.SetActive(true);
                        }
                        
                  
                        print("�����մϴ�");
                        customerTxt.text = "�����մϴ�";
                        isCustomer = true;
                        CounterTrigger.count = 0;
                        print(CounterTrigger.count + "ġŲ ī��Ʈ �ʱ�ȭ �ߴ���");
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
                    }

                    if (CounterTrigger.count == 1 && customerTxt.text == "ġŲ �� ���� �ּ���")
                    {
                        print("�ϳ� �� ���ҵ�");
                        ck.SetActive(false);

                        // ġŲ ī��Ʈ�� 1�� �Ǹ� UIChicken1 �ѱ�
                        if (CounterTrigger.count == 1)
                        {
                            UIChicken1.SetActive(true);
                        }
              

                      
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
                    }

                    // ġŲ ī��Ʈ�� 1�̰� ġŲ 1�̶�� �ؽ�Ʈ�� �� �ִٸ�
                    if (CounterTrigger.count == 2 && customerTxt.text == "ġŲ �� ���� �ּ���")
                    {
                        StartCoroutine(AnimTime());

                        // ġŲ ī��Ʈ�� 1�̸� UIChicken1 �ѱ�
                        if (CounterTrigger.count == 1)
                        {
                            UIChicken1.SetActive(true);
                        }
  
                        // ġŲ ī��Ʈ�� 2�̸� UIChicken2 �ѱ�
                        if (CounterTrigger.count == 2)
                        {
                            UIChicken2.SetActive(true);
                        }
    
                    

                        // �մ� ��ȭâ �ѱ�
                        customerUI.SetActive(true);
                        // ��ȭâ ����
                        Invoke("invokeUI", 3f);

                        print("�����մϴ�");
                        customerTxt.text = "�����մϴ�";
                        isCustomer = true;
                        anim.SetTrigger("Greetings");
                        CounterTrigger.count = 0;
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
                    }


                    if (CounterTrigger.count == 1 && customerTxt.text == "ġŲ �� ���� �ּ���")
                    {
                        // ġŲ ī��Ʈ�� 1�̸� UIChicken1 �ѱ�
                        if (CounterTrigger.count == 1)
                        {
                            UIChicken1.SetActive(true);
                        }


                        print("�� �� �� ���ҵ�");
                        ck.SetActive(false);
                       
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
                    }

                    if (CounterTrigger.count == 2 && customerTxt.text == "ġŲ �� ���� �ּ���")
                    {

                        // ġŲ ī��Ʈ�� 2�̸� UIChicken2 �ѱ�
                        if (CounterTrigger.count == 2)
                        {
                            UIChicken2.SetActive(true);
                        }



                        print("�ϳ� �� ������");
                        ck.SetActive(false);

                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
                        GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
                    }


                    // ġŲ ī��Ʈ�� 1�̰� ġŲ 1�̶�� �ؽ�Ʈ�� �� �ִٸ�
                    if (CounterTrigger.count == 3 && customerTxt.text == "ġŲ �� ���� �ּ���")
                    {
                        StartCoroutine(AnimTime());

                        
                        // ġŲ ī��Ʈ�� 3�̸� UIChicken3 �ѱ�
                        if (CounterTrigger.count == 3)
                        {
                            UIChicken3.SetActive(true);
                        }


                        // �մ� ��ȭâ �ѱ�
                        customerUI.SetActive(true);
                        // ��ȭâ ����
                        Invoke("invokeUI", 3f);

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
            customerTxt.text = "ġŲ �� ���� �ּ���";

            UIChickenbg1.SetActive(true);
        }

        if (customerText[rand] == "ġŲ �� ���� �ּ���")
        {
            customerTxt.text = "ġŲ �� ���� �ּ���";

            UIChickenbg1.SetActive(true);
            UIChickenbg2.SetActive(true);
        }

        if (customerText[rand] == "ġŲ �� ���� �ּ���")
        {
            customerTxt.text = "ġŲ �� ���� �ּ���";

            UIChickenbg1.SetActive(true);
            UIChickenbg2.SetActive(true);
            UIChickenbg3.SetActive(true);
        }
    }
    
    IEnumerator AnimTime()
    {
        anim.SetTrigger("Greetings");
        yield return new WaitForSeconds(2f);
        // �մ� ����
        customer.SetActive(false);
        ck.SetActive(false);

        // UI ����(���� ��)
        UIChicken1.SetActive(false);
        UIChicken2.SetActive(false);
        UIChicken3.SetActive(false);

        // UI ����(���� ��)
        UIChickenbg1.SetActive(false);
        UIChickenbg2.SetActive(false);
        UIChickenbg3.SetActive(false);
    }
    
    IEnumerator CustomerTime()
    {
        if(customer.activeSelf == false)
        {
            // 2�� �ڿ�
            yield return new WaitForSeconds(2f);
            // �մ� ������
            customer.SetActive(true);

            //customerTxt.text = "�մ� ����";
        }
       
    }


    void invokeUI()
    {
        customerUI.SetActive(false);
    }

    void menuImage()
    {
        menuImage1.SetActive(false);
        menuImage2.SetActive(false);

    }

    void OnMenuImage()
    {
        menuImage1.SetActive(true);
        menuImage2.SetActive(true);

    }

   
}
