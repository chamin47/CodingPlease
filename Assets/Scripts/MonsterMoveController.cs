using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMoveController : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        //������, ���� Y�࿡ ���� ����

        float x = 9.3f;
        float y = Random.Range(-4.3f, 4.5f);

        transform.position = new Vector3(x, y, 0);

    }

    // Update is called once per frame
    void Update()
    {
        //������ �Ǵ� �������� �����ӵ�(�����ӵ��� ����)�� ������ ������Ʈ
        transform.position += new Vector3(-0.03f, 0, 0);
        if(transform.position.x<-9.4f)
        {
            Destroy(gameObject);
        }

    }
}
