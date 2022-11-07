using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float speed = 5;
    float yVelocity;

    public float gravity = -20f;


    CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = h * transform.right + v * transform.forward;
       
        dir.Normalize();

        yVelocity += gravity * Time.deltaTime;
       
        dir.y = yVelocity;

     //   dir = Camera.main.transform.TransformDirection(dir);

        cc.Move(dir * speed * Time.deltaTime);
        
    }
}
