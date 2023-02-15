using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private GameObject cam;
    
    [Header("Movement variables")]
    [SerializeField] private float _movementSpeed = 3f;
    [SerializeField] private float _jumpSpeed = 8f;
    // Player rotation being smooth is controlled by this. Not sure how..
    [SerializeField] private float turnSmoothTime = 0.1f;
    private float turnSmoothBase;

    [Header("Others")]
    [Tooltip("Gravity of earth is 9.8. That should be the default")]
    [SerializeField] private float gravity = 9.8f;
    private float verticalSpeed = 0f;

    private void Start()
    {
        // Cursor setup.
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

        //IF it's on ground, vertical speed is 0. Then it can jump or stay at 0. This avoids multiple jumps mid air.
        if (_characterController.isGrounded)
        {
            verticalSpeed = 0;
            if (Input.GetKeyDown(KeyCode.Space)) verticalSpeed = _jumpSpeed;
        }
        
        /* We should put the y first since this math function is y/x. However, Unity works the opposite so it's x/y.
       It returns the angle of given two points x and y. (Brackeys video: 12:45)*/
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
        // Way of smoothly change angles.
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothBase, turnSmoothTime); 
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; // Turns rotation into direction.
        verticalSpeed -= gravity * Time.deltaTime; // Applies gravity to vertical speed.
        moveDir.y = verticalSpeed; // Updates direction.

        // Avoids movement if there was no input.
        if (direction.magnitude == 0)
        {
            moveDir.z = 0f;
            moveDir.x = 0f;
        }
        
        _characterController.Move(moveDir.normalized * _movementSpeed * Time.deltaTime);
    }
}
