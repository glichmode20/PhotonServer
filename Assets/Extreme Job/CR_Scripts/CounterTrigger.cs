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

    // 카운터에 치킨이 몇 개 닿았는지 알 수 있게
    public static int count = 0;

    private void OnCollisionEnter(Collision collision)
    {
        // 만약 카운터에 치킨이 닿았다면 
        if (collision.transform.gameObject.tag == "RealCk")
        {
            // +1
            count++;
            print(count + "현재 치킨 카운트");

            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }

    }

}
