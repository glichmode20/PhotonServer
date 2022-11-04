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

    // Start is called before the first frame update
    void Start()
    {
        // ġŲ ���׸��� �ҷ�����
        ckcolor = GetComponent<Renderer>();
    }


    // Update is called once per frame
    void Update()
    {


    }

    // ġŲ �� ����
    Renderer ckcolor;

    // ġŲ ���� ����
    public GameObject ck1;
    public GameObject ck2;
    public GameObject ck3;

    // ġŲ �� �;����� Ȯ���ϴ� ����
    public bool isFry1;
    public bool isFry2;
    public bool isFry3;

    private void OnTriggerEnter(Collider other)
    {
        // ���� ��Ƣ�� ������ �⸧�� ��Ҵٸ�
        if (other.gameObject.tag == "Oil")
        {
            // �ڷ�ƾ ����
            StartCoroutine(CkTime());
        }

    }

    // ��Ƣ�� �� ���ϴ� �ڷ�ƾ
    IEnumerator CkTime()
    {
        cube.SetActive(true);
        // 3�ʰ� ������
        yield return new WaitForSeconds(3);
        // ��Ƣ�� �� ���ϰ�
        ckcolor.material.color = new Color(0.67f, 0.41f, 0, 1);

        // ġŲ �� �;����� Ȯ���ϴ� ����
        isFry1 = true;
        isFry2 = true;
        isFry3 = true;

        cube.SetActive(false);
        yield return new WaitForSeconds(3);
        /*
        fryNet.transform.position = Vector3.Lerp(fryNet.transform.position, fryNet.transform.position + Vector3.up * 25f, 0.3f * Time.deltaTime);

        ck1.transform.position = Vector3.Lerp(ck1.transform.position, ck1.transform.position + Vector3.up * 25f, 0.3f * Time.deltaTime);
        ck2.transform.position = Vector3.Lerp(ck2.transform.position, ck2.transform.position + Vector3.up * 25f, 0.3f * Time.deltaTime);
        ck3.transform.position = Vector3.Lerp(ck3.transform.position, ck3.transform.position + Vector3.up * 25f, 0.3f * Time.deltaTime);
        */
    }
}
