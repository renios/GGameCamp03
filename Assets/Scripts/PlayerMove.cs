using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed = 5;
    
    void Move() {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            transform.position += Vector3.right * Speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            transform.position += Vector3.left * Speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            transform.position += Vector3.up * Speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            transform.position+= Vector3.down * Speed * Time.deltaTime;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}

