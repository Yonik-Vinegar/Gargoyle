using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class InputManager : MonoBehaviour
{
    public PlayerInputs PlayerControls;
    public PlayerInputs CameraControls;
    
    public Vector3 movementInput;
    public Vector3 mouseSensitivity;
    public float verticalInput;
    public float horizontalInput;

    public void OnEnable()
    {
        if (PlayerControls == null) 
        { 
            PlayerControls = new PlayerInputs();
            PlayerControls.PlayerMovement.WASD.performed += i => movementInput = i.ReadValue<Vector3>();  
        }

        if (CameraControls == null) 
        {
            CameraControls = new PlayerInputs();
            CameraControls.PlayerMovement.CameraDirections.performed += i => mouseSensitivity = i.ReadValue<Vector3>();
        }




        CameraControls.Enable();
        PlayerControls.Enable();
        
    }

    private void OnDisable()
    {
        PlayerControls.Disable();
        CameraControls.Disable();
       
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
    }

    public void HandleAllInputs()
    {

        HandleMovementInput();

    }
}
