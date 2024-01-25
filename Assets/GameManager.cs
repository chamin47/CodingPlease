using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;

	private void Awake()
	{
		// instance�� �Ҵ���� �ʾ��� ���
		if (instance == null)
		{
			instance = this;
		}
		// instance�� �Ҵ�� Ŭ������ �ν��Ͻ��� �ٸ� ��� ���� ������ Ŭ������ �ǹ���
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		// �ٸ� ������ �Ѿ���� �������� �ʰ� ������
		DontDestroyOnLoad(this.gameObject);
	}
}
