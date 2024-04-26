using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedCamera : MonoBehaviour
{
    public Transform target; // Người chơi
    public Vector3 offset; // Khoảng cách tương đối

    void Update()
    {
        // Camera di chuyển theo người chơi
        transform.position = target.position + offset;

        // Tự động xoay camera để nó luôn nằm phía sau người chơi
        transform.LookAt(target);
    }
}
