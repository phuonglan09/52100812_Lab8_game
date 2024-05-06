using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Animator animator;
    private CameraController cameraController;
    void Start() {
        cameraController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
    }

    void Update() {
        float movementV = Input.GetAxis("Vertical");
        float movementH = Input.GetAxis("Horizontal");

        if (movementH < 0 && movementV == 0) {
            animator.SetFloat("PlayerSpeed", 0.2f);
        } else if (movementH > 0 && movementV == 0) {
            animator.SetFloat("PlayerSpeed", 0.4f);
        } else if (movementH == 0 && movementV != 0) {
            if (Input.GetKey(KeyCode.LeftShift)) {
                animator.SetFloat("PlayerSpeed", 6.0f);
            } else {
                animator.SetFloat("PlayerSpeed", 2.0f);
            }
        } else if (movementV == 0 && movementV == 0) {
            animator.SetFloat("PlayerSpeed", 0.0f);
        }

        if (Input.GetKeyDown(KeyCode.F)) {
            cameraController.ChangeViewMode();
        }
    }

    void Awake() {
        animator = GetComponent<Animator>();
        animator.SetFloat("PlayerSpeed", 1.0f);
    }
}
