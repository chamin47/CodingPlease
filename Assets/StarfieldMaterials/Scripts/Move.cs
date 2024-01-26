using UnityEngine; 
using System.Collections;

public class Move : MonoBehaviour
{
    float Target;
	void Start()
	{
        //print("Thanks for buying this, if you need any support, email support@dilapidatedmeow.com. " +
        //    "Please note I cannot help with scripting related problems.");
	}

	void Update()
	{
        // 초기값 :Target += Time.deltaTime / 125;
        // 문제점 : 시간이 지나면 이미지가 더이상 확대되지 않고 멈춘다
        Target += Time.deltaTime /125;

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, Target), 0.05f);

	}
}