using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Vector2 moveDir = Vector2.zero;

    [SerializeField] private float speed = 5f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move(moveDir);
    }
    private void Move(Vector2 dir)
    {
        dir *= speed;
        rigidbody.velocity = dir;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        if (input != null)
        {
            moveDir = new Vector3(input.x, input.y, 0);
        }
    }
 
}
