using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState
{
	Ready,
	Play,
	End
}

public class GameManager : MonoBehaviour
{
	public GameState State;
	public GameObject monster;
	public float createTime = 3.0f;    // ������ ���� ����
	public static GameManager instance = null;
	public GameObject gameoverUI;
	public TextMeshProUGUI currentScoreUI;    // ���� ���� UI
	public int currentScore;       // ���� ����

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

	private void Start()
	{
		InvokeRepeating("CreateMonster", 2.0f, createTime);
	}

	public void GameOver()
	{
		gameoverUI.SetActive(true);
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void CreateMonster()
	{
		Instantiate(monster);
	}
}