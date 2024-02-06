using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPSGame
{
    public class TPSPlayerController : MonoBehaviour
    {
        [SerializeField] float playerSpeed = 5f;
        [SerializeField] float rotationSpeed = 500f;

        private UnityEngine.Quaternion targetRoatation;



        TPSCamera cameraController;
        private void Awake()
        {
            cameraController = Camera.main.GetComponent<TPSCamera>();
        }
        private void Update()
        {
            float horizontalValue = Input.GetAxis("Horizontal");
            float verticalValue = Input.GetAxis("Vertical");

            float moveAmount = Mathf.Abs(horizontalValue + verticalValue); //check for player moving
            Vector3 movement = (new Vector3(horizontalValue, 0, verticalValue)).normalized; //sets the vector lenght to 1
            var moveDirection = cameraController.PlannarRotation * movement; // To make the player movement in camera direction

            if(moveAmount > 0)
            {
                targetRoatation = Quaternion.LookRotation(moveDirection); //player to move facing towards camera;
                transform.position += movement * playerSpeed * Time.deltaTime;
            }
           transform.rotation = UnityEngine.Quaternion.RotateTowards(transform.rotation, targetRoatation, rotationSpeed * Time.deltaTime); // to rotate smoothly

        }
    }
}
