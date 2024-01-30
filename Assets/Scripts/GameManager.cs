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
	public GameState State = GameState.Ready; // ���� ���� �ʱ�ȭ
	public GameObject monster;
	public float createTime = 3.0f;    // ������ ���� ����
	public static GameManager instance = null;
	public GameObject gameoverUI;
	public TextMeshProUGUI currentScoreUI;    // ���� ���� UI
	public Text lifeUI;  // ���� UI
	public int currentScore;       // ���� ����
	public int life = 3;
	public GameObject player;

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
		life = 3;
		UpdateLifeUI(); // ���� ���� �� ���� UI ������Ʈ
		State = GameState.Play; // ���� ���� �� ���¸� Play�� ����
		InvokeRepeating("CreateMonster", 2.0f, createTime);
	}

	private void Update()
	{
		if (life == 0)
		{
			GameOver();
		}		
	}

	// ������ �پ�� ������ ȣ��
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
		State = GameState.Play;  // ���� ����� �� ���¸� Play�� ����
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void CreateMonster()
	{
		if (State == GameState.Play) // ���� ���°� Play�� ���� ���� ����
		{
			Instantiate(monster);
		}

	}
}