using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletPosition;
   
    Vector3 direction;
    float limitX = 9.4f;
    float speed = 3f;

    void Start()
    {
        SpawnPosition();

        InvokeRepeating("ShootingBullet", 0.0f, 0.5f);
    }

    void Update()
    {
        transform.position += direction * Time.deltaTime;
        if (transform.position.x < -limitX || limitX < transform.position.x)
        {
            Destroy(gameObject);
        }
    }

    void SpawnPosition()
    {
        float[] randomX = new float[] { 9.3f, -9.3f };
        Random.Range(0, randomX.Length);
        if (Random.Range(0, randomX.Length) == 0)
        {
            float x = randomX[0];
            float y = Random.Range(-4.3f, 4.5f);
            transform.position = new Vector3(x, y, 0);

            direction = new Vector3(-speed, 0, 0);
        }
        else if (Random.Range(0, randomX.Length) == 1)
        {
            float x = randomX[1];
            float y = Random.Range(-4.3f, 4.5f);
            transform.position = new Vector3(x, y, 0);

            direction = new Vector3(speed, 0, 0);
        }
    }

    void ShootingBullet()
    {
        Vector2 position = bulletPosition.transform.position;
        Instantiate(bullet, position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameObject gmObject = GameObject.Find("GameMgr");
            GameManager gm = gmObject.GetComponent<GameManager>();
            gm.currentScore++;
            gm.currentScoreUI.text = gm.currentScore.ToString();
        }
    }
}
