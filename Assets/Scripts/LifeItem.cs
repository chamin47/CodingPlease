using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeItem : MonoBehaviour
{
    public AudioClip clip;

    private void Start()
    {
        Invoke("DestroyItem", 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.SFXPlay2("Heal", clip);

            if (GameManager.instance.life < 3)
            {
                GameManager.instance.life++;
                GameManager.instance.UpdateLifeUI();
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    void DestroyItem()
    {
        Destroy(gameObject);
    }

}
