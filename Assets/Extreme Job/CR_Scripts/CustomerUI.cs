using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerUI : MonoBehaviour
{
    // �մ�
    public GameObject customer;
    // customerUI ������Ʈ
    public GameObject customerUI;
    // ���� ��� �մ� ���� �������� ����
    public GameObject customerUIText;

    public GameObject ck;

    // �մ� �ؽ�Ʈ
    Text customerText;

    // �մ� ��
    Renderer curstomerColor;
    // Start is called before the first frame update
    void Start()
    {
        // �մ� ������ �ڷ�ƾ ����
        StartCoroutine(CustomerTime());
        // ĵ�������� �ؽ�Ʈ ã��
        customerUIText = customerUI.transform.GetChild(0).gameObject;
        // customerUI�� �ִ� �ؽ�Ʈ �ҷ�����
        customerText = customerUIText.GetComponent<Text>();
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
                    print("ġŲ �� ���� �ּ���");

                    // ���� �մ� �����̶� �ؽ�Ʈ�� ġŲ 1�� �ٲٱ�
                    customerText.text = "ġŲ �� ���� �ּ���";

                    TextPlay();
                }
            }
        }
    }
    IEnumerator CustomerTime()
    {
        // 2�� �ڿ�
        yield return new WaitForSeconds(2f);
        // �մ� ������
        customer.SetActive(true);
    }

    void TextPlay()
    {
        // ġŲ ī��Ʈ�� 1�̰� ġŲ 1�̶�� �ؽ�Ʈ�� �� �ִٸ�
        if (CounterTrigger.count == 1 && customerText.text == "ġŲ �� ���� �ּ���")
        {
            // �մ� ����
            customer.SetActive(false);
            ck.SetActive(false);
            print("�����մϴ�");
            customerText.text = "";
            GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
            GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
        }
       
        // ġŲ ī��Ʈ�� 1���� ũ�� ġŲ 1�̶�� �ؽ�Ʈ�� �� �ִٸ�
        else if (CounterTrigger.count > 1 && customerText.text == "ġŲ �� ���� �ּ���")
        {
            print("�̰� �ƴ��ݾƿ�!");
            ck.SetActive(false);
            customer.SetActive(false);
            // �մ� �� �ٲ��(ȭ����)
            curstomerColor.material.color = new Color(1, 0, 0, 1);
            GameObject.Find("@ResetManager").GetComponent<ResetManager>().Reset();
            GameObject.Find("@ResetManager").GetComponent<ResetManager>().CountReset();
        }

    }
}


