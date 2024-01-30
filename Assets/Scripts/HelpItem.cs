using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpItem : MonoBehaviour
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
            SoundManager.instance.SFXPlay2("Help", clip);

            if (GameManager.instance.clearAbilityCount < 3)
            {
                GameManager.instance.clearAbilityCount++;
                Destroy(gameObject);
                Debug.Log(GameManager.instance.clearAbilityCount);
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
