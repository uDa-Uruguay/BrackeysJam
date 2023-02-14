using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private GameObject cam;
    
    [SerializeField] private float _movementSpeed = 3f;
    [SerializeField] private float _jumpSpeed = 8f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    private float turnSmoothBase;

    [SerializeField] private float gravity = 9.8f;
    private float verticalSpeed = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontalAxis, 0f, verticalAxis).normalized; // By normalize it, it seems to fix the diagonal problem.

        //vSpeed check if is on ground. Then it can jump or stay at 0.
        if (_characterController.isGrounded)
        {
            verticalSpeed = 0;
            if (Input.GetKeyDown(KeyCode.Space)) verticalSpeed = _jumpSpeed;
        }
        
       
        if (_characterController.isGrounded) Debug.Log("Is grounded");
        
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y; /* We should put the y first since this math function is y/x. However, Unity works the opposite so it's x/y.
        It returns the angle of given two points x and y. (Brackeys video: 12:45)*/
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothBase, turnSmoothTime); // Way of smoothly change angles.
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; // Turns rotation into direction.
        verticalSpeed -= gravity * Time.deltaTime; // Applies gravity to vertical speed.
        moveDir.y = verticalSpeed; // Updates direction.

        if (direction.magnitude == 0)
        {
            moveDir.z = 0f;
            moveDir.x = 0f;
        }
        
        _characterController.Move(moveDir.normalized * _movementSpeed * Time.deltaTime);
    }
}
