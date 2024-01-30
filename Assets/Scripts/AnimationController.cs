using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    static readonly int IsDead = Animator.StringToHash("IsDead");

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Dead()
    {
        animator.SetBool(IsDead, true);

    }

}
