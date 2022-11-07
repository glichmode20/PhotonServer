using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    [SerializeField]
    List<GameObject> hitObjects;

    public float maxRayDistance = 10f;


    // Start is called before the first frame update
    void Start()
    {
        hitObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        FireRay();
    }

    public void FireRay()
    {
        // Ray 생성
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hitInfo;
        int layer = 1 << LayerMask.NameToLayer("Item");
        // Ray 가 닿으면
        if (Physics.Raycast(ray, out hitInfo, maxRayDistance, layer))
        {

            // 닿은 Object 의 Outline 스크립트를 컴포넌트로 가져온다.
            Outline outline = hitInfo.transform.GetComponent<Outline>();
            // Outline 컴포넌트를 가지고 있다면
            // -> outline is not null
            if (outline != null)
            {
                // 기존에 hit 한 object 들의 outline 을 꺼주는 것
                foreach (GameObject go in hitObjects)
                {
                    go.GetComponent<Outline>().OutlineWidth = 0;
                }
                hitObjects.Clear();
                outline.OutlineWidth = 10f;
                hitObjects.Add(outline.gameObject);
            }

        }
        else
        {
            // 기존에 hit 한 object 들의 outline 을 꺼주는 것
            foreach (GameObject go in hitObjects)
            {
                go.GetComponent<Outline>().OutlineWidth = 0;
            }
            hitObjects.Clear();
        }
    }


}
