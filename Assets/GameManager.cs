using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;

	private void Awake()
	{
		// instance가 할당되지 않았을 경우
		if (instance == null)
		{
			instance = this;
		}
		// instance에 할당된 클래스의 인스턴스가 다를 경우 새로 생성된 클래스를 의미함
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		// 다른 씬으로 넘어가더라도 삭제하지 않고 유지함
		DontDestroyOnLoad(this.gameObject);
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}