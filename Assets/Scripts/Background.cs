using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // ��� ��Ƽ����
    public Material bgMaterial;
    // ��ũ�� �ӵ�
    public float scrollSpeed = 0.2f;

	private void Update()
	{
		Vector2 direction = Vector2.right;

		bgMaterial.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
	}
}
