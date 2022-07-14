using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentInput : MonoBehaviour
{
    private Camera mainCamera;

    [field: SerializeField]
    public UnityEvent<Vector2> OnMovementKeyPressed {get; set;}

    [field: SerializeField]
    public UnityEvent<Vector2> OnPointerPositionChange { get; set; }


    private void Update() {
        GetMovementInput();
        GetPointerInput();
    }

    private void GetPointerInput()
    {
        Vector3 mousePos = Input.mousePosition;
        // Prevents issues with clipping plane
        mousePos.z = mainCamera.nearClipPlane;
        // Find the screen position of the mouse and convert it to world point
        var mouseInWorldSpace = mainCamera.ScreenToWorldPoint(mousePos);
        OnPointerPositionChange?.Invoke(mouseInWorldSpace);
    }

    private void GetMovementInput() {
        OnMovementKeyPressed?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }

    private void Awake()
    { 
        // When awakened, find the camera in the scene tagged MainCamera and set it to our reference
        mainCamera = Camera.main;
    }

}
