using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShootingToTarget : MonoBehaviour
{
    //public GameObject TestTarget;
    //Transform Target { get; set; }

    
    //void Start()
    //{
        //Target = GameObject.TestTarget;
    //}

    
    //void Update()
    //{
        
    //}

    //float DistanceToTarget()
    //{
    //    return Vector3.Distance(transform.position, Target.position);
    //}

    GameObject target;
    public float speed = 5.0f; // �̵� �ӵ��� public ������ �����Ͽ� �����Ϳ��� ���� �����ϰ� ��

    void Start()
    {
        target = GameObject.Find("Player");
        transform.eulerAngles = new Vector3(0f, 0f, getAngle(transform.position.x, transform.position.y, target.transform.position.x, target.transform.position.y));
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    float getAngle(float x1, float y1, float x2, float y2)
    {
        float dx = x2 - x1;
        float dy = y2 - y1;
        float rad = Mathf.Atan2(dy, dx);
        float degree = rad * Mathf.Rad2Deg;
        return degree;
    }
}