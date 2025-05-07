using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 0, -10);

    void LateUpdate()
    {
        if (player != null) {transform.position = player.position + offset;}
        else {Debug.Log("카메라 연결안됨");}
    }
}
