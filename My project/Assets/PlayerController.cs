using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  
        public float verticalValue;
        private Animator animator;
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();


        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                animator.SetFloat("Speed", 0.6F);
            }
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                animator.SetFloat("Speed", 1.5F);
            }
        }
        private void Awake()
        {
            verticalValue = transform.position.x;
            animator = GetComponent<Animator>();
            animator.SetFloat("Speed", 0.25F);
        }
    


}
