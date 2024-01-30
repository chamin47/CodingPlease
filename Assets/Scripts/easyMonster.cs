using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class easyMonster : MonoBehaviour
{
	public AudioClip clip;
	public GameObject bulletPosition;

	Vector3 direction;
	float limitX = 9.4f;
	float speed = 3f;

    SpriteRenderer _spriteRenderer;


    void Start()
	{
        _spriteRenderer = GetComponent<SpriteRenderer>();
		SpawnPosition();
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
		int rndX = Random.Range(0, randomX.Length);
		if (rndX == 0)
		{
			float x = randomX[0];
			float y = Random.Range(-4.3f, 4.5f);
			transform.position = new Vector3(x, y, 0);

			direction = new Vector3(-speed, 0, 0);
			_spriteRenderer.flipX = true;
        }
		else
		{
			float x = randomX[1];
			float y = Random.Range(-4.3f, 4.5f);
			transform.position = new Vector3(x, y, 0);

			direction = new Vector3(speed, 0, 0);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Bullet"))
		{
			SoundManager.instance.SFXPlay("Explode", clip);
			Destroy(other.gameObject);
			Destroy(gameObject);

			GameObject gmObject = GameObject.Find("GameMgr");
			GameManager gm = gmObject.GetComponent<GameManager>();
			gm.killScore++;
			gm.killScoreUI.text = gm.killScore.ToString();
		}
		else if (other.gameObject.CompareTag("Player"))
		{
			GameManager.instance.DecreaseLife();

		}
	}
}
