using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpItem : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			GameManager.instance.clearAbilityCount++;
			Destroy(gameObject);
			Debug.Log(GameManager.instance.clearAbilityCount);
		}
	}
}
