using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeItem : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			GameManager.instance.life++;
			GameManager.instance.UpdateLifeUI();
			Destroy(gameObject);
		}
	}

}
