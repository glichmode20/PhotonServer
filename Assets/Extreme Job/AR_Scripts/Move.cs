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

        Cursor.visible = false;

        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Cursor.visible = true;
        }
        else if(Input.GetMouseButtonDown(0))
        {
            Cursor.visible = false;
        }
        

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = h * transform.right + v * transform.forward;
       
        dir.Normalize();

        yVelocity += gravity * Time.deltaTime;
       
        dir.y = yVelocity;

        // dir = Camera.main.transform.TransformDirection(dir);

        cc.Move(dir * speed * Time.deltaTime);
        
    }
}
