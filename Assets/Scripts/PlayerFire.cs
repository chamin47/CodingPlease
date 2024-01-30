using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{  
    public float coolTime = 0.2f;
    private float curTime;

    public AudioClip clip;
	public AudioClip clip2;
    public GameObject bulletPrefab;
    public GameObject firePosition;

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
		// alt�� ������ ��� ���� Ƚ���� �����ִ� ���
		if (Input.GetKeyDown(KeyCode.LeftAlt) && GameManager.instance.clearAbilityCount > 0)
		{
			ClearEnemiesAndBullets();
			GameManager.instance.UseClearAbility(); // ��� Ƚ�� ����
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
}
