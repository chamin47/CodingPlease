using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public GameObject monsterRight;
    public GameObject monsterLeft;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(monsterRight);
        Instantiate(monsterLeft);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
