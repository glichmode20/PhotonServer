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

    // Start is called before the first frame update
    void Start()
    {
        // 치킨 머테리얼 불러오기
        ckcolor = GetComponent<Renderer>();
    }


    // Update is called once per frame
    void Update()
    {


    }

    // 치킨 색 변수
    Renderer ckcolor;

    // 치킨 조각 변수
    public GameObject ck1;
    public GameObject ck2;
    public GameObject ck3;

    // 치킨 다 익었는지 확인하는 변수
    public bool isFry1;
    public bool isFry2;
    public bool isFry3;

    private void OnTriggerEnter(Collider other)
    {
        // 만약 닭튀김 조각이 기름에 닿았다면
        if (other.gameObject.tag == "Oil")
        {
            // 코루틴 실행
            StartCoroutine(CkTime());
        }

    }

    // 닭튀김 색 변하는 코루틴
    IEnumerator CkTime()
    {
        cube.SetActive(true);
        // 3초가 지나면
        yield return new WaitForSeconds(3);
        // 닭튀김 색 변하게
        ckcolor.material.color = new Color(0.67f, 0.41f, 0, 1);

        // 치킨 다 익었는지 확인하는 변수
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
