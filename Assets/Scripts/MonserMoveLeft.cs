using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonserMoveLeft : MonoBehaviour
{
    public GameObject bullet;
    //public Transform TestTarget { get; set; }

    void Start()
    {
        float x = -9.3f;
        float y = Random.Range(-4.3f, 4.5f);

        transform.position = new Vector3(x, y, 0);

        InvokeRepeating("ShootingBullet", 0.0f, 0.5f);

    }

    void Update()
    {
        transform.position += new Vector3(0.03f, 0, 0);
        if (transform.position.x > 9.4f)
        {
            Destroy(gameObject);
        }

        //Debug.Log(TargetPosition().ToString());
    }

    void ShootingBullet()
    {
        float x = this.transform.position.x;
        float y = this.transform.position.y;
        Instantiate(bullet, new Vector3(x, y, 0), Quaternion.identity);
    }

    // public Vector2 TargetPosition()
    //{
    //    return (TestTarget.position);
    //}
}
