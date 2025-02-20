using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Camera camera;

    private Vector2 lookDirection = Vector2.zero;

    public void Start()
    {
        camera = Camera.main;
    }


    public void Update()
    {
        Rotate();
    }
    private void Rotate(Vector2 direction)
    {
        //방향 y,x를 받아서 Atan2를 활용해 그 사이 세타값(라디안)을 구한후 Degree로 변환하여 rotZ에 저장한다.
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Abs로 rotZ의 절대값을 구하고 90이 넘는다면 왼쪽에 있다는 뜻이므로 isLeft = true
        bool isLeft = Mathf.Abs(rotZ) > 90f;

    }


    void OnLook(InputValue inputValue)
    {
        //마우스의 좌표는 화면 해상도 좌표이고 
        Vector2 mousePosition = inputValue.Get<Vector2>();

        //ScreenToWorldPoint함수를 통해 해상도좌표를 월드좌표로변환
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
        //바라보는 방향은 마우스의 월드좌표에서 플레이어의 좌표를 빼주면 플레이어가 마우스를 바라보는 방향을 구할 수 있다.
        lookDirection = (worldPos - (Vector2)transform.position);

        lookDirection = lookDirection.normalized;
    }
}
