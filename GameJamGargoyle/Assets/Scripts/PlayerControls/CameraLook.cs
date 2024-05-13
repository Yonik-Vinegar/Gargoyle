using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
   public InputManager inputManager;
   public float mouseSensitivity = 25f;
    public Transform body;


    private float xRotation = 0;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {
        float mouseX = inputManager.CameraControls.PlayerMovement.CameraDirections.ReadValue<float>() * mouseSensitivity * Time.deltaTime;
        float mouseY = inputManager.CameraControls.PlayerMovement.CameraDirections.ReadValue<float>() * mouseSensitivity * Time.deltaTime;
        Debug.Log(1);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(value: xRotation, min: -90f, max: 90f);

       transform.localRotation = Quaternion.Euler(xRotation, y:0, z:0F);
       body.Rotate(eulers: Vector3.up * mouseX);

    }

}
