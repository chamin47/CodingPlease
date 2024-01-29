using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerInputController : CharacterController
{
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>();
        CallMoveEvent(moveInput);
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
