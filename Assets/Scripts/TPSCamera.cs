using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

namespace TPSGame
{
    public class TPSCamera : MonoBehaviour
    {
        #region private variables
        [SerializeField] private Transform followTarget;
        [SerializeField] private float distance;

        private float rotationY;
        private float rotationX;

        [SerializeField] private float minVerticalAngle = -45f;
        [SerializeField] private float maxVerticalAngle = 45f;
        [SerializeField] private UnityEngine.Vector2 offSet;
        [SerializeField] private float rotationSpeed = 2f;

        [SerializeField] private bool invertX;
        [SerializeField] private bool invertY;

        float invertXValue;
        float invertYValue;

        #endregion

        private void Start()
        {
            //disabling the visibility of mouse during runtime.
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        private void Update()
        {
            invertXValue = (invertX) ? -1f : 1f;
            invertYValue = (invertY) ? -1f : 1f;

            rotationX += Input.GetAxis("Mouse Y") * invertXValue * rotationSpeed; //rotating around vertical
            rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);
            rotationY += Input.GetAxis("Mouse X") * invertYValue * rotationSpeed; //Roatating around Horizontal
            var targetRotation = UnityEngine.Quaternion.Euler(rotationX, rotationY, 0);

            var focusPosition = followTarget.position + new UnityEngine.Vector3(offSet.x, offSet.y);
            transform.position = focusPosition - targetRotation * new UnityEngine.Vector3(0,0,distance); //To keep camera distance away from certain distance
            transform.rotation = targetRotation;
        }
    }
}
