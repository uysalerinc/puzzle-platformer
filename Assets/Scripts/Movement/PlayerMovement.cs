using System;
using UnityEngine;

namespace DEMO.Movement{
    
    public class PlayerMovement : MonoBehaviour {
        #region Components
        Animator animator;
        Rigidbody2D rb;
        #endregion

        #region Parameters
        float direction;
        [SerializeField] private float speed = 5f;
        const int MAX_AIR_JUMP_COUNT = 1;
        int airJumpCount = 0;
        bool isMoving;
        [SerializeField] private float jumpForce = 15f;
        #endregion
        #region Check Parameters
        [Header("Ground Check Parameters")]
        [SerializeField] Transform groundCheck;
        [SerializeField] Vector2 groundCheckSize;
        [SerializeField] LayerMask groundLayer;
        #endregion
        private void Awake() {
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
        }
        
        private void Update() {
            Movement();
            Jump();
            UpdateAnimator();
            
        }
            

        private bool isGrounded()
        {
            RaycastHit2D isGrounded = Physics2D.BoxCast(groundCheck.position, groundCheckSize, 0f, Vector2.down, 0f , groundLayer);
            Debug.DrawRay(groundCheck.position, new Vector3(groundCheckSize.x ,0 ,0), Color.green);
            Debug.DrawRay(groundCheck.position, new Vector3(0 ,-groundCheckSize.y ,0), Color.green);
            return isGrounded.collider != null;
           
        }

        private void Jump()
        {
            if (isGrounded() && Input.GetKeyDown(KeyCode.Space)){
                rb.velocity = new Vector2(0, jumpForce);
                airJumpCount = 0;
            } else if (Input.GetKeyDown(KeyCode.Space) && airJumpCount < MAX_AIR_JUMP_COUNT){
                rb.velocity = new Vector2(0, jumpForce);
                airJumpCount ++;
            }
        }

        private void UpdateAnimator()
        {
            animator.SetBool("isMoving", isMoving);
        }

        private void Movement()
        {
            direction = Input.GetAxisRaw("Horizontal");
            if (direction != 0)
            {
                transform.localScale = new Vector3(direction, 1, 1);
                transform.Translate(speed * Time.deltaTime * direction, 0, 0);
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
        }
    }
}