using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TypewriterEffectLegacy : MonoBehaviour
{
	public Text uiText;
	public string story = "�巡�ﺼ ��Ȱ�� û���ϰ� ������ ���θ� �ϴ� õ������ ���� �ϳ��� ���� �ϼ��ߴ�.\r\n\r\n��� �ڵ��� �ϴ��� �Ӹ��� �� ���������� ��������\r\n\r\n������ �ϼ��Ƿ��� ���� �������� �� �ϴ��� õ������ ������ �븮�� �����ڵ���� �Ѹ��� �����ϴµ���\r\n\r\nõ������ �̵��� �Ѹ��� �����ڵ带 �ذ��ϰ� ������ �ϼ���ų �� ���� ���ΰ�!";
	public float typingSpeed = 0.1f;
	public float delay = 2.0f;

	private void Start()
	{
		StartCoroutine(TypeStory());
	}

	public void EndStory()
	{
		StartCoroutine(TransitionToGame());
	}

	IEnumerator TransitionToGame()
	{
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene("SampleScene");
	}

	IEnumerator TypeStory()
	{
		uiText.text = "";
		foreach (char letter in story.ToCharArray())
		{
			uiText.text += letter;
			yield return new WaitForSeconds(typingSpeed);
		}
		EndStory();
	}
}
