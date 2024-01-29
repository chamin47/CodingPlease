using UnityEngine;

public class RotateOnKeyPress : MonoBehaviour
{
	public float turnSpeed = 150.0f; // ȸ�� �ӵ� (��/��)
	public float moveSpeed = 5.0f;

	void Update()
	{
		transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
		// ���� Ű�� ���ȴ��� üũ
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			// �������� ȸ�� (�ð� �ݴ� ����)
			transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
		}
		// ������ Ű�� ���ȴ��� üũ
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			// ���������� ȸ�� (�ð� ����)
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
