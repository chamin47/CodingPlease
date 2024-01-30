using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("ÃÑ¾Ë ¼Óµµ")]
    [SerializeField][Range(1, 10)] float speed = 5f;

    private void Start()
    {
        Invoke("DestroyBullet", 2);
    }

    private void Update()
    {
        transform.Translate(Vector2.right.normalized * speed * Time.deltaTime);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
