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
	public float speed = 3.0f; // 이동 속도를 public 변수로 설정하여 에디터에서 조절 가능하게 함

	void Start()
	{
		target = GameObject.Find("Player");
		if (target != null)
		{
			transform.eulerAngles = new Vector3(0f, 0f, getAngle(transform.position.x, transform.position.y, target.transform.position.x, target.transform.position.y));
		}

		Invoke("DestroyBullet", 6.0f);

	}

	void Update()
	{
		transform.Translate(Vector2.right.normalized * speed * Time.deltaTime);
	}

	float getAngle(float x1, float y1, float x2, float y2)
	{
		float dx = x2 - x1;
		float dy = y2 - y1;
		float rad = Mathf.Atan2(dy, dx);
		float degree = rad * Mathf.Rad2Deg;
		return degree;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		// 플레이어와 충돌했는지 확인
		if (other.gameObject.CompareTag("Player"))
		{
			GameManager.instance.DecreaseLife();
			Destroy(gameObject);
		}
	}

	void DestroyBullet()
	{
		Destroy(gameObject);
	}
}
