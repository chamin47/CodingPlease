using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private float speed = 10.0f;
	private void Update()
	{
		transform.Translate(Vector2.right * speed * Time.deltaTime);
	}
}
