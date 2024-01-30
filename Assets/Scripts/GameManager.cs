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
	public GameState State = GameState.Ready; // 게임 상태 초기화
	public GameObject monster;
	public float createTime = 3.0f;    // 몬스터의 생성 간격
	public static GameManager instance = null;
	public GameObject gameoverUI;
	public TextMeshProUGUI currentScoreUI;    // 현재 점수 UI
	public Text lifeUI;  // 생명 UI
	public int currentScore;       // 현재 점수
	public int life = 3;
	public GameObject player;

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
	}

	private void Start()
	{
		life = 3;
		UpdateLifeUI(); // 게임 시작 시 생명 UI 업데이트
		State = GameState.Play; // 게임 시작 시 상태를 Play로 변경
		InvokeRepeating("CreateMonster", 2.0f, createTime);
	}

	private void Update()
	{
		if (life == 0)
		{
			GameOver();
		}		
	}

	// 생명이 줄어들 때마다 호출
	public void DecreaseLife()
	{
		if (life > 0)
		{
			life--;
			UpdateLifeUI();
		}
	}

	private void UpdateLifeUI()
	{
		lifeUI.text = new string('♥', life);
	}

	public void GameOver()
	{
		State = GameState.End; // 게임 오버 시 상태를 End로 변경
		gameoverUI.SetActive(true);
		Destroy(player);
	}

	public void RestartGame()
	{
		State = GameState.Play;  // 게임 재시작 시 상태를 Play로 변경
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void CreateMonster()
	{
		if (State == GameState.Play) // 게임 상태가 Play일 때만 몬스터 생성
		{
			Instantiate(monster);
		}

	}
}