using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // 배경 머티리얼
    public Material bgMaterial;
    // 스크롤 속도
    public float scrollSpeed = 0.2f;

	private void Update()
	{
		Vector2 direction = Vector2.right;

		bgMaterial.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
	}
}
