using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    int entry, idle, locomotion;

    void  Awake() {
        entry = Animator.StringToHash("Entry");
        idle = Animator.StringToHash("Idle");
        locomotion = Animator.StringToHash("Locomotion");
    }

    void Update()
    {
        
    }
}
