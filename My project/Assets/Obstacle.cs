using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Tìm vị trí của va chạm
           // Vector3 collisionPosition = other.transform.position;

            // Đặt vị trí của người chơi thành vị trí của va chạm
          //  other.transform.position = collisionPosition;

            // Thực hiện các hành động khác nếu cần
           // Debug.Log("Player hit the obstacle and stopped at collision position: " + collisionPosition);
        }
    }


}


