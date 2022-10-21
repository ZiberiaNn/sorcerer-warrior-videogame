using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class LockMovementController : MonoBehaviour
    {
        public float moveSpeed = 10f;
        public float jumpForce = 5f;
        public float rotationSpeed = 10f;
        public Transform groundCheck;
        public LayerMask ground;
        public Animator playerAnim;

        private Vector2 moveInputVector;
        private Rigidbody rigidBody;
        private bool canDoubleJump;
        private Transform cameraTransform;
        private Vector3 moveVector;
        private bool isJumping;
        private bool isGrounded;
        public Vector2 MoveInputVector { get => moveInputVector; set => moveInputVector = value; }
        public bool IsGrounded { get => isGrounded; set => isGrounded = value; }


        private void Start()
        {
            playerAnim = GetComponent<Animator>();
        }
        void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            rigidBody = GetComponent<Rigidbody>();
            cameraTransform = Camera.main.transform;
        }
        void FixedUpdate()
        {
            Move();
            Rotate();
            CheckIfFalling();
            CheckIfGrounded();
        }
        public void Move()
        {

            moveVector = new Vector3(moveInputVector.x * moveSpeed, rigidBody.velocity.y, moveInputVector.y * moveSpeed);

            moveVector = moveVector.x * cameraTransform.right.normalized + moveVector.z * cameraTransform.forward.normalized;
            moveVector.y = rigidBody.velocity.y;

            rigidBody.velocity = moveVector;
            if (moveInputVector != Vector2.zero)
            {
                playerAnim.SetBool("isRunning", true);
            }
            else
            {
                playerAnim.SetBool("isRunning", false);
            }
        }

        private void Rotate()
        {
        float targetAngle = cameraTransform.eulerAngles.y;
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 1);
    }

        public void Jump()
        {
            if (isGrounded)
            {
                rigidBody.velocity = new Vector3(moveInputVector.x * moveSpeed, jumpForce);
                playerAnim.SetBool("isJumping", true);
                //canDoubleJump = true;
            }
            //else if (canDoubleJump)
            //{
            //    rigidBody.velocity = Vector3.up * jumpForce;
            //    canDoubleJump = false;
            //}
        }

        private bool CheckIfFalling()
        {
            if (rigidBody.velocity.y < 0 && !isGrounded)
            {
                playerAnim.SetBool("isFalling", true);
                return true;
            }
            playerAnim.SetBool("isFalling", false);
            return false;
        }

        private void CheckIfGrounded()
        {
            if (Physics.CheckSphere(groundCheck.position, .1f, ground))
            {
                isGrounded = true;
                playerAnim.SetBool("isJumping", false);
                playerAnim.SetBool("isGrounded", true);
            }
            else
            {
                isGrounded = false;
                playerAnim.SetBool("isGrounded", false);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.transform.CompareTag("DeadZone"))
            {
                gameObject.SetActive(false);
            }
        }
    }
