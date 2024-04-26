using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /*public float moveSpeed = 10f;
    Animator animator;
    AnimatorIDScript animatorIDs;

    void Start()
    {
        // Lấy reference tới Animator và AnimatorIDs component
        animator = GetComponent<Animator>();
        animatorIDs = GameObject.FindGameObjectWithTag("GameController").GetComponent<AnimatorIDScript>();
    }

    void Update()
    {
        // Bắt lấy input trên trục vertical (lên và xuống)
        float verticalInput = Input.GetAxis("Vertical");

        // Đặt giá trị biến Speed của animator controller thành 1:0
        animator.SetFloat(animatorIDs.speedParamID, Mathf.Abs(verticalInput));

        // Di chuyển người chơi
        transform.Translate(Vector3.forward * verticalInput * moveSpeed * Time.deltaTime);

        // Bắt lấy input trên trục horizontal (trái và phải)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Nếu người chơi đang ở trạng thái dừng (Idle)
        if (verticalInput == 0)
        {
            // Kiểm tra input horizontal để quay trái hoặc phải
            if (horizontalInput < 0)
            {
                animator.Play("TurnOnSpotLeftA");
            }
            else if (horizontalInput > 0)
            {
                animator.Play("TurnOnSpotRightA");
            }
        }
    }*/
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f; // Tốc độ quay

    Animator animator;
    AnimatorIDScript animatorIDs;

    void Start()
    {
        animator = GetComponent<Animator>();
        animatorIDs = GameObject.FindGameObjectWithTag("GameController").GetComponent<AnimatorIDScript>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Di chuyển người chơi
        transform.Translate(Vector3.forward * verticalInput * moveSpeed * Time.deltaTime);

        // Quay người chơi
        transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);

        // Đặt biến Speed của animator controller
        float speed = Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput); // Tính toán tốc độ dựa trên input
        animator.SetFloat(animatorIDs.speedParamID, speed);

        // Chơi animation quay khi đang ở trạng thái Idle và có input horizontal
        if (speed == 0 && horizontalInput != 0)
        {
            animator.Play(horizontalInput < 0 ? "TurnOnSpotLeftA" : "TurnOnSpotRightA");
        }
    }
}
