using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : MonoBehaviour
{
    [SerializeField] private GameObject dustPrefab;  // 먼지프리팹 오브젝트
    [SerializeField] private Transform Star; // 중심 항성
    [SerializeField] private int amount = 50;
    private float SpawnRange = 29.5f;

    void Start()
    {
        MakeDust(amount);
    }

    public void MakeDust(float input)
    {
        for (int i = 0; i < input; i++)
        {
            Vector2 randomVector = Random.insideUnitCircle.normalized; // 방향 랜덤
            float distance = Random.Range(10f, SpawnRange); // 태양보다 멀리 생성되고 맵밖에 나가면 안됨
            Vector2 spawnPos = (Vector2)Star.position + randomVector * distance; // 만들어지는 좌표

            GameObject dust = Instantiate(dustPrefab, spawnPos, Quaternion.identity);
            dust.transform.localScale = Vector3.one * Random.Range(0.4f, 0.6f); // 크기 랜덤

            Rigidbody2D rigidTemp = dust.GetComponent<Rigidbody2D>(); // 먼지의 리귀드바디 호
            if (rigidTemp != null)
            {
                Vector2 StarDirection = (Vector2)Star.position - spawnPos; // 중심(별)과의 방향 계산

               
                Vector2 tangent = Vector2.Perpendicular(StarDirection.normalized); // 중심기준 왼쪽 90도 직각회전 (아마도 시계방향?)

                
                float gravityStrength = GameManager.Instance.GameGravity; // 기본 15설정
                float orbitSpeed = Mathf.Sqrt(gravityStrength / distance); //중력 나누기 거리의 제곱근 = 공전속도

                rigidTemp.velocity = tangent * orbitSpeed;
            }
        }
    }
}
