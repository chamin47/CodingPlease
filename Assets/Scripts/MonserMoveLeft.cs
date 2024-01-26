using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonserMoveLeft : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        float x = -9.3f;
        float y = Random.Range(-4.3f, 4.5f);

        transform.position = new Vector3(x, y, 0);

        InvokeRepeating("ShootingBullet", 0.0f, 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0.03f, 0, 0);
        if (transform.position.x > 9.4f)
        {
            Destroy(gameObject);
        }
    }

    void ShootingBullet()
    {
        float x = this.transform.position.x;
        float y = this.transform.position.y;
        Instantiate(bullet, new Vector3(x, y, 0), Quaternion.identity);
    }
}
