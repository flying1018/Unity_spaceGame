using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEdge : MonoBehaviour
{
    public Transform star;  // 중심 항성
    public float radius = 25f; // 게임맵크기 25

    void Update()
    {
        Vector2 temp = transform.position - star.position;
        if (temp.magnitude >= radius) // 벡터 길이가 맵크기(13)에 도달시
        {
            transform.position = star.position + (Vector3)(temp.normalized * radius);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
