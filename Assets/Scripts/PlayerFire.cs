using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFire : MonoBehaviour
{  
    public float coolTime = 0.2f;
    private float curTime;

    public AudioClip clip;
	public AudioClip clip2;
    public GameObject bulletPrefab;
    public GameObject firePosition;
	public Image flashImage;
	public float flashDuration = 0.1f;

    void FixedUpdate()
    {
        if (curTime <= 0)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = firePosition.transform.position;
                bullet.transform.rotation = firePosition.transform.rotation;

                SoundManager.instance.SFXPlay("Fire", clip);
            }
            curTime = coolTime;
        }
        curTime -= Time.deltaTime;
    }

	private void Update()
	{
		// alt를 누르고 사용 가능 횟수가 남아있는 경우
		if (Input.GetKeyDown(KeyCode.LeftAlt) && GameManager.instance.clearAbilityCount > 0)
		{
			ClearEnemiesAndBullets();
			FlashScreenEffect();
			GameManager.instance.UseClearAbility(); // 사용 횟수 감소
		}
	}

	private void ClearEnemiesAndBullets()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (var enemy in enemies)
		{
			Destroy(enemy);
			GameObject gmObject = GameObject.Find("GameMgr");
			GameManager gm = gmObject.GetComponent<GameManager>();
			gm.killScore++;
			gm.killScoreUI.text = gm.killScore.ToString();
		}

		GameObject[] bullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
		foreach (var bullet in bullets)
		{
			Destroy(bullet);
		}
		SoundManager.instance.SFXPlay2("Bomb", clip2);
	}

	private void FlashScreenEffect()
	{
		StartCoroutine(DoFlash());
	}

	private IEnumerator DoFlash()
	{
		float time = 0;

		while (time < flashDuration)
		{
			time += Time.deltaTime;
			float alpha = Mathf.Sin(time / flashDuration * Mathf.PI);
			flashImage.color = new Color(1, 1, 1, alpha);
			yield return null;
		}

		flashImage.color = new Color(1, 1, 1, 0); // 번쩍임 종료 후 이미지를 다시 투명하게 만듦
	}
}
