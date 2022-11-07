using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenTrigger : MonoBehaviour
{
    // Ƣ��� ��ư
    public GameObject btn;
    // Ƣ���
    public GameObject fryNet;
    // Ŭ�� ���ϰ� ���� ������Ʈ
    public GameObject cube;
    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        // ġŲ ���׸��� �ҷ�����
        ck1color = ck1.transform.GetChild(0).GetComponent<Renderer>();
        ck2color = ck2.transform.GetChild(0).GetComponent<Renderer>();
        ck3color = ck3.transform.GetChild(0).GetComponent<Renderer>();

        fryer = manager.transform.GetComponent<Fryer>();
    }


    // Update is called once per frame
    void Update()
    {


    }

    // ġŲ �� ����
    Renderer ck1color;
    Renderer ck2color;
    Renderer ck3color;

    // ġŲ ���� ����
    public GameObject ck1;
    public GameObject ck2;
    public GameObject ck3;

    // ġŲ �� �;����� Ȯ���ϴ� ����
    public bool isFry1 = false;
    public bool isFry2 = false;
    public bool isFry3 = false;

    Fryer fryer;
    private void OnTriggerEnter(Collider other)
    {
        // ���� ��Ƣ�� ������ �⸧�� ��Ҵٸ�
        if (other.gameObject.tag == "Oil")
        {
            // �ڷ�ƾ ����
            StartCoroutine(CkTime());
        }

    }

    public bool isck1 = true;
    public bool isck2 = true;
    public bool isck3 = true;
    // ��Ƣ�� �� ���ϴ� �ڷ�ƾ
    IEnumerator CkTime()
    {
        cube.SetActive(true);
        // 3�ʰ� ������
        yield return new WaitForSeconds(3);
        // ��Ƣ�� �� ���ϰ�
        ck1color.material.color = new Color(0.67f, 0.41f, 0, 1);
        ck2color.material.color = new Color(0.67f, 0.41f, 0, 1);
        ck3color.material.color = new Color(0.67f, 0.41f, 0, 1);

        cube.SetActive(false);
        // ġŲ �� �;����� Ȯ���ϴ� ����
        isFry1 = true;
        isFry2 = true;
        isFry3 = true;

        StartCoroutine(CkStop());

        //yield return new WaitForSeconds(3);
        /*
        fryNet.transform.position = Vector3.Lerp(fryNet.transform.position, fryNet.transform.position + Vector3.up * 25f, 0.3f * Time.deltaTime);

        ck1.transform.position = Vector3.Lerp(ck1.transform.position, ck1.transform.position + Vector3.up * 25f, 0.3f * Time.deltaTime);
        ck2.transform.position = Vector3.Lerp(ck2.transform.position, ck2.transform.position + Vector3.up * 25f, 0.3f * Time.deltaTime);
        ck3.transform.position = Vector3.Lerp(ck3.transform.position, ck3.transform.position + Vector3.up * 25f, 0.3f * Time.deltaTime);
        */
    }

    public IEnumerator CkStop()
    {
        // ���� ġŲ�� �� ���� ���¶��
        if (isFry1 == true && isFry2 == true && isFry3 == true)
        {
            // ���� ù ��° ġŲ ������ Ÿ�� �ʰ� 3�ʰ� �����ٸ�
            if (fryer.isckk1 == false && fryer.isck1 == false)
            {
                yield return new WaitForSeconds(3f);
                if (fryer.moveCKcheck[0] == false != fryer.isck1 == false != fryer.isMoveCk1 == true)
                {
                    // ġŲ ���� ���������� �ٲ۴�
                    ck1color.material.color = new Color(0, 0, 0, 1);
                    fryer.ckCount++;
                    ScoreManager.instance.GetOtherScore();
                    print("���������� ����");
                }

            }

            // ���� �� ��° ġŲ ������ Ÿ�� �ʰ� 3.5�ʰ� �����ٸ�
            if (fryer.isckk2 == false && fryer.isck2 == false)
            {
                yield return new WaitForSeconds(3.5f);
                if (fryer.moveCKcheck[1] == false != fryer.isck2 == false != fryer.isMoveCk2 == true)
                {
                    // ġŲ ���� ���������� �ٲ۴�
                    ck2color.material.color = new Color(0, 0, 0, 1);
                    fryer.ckCount++;
                    ScoreManager.instance.GetOtherScore();

                }
            }

            // ���� �� ��° ġŲ ������ Ÿ�� �ʰ� 4�ʰ� �����ٸ�
            if (fryer.isckk3 == false && fryer.isck3 == false)
            {
                yield return new WaitForSeconds(4);
                if (fryer.moveCKcheck[2] == false != fryer.isck3 == false != fryer.isMoveCk3 == true)
                {
                    // ġŲ ���� ���������� �ٲ۴�
                    ck3color.material.color = new Color(0, 0, 0, 1);
                    fryer.ckCount++;
                    ScoreManager.instance.GetOtherScore();
                }
            }
        }
    }
}

