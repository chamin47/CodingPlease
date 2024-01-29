using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("회전속도 조절")]
    [SerializeField][Range(1f, 150f)] float rotateSpeed = 150f;

    [Header("속도 조절")]
    [SerializeField][Range(1f, 10f)] float speed = 3f;

    [Header("가속도 조절")]
    [SerializeField][Range(1f, 100f)] float fast = 2f;

    [Header("브레이크 조절")]
    [SerializeField][Range(1f, 100f)] float slow = 2f;

    private PlayerInputController _controller;
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        _controller = GetComponent<PlayerInputController>();
    }

    void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 vector)
    {
        moveVector = vector;
    }

    private void Movement(Vector2 vector)
    {
        if (vector.x != 0)
        {
            // 회전 기능 구현
            if (vector.x > 0)
            {
                transform.Rotate(0, 0, vector.x * -Time.deltaTime * rotateSpeed);
            }
            else if (vector.x < 0)
            {
                transform.Rotate(0, 0, vector.x * -Time.deltaTime * rotateSpeed);
            }
        }

        if (vector.y != 0)
        {
            // 부스트, 브레이크 기능 구현
            if (vector.y > 0)
            {
                rigidbody2D.velocity = transform.right * (speed + fast);
            }
            else if (vector.y < 0)
            {
                rigidbody2D.velocity = transform.right * (speed - slow);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
            GameManager.instance.GameOver();
        }
    }

    void FixedUpdate()
    {
        rigidbody2D.velocity = transform.right * speed;
        Movement(moveVector);
    }
}
