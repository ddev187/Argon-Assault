using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] InputAction movement;

    void Start()
    {
        
    }

    void OnEnable()
    {
        movement.Enable();
    }

    void OnDisable()
    {
        movement.Disable();
    }

    void Update()
    {
        float xRoll = movement.ReadValue<Vector2>().x;
        Debug.Log(xRoll);

        float yRoll = movement.ReadValue<Vector2>().y;
        Debug.Log(yRoll);
    }
}
