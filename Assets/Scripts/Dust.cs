using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : MonoBehaviour
{

    [SerializeField] private GameObject dustPrefab;  // 먼지프리팹 오브젝트
    [SerializeField] private Transform Star; // 중심 항성
    [SerializeField] private int amount = 50;
    private float radius = 30f;

    void Start()
    {
        MakeDust(amount);
    }

    public void MakeDust(float input)
    {
        for (int i = 0; i < input; i++)
        {
            Vector2 randomVector = Random.insideUnitCircle.normalized; // 방향 랜덤
            float distance = Random.Range(10f, radius); // 태양보다 멀리 생성되고 맵밖에 나가면 안됨
            Vector2 spawnPos = (Vector2)Star.position + randomVector * distance; // 만들어지는 좌표

            GameObject dust = Instantiate(dustPrefab, spawnPos, Quaternion.identity);
            dust.transform.localScale = Vector3.one * Random.Range(0.4f, 0.6f); // 크기 랜덤

            Rigidbody2D rigidTemp = dust.GetComponent<Rigidbody2D>();
            if (rigidTemp != null)
            {
                // 공전로직 계산
                Vector2 tangent = Vector2.Perpendicular((spawnPos - (Vector2)rigidTemp.position).normalized);
                rigidTemp.velocity = tangent * 1.5f; // 속도 크기 조정
            }
        }
    }
}
