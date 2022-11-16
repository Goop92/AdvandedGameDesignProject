using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController characterController;

    private Vector2 leftStickPosition;

    private Vector3 movmentVector;
    [SerializeField] private float maximumSpeed = 10;

    void Start()
    {
        characterController = GetComponent<CharacterController>();


    }

    // Update is called once per frame
    void Update()
    {

        if(leftStickPosition != Vector2.zero)
        {

            movmentVector = new Vector3(leftStickPosition.x, 0, leftStickPosition.y) * maximumSpeed;

        }
        else
        {

            movmentVector = new Vector3(0, 0, 0);


        }
        
        characterController.Move(movmentVector * Time.deltaTime);

    }

    private void OnMove(InputValue movementValue)
    {
        leftStickPosition = movementValue.Get<Vector2>();
    }
}
