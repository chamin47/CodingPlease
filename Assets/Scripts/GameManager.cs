using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public enum GameState
{
	Ready,
	Stage1,
	Stage2,
	End
}

public class GameManager : MonoBehaviour
{
	public GameState State = GameState.Ready; // 게임 상태 초기화
	public GameObject monster;
	public GameObject easyMonster;
	public float createTime = 3.0f;    // 몬스터의 생성 간격
	public static GameManager instance = null;
	public GameObject gameoverUI;
	public TextMeshProUGUI currentScoreUI;    // 현재 점수 UI
	public Text lifeUI;  // 생명 UI
	public int currentScore;       // 현재 점수
	public int life = 3;
	public GameObject player;
	public int clearAbilityCount = 2; // ClearEnemiesAndBullets 기능의 사용 가능 횟수

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
		clearAbilityCount = 2; // 시작 시 사용 가능 횟수 초기화
		UpdateLifeUI(); // 게임 시작 시 생명 UI 업데이트
		State = GameState.Stage1; // 게임 시작 시 상태를 Play로 변경
		InvokeRepeating("CreateMonster", 2.0f, createTime);
		StartCoroutine(Stage2Delay(20.0f)); // 20초 후에 Stage2로 전환
	}

	IEnumerator Stage2Delay(float delay)
	{
		yield return new WaitForSeconds(delay);
		State = GameState.Stage2;
	}

	private void Update()
	{
		if (life == 0)
		{
			GameOver();
		}
	}

	public void UseClearAbility()
	{
		if (clearAbilityCount > 0)
		{
			clearAbilityCount--;
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

	public void UpdateLifeUI()
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
		State = GameState.Stage1;  // 게임 재시작 시 상태를 Play로 변경
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void CreateMonster()
	{
		if (State == GameState.Stage1) // 게임 상태가 Stage1일 때만 몬스터 생성
		{
			Instantiate(easyMonster);
		}
		else if (State == GameState.Stage2)
		{
			Instantiate(monster); // Stage2 상태에서는 monster 생성
			Instantiate(easyMonster);
		}     
    }
}