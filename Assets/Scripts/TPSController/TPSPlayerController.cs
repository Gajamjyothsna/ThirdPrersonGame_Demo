using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace TPSGame
{
    public class TPSPlayerController : MonoBehaviour
    {
        [SerializeField] float playerSpeed = 5f;
        [SerializeField] float rotationSpeed = 500f;
        [Header("GroundCheck")]
        [SerializeField] private float groundCheckRadius = .2f;
        [SerializeField] private Vector3 groundCheckOffset;
        [SerializeField] private LayerMask groundLayer;

        private bool isGrounded;
        private float ySpeed;
        private UnityEngine.Quaternion targetRoatation;
        private CharacterController characterController;
        private Animator playerAnimator;
        private TPSCamera cameraController;

        private void Awake()
        {
            cameraController = Camera.main.GetComponent<TPSCamera>();
            playerAnimator = GetComponent<Animator>();
            characterController = GetComponent<CharacterController>();
        }
        private void Update()
        {
            float horizontalValue = Input.GetAxis("Horizontal");
            float verticalValue = Input.GetAxis("Vertical");

            float moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalValue)  + Mathf.Abs(verticalValue)); //check for player moving
            Vector3 movement = (new Vector3(horizontalValue, 0, verticalValue)).normalized; //sets the vector lenght to 1
            var moveDirection = cameraController.PlannarRotation * movement; // To make the player movement in camera direction

            GroundCheck();

            if(isGrounded)
            {
                ySpeed = -0.5f; //make sure to strict the player to ground
            }
            else
            {
                //if player is not grouned
                ySpeed += Physics.gravity.y * Time.deltaTime; //y speed should be increase 
            }
            var velocity = movement * playerSpeed;
            velocity.y = ySpeed;

            characterController.Move(velocity * Time.deltaTime);
            if (moveAmount > 0)
            {
                targetRoatation = Quaternion.LookRotation(moveDirection); //player to move facing towards camera;
            }
           transform.rotation = UnityEngine.Quaternion.RotateTowards(transform.rotation, targetRoatation, rotationSpeed * Time.deltaTime); // to rotate smoothly

            playerAnimator.SetFloat("moveAmount", moveAmount, 0.2f, Time.deltaTime); //to make the smooth out the animation

        }
        private void GroundCheck() //check player is grounded or not
        {
            //transform relates to player 
            isGrounded = Physics.CheckSphere(transform.TransformPoint(groundCheckOffset), groundCheckRadius, groundLayer);
        }
        private void OnDrawGizmosSelected() //draw gizmos
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.TransformPoint(groundCheckOffset), groundCheckRadius);
        }
        internal void CrounchingAnimation()
        {
            playerAnimator.SetFloat("Climbing", 0f);
        }
    }
}
