using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;

public enum GameState
{
	Ready,
	Stage1,
	Stage2,
	End
}

public class GameManager : MonoBehaviour
{
	public AudioClip clip;
	public GameState State = GameState.Ready; // ���� ���� �ʱ�ȭ
	public GameObject monster;
	public GameObject easyMonster;
	public float createTime = 3.0f;    // ������ ���� ����
	public static GameManager instance = null;
	public GameObject gameoverUI;
	public TextMeshProUGUI killScoreUI;    // ���� ų�� UI
	public TextMeshProUGUI timeTxt;
	public TextMeshProUGUI scoreTxt;
	public float startTime; // ���ӽ��۽ð�
	public Text lifeUI;  // ���� UI
	public int killScore;       // ���� ų��
	public int life = 3;
	public GameObject player;
	public int clearAbilityCount = 2; // ClearEnemiesAndBullets ����� ��� ���� Ƚ��

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
	}

	private void Start()
	{
		startTime = Time.time; // �������� ���� �ð� �ʱ�ȭ
		life = 3;
		clearAbilityCount = 2; // ���� �� ��� ���� Ƚ�� �ʱ�ȭ
		UpdateLifeUI(); // ���� ���� �� ���� UI ������Ʈ
		State = GameState.Stage1; // ���� ���� �� ���¸� Play�� ����
		InvokeRepeating("CreateMonster", 2.0f, createTime);
		StartCoroutine(Stage2Delay(20.0f)); // 20�� �Ŀ� Stage2�� ��ȯ

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

		UpdateTimeUI();
		UpdateScore();
	}

	private void UpdateTimeUI()
	{
		float timeStageStart = Time.time - startTime;
		int minutes = (int)(timeStageStart / 60);
		int seconds = (int)(timeStageStart % 60);
		timeTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
	}

	public void UseClearAbility()
	{
		if (clearAbilityCount > 0)
		{
			clearAbilityCount--;
		}
	}

	// ������ �پ�� ������ ȣ��
	public void DecreaseLife()
	{
		if (life > 0)
		{
			life--;
			UpdateLifeUI();
            SoundManager.instance.SFXPlay3("collision", clip);
        }
    }

	private void UpdateScore()
	{
		float timeStageStart = Time.time - startTime;
		float score = killScore * 1 + (int)timeStageStart *0.5f; // ���⼭ ų ������ �ð��� �ջ�
		scoreTxt.text = score.ToString();
	}

	public void UpdateLifeUI()
	{
        lifeUI.text = new string('��', life);
	}

	public void GameOver()
	{
		State = GameState.End; // ���� ���� �� ���¸� End�� ����
		gameoverUI.SetActive(true);
		Destroy(player);
	}

	public void RestartGame()
	{
		State = GameState.Stage1;  // ���� ����� �� ���¸� Play�� ����
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void Menu()
	{
		SceneManager.LoadScene("StartMenu");
	}

	public void ExitGame()
	{
		Application.Quit();
	}


	public void CreateMonster()
	{
		if (State == GameState.Stage1) // ���� ���°� Stage1�� ���� ���� ����
		{
			Instantiate(easyMonster);
		}
		else if (State == GameState.Stage2)
		{
			Instantiate(monster); // Stage2 ���¿����� monster ����
			Instantiate(easyMonster);
		}     
    }
}