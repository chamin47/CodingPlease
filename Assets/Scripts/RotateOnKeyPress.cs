using UnityEngine;

public class RotateOnKeyPress : MonoBehaviour
{
	public float turnSpeed = 150.0f; // 회전 속도 (도/초)
	public float moveSpeed = 5.0f;

	void Update()
	{
		transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
		// 왼쪽 키가 눌렸는지 체크
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			// 왼쪽으로 회전 (시계 반대 방향)
			transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
		}
		// 오른쪽 키가 눌렸는지 체크
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			// 오른쪽으로 회전 (시계 방향)
			transform.Rotate(0, 0, -turnSpeed * Time.deltaTime);
		}
		else if (Input.GetKey (KeyCode.UpArrow))
		{
			moveSpeed = 7.5f;
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			moveSpeed = 2.5f;
		}
	}
}
