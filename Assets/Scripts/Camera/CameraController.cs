using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float zoomSpeed = 5f;
    public float min = 5f; // 카메라 범위 최소, 일단은 5까지만
    public float max = 15f; // 위와 동일 일단 15까지
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        float scrollMouse = Input.GetAxis("Mouse ScrollWheel");
        cam.orthographicSize -= scrollMouse * zoomSpeed;
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, min, max); // 무한하게 줌 커지, 작아지는거 방지
    }
}
