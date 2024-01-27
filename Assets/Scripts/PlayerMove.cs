using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    public float speed = 1.0f;

	private void Update()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		Vector2 dir = new Vector2 (h, v);

		transform.Translate( dir * speed * Time.deltaTime);
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Wall"))
		{
			Destroy(gameObject);
			GameManager.instance.GameOver();
		}
	}
}
