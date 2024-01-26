using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMoveController : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        //오른쪽, 왼쪽 Y축에 랜덤 생성

        float x = 9.3f;
        float y = Random.Range(-4.3f, 4.5f);

        transform.position = new Vector3(x, y, 0);

    }

    // Update is called once per frame
    void Update()
    {
        //오른족 또는 왼쪽으로 일정속도(랜덤속도도 가능)로 움직임 업데이트
        transform.position += new Vector3(-0.03f, 0, 0);
        if(transform.position.x<-9.4f)
        {
            Destroy(gameObject);
        }

    }
}
