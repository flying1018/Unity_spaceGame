using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float thrustPower = 0.7f;     // 가속하는 힘의 크기
    public float mass = 100f;          // 행성 질량 초기값
    public float consume = 1f;  // 초당 질량 소모량
    public TextMeshProUGUI massText;
    private bool isInSun = false;
    private Rigidbody2D rigidTemp;

    void Start()
    {
        rigidTemp = GetComponent<Rigidbody2D>();
        rigidTemp.gravityScale = 0f; // 중력은 추후 따로 구현예정
        rigidTemp.drag = 0f;         // 관성은 일단 유지로
    }

    void Update()
    {
        PlayerMove();
        this.gameObject.transform.localScale = new Vector3(mass / 50, mass / 50, 1);

        if (isInSun && Input.GetKeyDown(KeyCode.F))
        {
            TiggerStar();
        }

        if (mass <= 90f)
        {
            GameManager.Instance.GameOver(1);
        }
        else if (mass >= 120f)
        {
            GameManager.Instance.GameOver(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D tag)
    {
        if (tag.CompareTag("dust"))
        {
            mass += tag.gameObject.transform.localScale.x * 2; // 질량 증가
            Destroy(tag.gameObject); // 먼지 제거
        }
        else if (tag.CompareTag("Star"))
        {
            isInSun = true;
            ShowEvent();
        }
    }

    private void OnTriggerExit2D(Collider2D tag)
    {
        if (tag.CompareTag("Star"))
        {
            isInSun = false;
        }
    }

    private void PlayerMove()
    {
        if (Input.GetMouseButton(0) && mass > 0f)
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mouseWorldPos - transform.position).normalized; // 마우스 클릭시 행성,마우스 위치의 벡터방향 계산

            rigidTemp.AddForce(direction * thrustPower, ForceMode2D.Force);

            // 1초에 질량 1씩 감소
            mass -= consume * Time.deltaTime;
        }

        if (massText != null)
            massText.text = "Mass : " + Mathf.Max(0f, mass).ToString("F1");
    }

    public void ShowEvent()
    {
        Debug.Log("press F to play Evnet");
    }

    public void TiggerStar()
    {
        Debug.Log("eat Star's Mass"); 
        mass += 10f;
    }
}
