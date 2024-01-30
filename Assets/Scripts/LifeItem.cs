using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeItem : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			GameManager.instance.life++;
			GameManager.instance.UpdateLifeUI();
			Destroy(gameObject);
		}
	}
}
