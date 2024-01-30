using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpItem : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			GameManager.instance.clearAbilityCount++;
			Destroy(gameObject);
		}
	}
}
