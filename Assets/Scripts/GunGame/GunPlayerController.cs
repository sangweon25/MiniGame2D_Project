using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GunPlayerController : MonoBehaviour
{
    public GameObject projectile;
    private Camera camera;

    private Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection {  get { return lookDirection; } }

    public void Start()
    {
        camera = Camera.main;
        InvokeRepeating("MakeProjectile",0.5f,0.5f);
    }


    public void Update()
    {
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
        Debug.Log(lookDirection);
    }
    //void OnFire()
    //{
    //    if (EventSystem.current.IsPointerOverGameObject())
    //        return;
    //    //IsAttacking =true;
    //}

    void MakeProjectile()
    {
        Instantiate(projectile,new Vector2(transform.position.x-1, transform.position.y),Quaternion.identity);
    }
}
