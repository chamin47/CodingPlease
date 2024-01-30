using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TypewriterEffectLegacy : MonoBehaviour
{
	public Text uiText;
	public string story = "드래곤볼 생활을 청산하고 개발자 공부를 하던 천진반은 게임 하나를 거의 완성했다.\r\n\r\n비록 코딩을 하느라 머리가 다 빠져버리긴 했지만…\r\n\r\n하지만 완성되려는 순간 프리저와 셀 일당이 천진반의 게임을 노리고 에러코드들을 뿌리기 시작하는데…\r\n\r\n천진반은 이들이 뿌리는 에러코드를 해결하고 게임을 완성시킬 수 있을 것인가!";
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
