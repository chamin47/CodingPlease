using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [Header("회전속도 조절")]
    [SerializeField][Range(1f, 150f)] float rotateSpeed = 30f;

    [Header("속도 조절")]
    [SerializeField][Range(1f, 10f)] float speed = 3f;

    [Header("가속도 조절")]
    [SerializeField][Range(1f, 100f)] float fast = 2f;

    [Header("가속도 조절")]
    [SerializeField][Range(1f, 100f)] float slow = 2f;

    Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }



    void Update()
    { 
        float z = Input.GetAxisRaw("Horizontal");

        transform.Rotate(0, 0, z * -Time.deltaTime * rotateSpeed);

        rigidbody.velocity = transform.up * speed;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody.velocity = transform.up * (speed + fast);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidbody.velocity = transform.up * (speed - slow);
        }
    }
}
