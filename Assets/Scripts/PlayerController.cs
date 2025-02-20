using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Vector2 moveDir = Vector2.zero;

    [SerializeField] private float speed = 5f;

    UIManager uIManager;

    public bool isCanIteractive { get; set; }

    private void Awake()
    {
        uIManager = FindObjectOfType<UIManager>();
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

    public void OnShowScoreUI(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            uIManager.BestScoreUI.ChangeBestScoreUIState();
        }
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
                Debug.Log(isCanIteractive);
            if (isCanIteractive)
            {
                SceneManager.LoadScene("FlappyGame");
            }
        }
    }

    public void OnDeleteScore(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            PlayerPrefs.DeleteAll();
        }

    }
 
}
