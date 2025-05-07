using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float gravityStrength = 1f; // G 값
    public GameObject star;

    void FixedUpdate()
    {
        GravityEffect();
    }

    public void GravityEffect()
    {
        
        foreach (Rigidbody2D rigidTemp in FindObjectsOfType<Rigidbody2D>()) // 주변에 Rigidbody2D 달린 물체들 탐색
        {
            if (rigidTemp.gameObject == gameObject) { continue; } // 본인은 제외

            Vector2 direction = (transform.position - rigidTemp.transform.position);
            float distance = direction.magnitude;

            // 너무 가까운 건 무시
            if (distance < 5f) continue;

            // 뉴턴 중력공식 일단 적용 F(중력) = G*M*m / r^2
            float forceMagnitude = gravityStrength / (distance * distance);
            Vector2 force = direction.normalized * forceMagnitude;

            rigidTemp.AddForce(force);
        }
    }
}

