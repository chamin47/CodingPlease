using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerInputController : MonoBehaviour
{
    [Header("회전속도 조절")]
    [SerializeField][Range(1f, 150f)] float rotateSpeed = 30f;

    [Header("속도 조절")]
    [SerializeField][Range(1f, 10f)] float speed = 3f;

    [Header("가속도 조절")]
    [SerializeField][Range(1f, 100f)] float fast = 2f;

    [Header("브레이크 조절")]
    [SerializeField][Range(1f, 100f)] float slow = 2f;

    Rigidbody2D rigidbody2D;
    InputAction moveAction;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>();

        // moveinput의 x값이 0이 아니라 다른 값이 들어오면, 왼쪽이든 오른쪽이든 회전
        // y값이 0보다 작거나 0보다 크면 부스터 또는 브레이크

        // 왼쪽 누르면 왼쪽으로 회전, 오른쪽 누르면 오른쪽으로 회전, 위를 누르면 부스트, 아래를 누르면 브레이크
        // 회전, 부스트, 브레이크

        if (moveInput.x != 0)
        {
            // 회전 기능 구현
            if (moveInput.x > 0)
            {
                transform.Rotate(0, 0, moveInput.x * -Time.deltaTime * rotateSpeed);
            }
            else if (moveInput.x < 0)
            {
                transform.Rotate(0, 0, moveInput.x * -Time.deltaTime * rotateSpeed);
            }
        }

        if (moveInput.y > 0)
        {
            // 부스트 기능 구현
            rigidbody2D.velocity = transform.up * (speed + fast);
        }

        if (moveInput.y < 0)
        {
            // 브레이크 기능 구현 혹은 호출
            rigidbody2D.velocity = transform.up * (speed - slow);
        }
    }
    void Update()
    {
        rigidbody2D.velocity = transform.up * speed;
    }
}


    //public void onmove(InputValue value)
    //{
    //    float z = Input.GetAxisRaw("horizontal");

    //    transform.Rotate(0, 0, z * -time.deltatime * rotatespeed);

    //    rigidbody2D.velocity = transform.up * speed;

    //    if (input.getkey(keycode.uparrow))
    //    {
    //        rigidbody2D.velocity = transform.up * (speed + fast);
    //    }
    //    if (input.getkey(keycode.downarrow))
    //    {
    //        rigidbody2D.velocity = transform.up * (speed - slow);
    //    }
    //}
