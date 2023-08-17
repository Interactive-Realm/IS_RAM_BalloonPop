using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Touch : MonoBehaviour
{
    private Camera _mainCamera;
    private Vector3 position;

    void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        position = context.ReadValue<Vector2>();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if(!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(position));

        if (!rayHit.collider) return;
        Debug.Log(rayHit.collider.gameObject.name);
        Destroy(rayHit.collider.gameObject);
        
    }
}
