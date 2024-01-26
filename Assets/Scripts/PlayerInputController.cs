using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerInputController : MonoBehaviour
{
    [Header("ȸ���ӵ� ����")]
    [SerializeField][Range(1f, 150f)] float rotateSpeed = 30f;

    [Header("�ӵ� ����")]
    [SerializeField][Range(1f, 10f)] float speed = 3f;

    [Header("���ӵ� ����")]
    [SerializeField][Range(1f, 100f)] float fast = 2f;

    [Header("�극��ũ ����")]
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

        // moveinput�� x���� 0�� �ƴ϶� �ٸ� ���� ������, �����̵� �������̵� ȸ��
        // y���� 0���� �۰ų� 0���� ũ�� �ν��� �Ǵ� �극��ũ

        // ���� ������ �������� ȸ��, ������ ������ ���������� ȸ��, ���� ������ �ν�Ʈ, �Ʒ��� ������ �극��ũ
        // ȸ��, �ν�Ʈ, �극��ũ

        if (moveInput.x != 0)
        {
            // ȸ�� ��� ����
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
            // �ν�Ʈ ��� ����
            rigidbody2D.velocity = transform.up * (speed + fast);
        }

        if (moveInput.y < 0)
        {
            // �극��ũ ��� ���� Ȥ�� ȣ��
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
