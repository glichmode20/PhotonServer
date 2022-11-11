using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenTrigger : MonoBehaviour
{
    // 튀김기 버튼
    public GameObject btn;
    // 튀김망
    public GameObject fryNet;
    // 클릭 못하게 막는 오브젝트
    public GameObject cube;
    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        // 치킨 머테리얼 불러오기
        ck1color = ck1.transform.GetChild(0).GetComponent<Renderer>();
        ck2color = ck2.transform.GetChild(0).GetComponent<Renderer>();
        ck3color = ck3.transform.GetChild(0).GetComponent<Renderer>();

        fryer = manager.transform.GetComponent<Fryer>();
    }


    // Update is called once per frame
    void Update()
    {


    }

    // 치킨 색 변수
    Renderer ck1color;
    Renderer ck2color;
    Renderer ck3color;

    // 치킨 조각 변수
    public GameObject ck1;
    public GameObject ck2;
    public GameObject ck3;

    // 치킨 다 익었는지 확인하는 변수
    public bool isFry1 = false;
    public bool isFry2 = false;
    public bool isFry3 = false;

    Fryer fryer;
    private void OnTriggerEnter(Collider other)
    {
        // 만약 닭튀김 조각이 기름에 닿았다면
        if (other.gameObject.tag == "Oil")
        {
            // 코루틴 실행
            StartCoroutine(CkTime());
        }

    }

    public bool isck1 = true;
    public bool isck2 = true;
    public bool isck3 = true;
    // 닭튀김 색 변하는 코루틴
    IEnumerator CkTime()
    {
        cube.SetActive(true);
        // 3초가 지나면
        yield return new WaitForSeconds(3);
        // 닭튀김 색 변하게
        ck1color.material.color = new Color(0.67f, 0.41f, 0, 1);
        ck2color.material.color = new Color(0.67f, 0.41f, 0, 1);
        ck3color.material.color = new Color(0.67f, 0.41f, 0, 1);

        cube.SetActive(false);
        // 치킨 다 익었는지 확인하는 변수
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
        // 만약 치킨이 다 익은 상태라면
        if (isFry1 == true && isFry2 == true && isFry3 == true)
        {
            // 만약 첫 번째 치킨 조각이 타지 않고 3초가 지났다면
            if (fryer.isckk1 == false && fryer.isck1 == false)
            {
                yield return new WaitForSeconds(3f);
                if (fryer.moveCKcheck[0] == false != fryer.isck1 == false != fryer.isMoveCk1 == true)
                {
                    // 치킨 색을 검은색으로 바꾼다
                    ck1color.material.color = new Color(0, 0, 0, 1);
                    fryer.ckCount++;
                    ScoreManager.instance.GetOtherScore();
                    print("검은색으로 변함");
                }

            }

            // 만약 두 번째 치킨 조각이 타지 않고 3.5초가 지났다면
            if (fryer.isckk2 == false && fryer.isck2 == false)
            {
                yield return new WaitForSeconds(3.5f);
                if (fryer.moveCKcheck[1] == false != fryer.isck2 == false != fryer.isMoveCk2 == true)
                {
                    // 치킨 색을 검은색으로 바꾼다
                    ck2color.material.color = new Color(0, 0, 0, 1);
                    fryer.ckCount++;
                    ScoreManager.instance.GetOtherScore();

                }
            }

            // 만약 세 번째 치킨 조각이 타지 않고 4초가 지났다면
            if (fryer.isckk3 == false && fryer.isck3 == false)
            {
                yield return new WaitForSeconds(4);
                if (fryer.moveCKcheck[2] == false != fryer.isck3 == false != fryer.isMoveCk3 == true)
                {
                    // 치킨 색을 검은색으로 바꾼다
                    ck3color.material.color = new Color(0, 0, 0, 1);
                    fryer.ckCount++;
                    ScoreManager.instance.GetOtherScore();
                }
            }
        }
    }
}

