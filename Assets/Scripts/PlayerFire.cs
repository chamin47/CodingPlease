using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefabs;
    public GameObject firePosition;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject bullet = Instantiate(bulletPrefabs);
            bullet.transform.position = firePosition.transform.position;

        }
    }
}
