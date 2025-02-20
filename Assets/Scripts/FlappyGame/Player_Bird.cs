using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player_Bird : MonoBehaviour
{
    //속도설정을 위한 Rigidbody
    Rigidbody2D birdRigidbody;
    //Die 애니메이션을 위한 Animator
    Animator animator;

    //클릭할때 올라가는 정도
    [SerializeField]float flap = 4f;
    //새가 계속해서 가는 일정한 속도
    [SerializeField] float speed = 4f;
    //새의 기울기의 속도를 결정하는 변수
    [SerializeField] float slope = 10f;

    float deathCoolDown = 0f;

    //한번 클릭을 체크하기 위한 bool
    bool isFlap = false;
    //죽은지를 체크하기 위한 bool
    bool isDead = false;

    MiniGameManager miniGameManager;

    void Start()
    {
        miniGameManager = MiniGameManager.Instance;

        //컴포넌트 값을 사용하기 위해 GetComponent~
        birdRigidbody = GetComponent<Rigidbody2D>();  
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        //매 프레임 죽었다면 체크
        if(isDead)
        {
            //죽고나서 deathCoolDown 시간만큼 기다려야 재시작 가능
            deathCoolDown -= Time.deltaTime;

            miniGameManager.QuitText();
            //재시작 가능 시간이 되었다면
            if (deathCoolDown < 0)
            {

                //현재 미니게임 나가기
                miniGameManager.Quit_MiniGame();
            }
        }
    }

    private void FixedUpdate()
    {
        //죽었다면 if문 아래 내용 실행X
        if (isDead) return;
        //rigidbody의 속도를 x 값을 변수 speed값으로 저장
        Vector3 velocity = birdRigidbody.velocity;
        velocity.x = speed;

        //매 프레임마다 flap 입력을 받았는지 체크
        if(isFlap)
        {
            //입력을 받았다면 flap변수만큼 속도.y값을 flap 변수만큼 저장
            velocity.y += flap;
            //다시 재입력을 위한 isFlap = false;
            isFlap = false;
        }
        //velocity.x는 일정한 값이지만 isFlap의 여부에 따라서 y값의 속도가 달라진다.
        //=> 새가 뛰어오름.
        birdRigidbody.velocity = velocity;

        //Clamp함수를 이용해 45도와 -45도안으로 angle값을 제한
        float angle = Mathf.Clamp((birdRigidbody.velocity.y * slope),-45,45);
        //오일러 각을 쿼터니온으로 변환하여 bird의 rotation으로 저장
        transform.rotation = Quaternion.Euler(0,0,angle);
    }

    void OnFlap()
    {
        //Player_Input- Bird- FlapActions에 바인딩 된 키(Left Mouse Button)를 누를때마다 함수 호출 
        isFlap = true;

      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        animator.SetTrigger("IsDie");
        isDead = true;
        deathCoolDown = 2f;
    }
}
