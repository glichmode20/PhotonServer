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
        // Ray ����
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hitInfo;
        int layer = 1 << LayerMask.NameToLayer("Item");
        // Ray �� ������
        if (Physics.Raycast(ray, out hitInfo, maxRayDistance, layer))
        {

            // ���� Object �� Outline ��ũ��Ʈ�� ������Ʈ�� �����´�.
            Outline outline = hitInfo.transform.GetComponent<Outline>();
            // Outline ������Ʈ�� ������ �ִٸ�
            // -> outline is not null
            if (outline != null)
            {
                // ������ hit �� object ���� outline �� ���ִ� ��
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
            // ������ hit �� object ���� outline �� ���ִ� ��
            foreach (GameObject go in hitObjects)
            {
                go.GetComponent<Outline>().OutlineWidth = 0;
            }
            hitObjects.Clear();
        }
    }


}
