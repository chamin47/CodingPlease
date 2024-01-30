using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{  
    public float coolTime = 0.2f;
    private float curTime;

    public AudioClip clip;
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
}
