using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterTrigger : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ī���Ϳ� ġŲ�� �� �� ��Ҵ��� �� �� �ְ�
    public static int count = 0;

    private void OnCollisionEnter(Collision collision)
    {
        // ���� ī���Ϳ� ġŲ�� ��Ҵٸ� 
        if (collision.transform.gameObject.tag == "RealCk")
        {
            // +1
            count++;
            print(count + "���� ġŲ ī��Ʈ");

            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }

    }

}
