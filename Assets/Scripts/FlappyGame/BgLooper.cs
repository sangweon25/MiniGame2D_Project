using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    //배경의 수
    private int numBgCnt = 5;
    public int obstacleCount = 0;
    //계속해서 다음 장애물을 생성하기 위한 장애물 마지막 위치
    private Vector3 obstacleLastPos= Vector3.zero;

    void Start()
    {
        //현재 씬에 Obstacle클래스를 가진 Object들을 배열로 저장
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
        //배열의 장애물위치를 장애물의 마지막 위치로 저장
        obstacleLastPos = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;
        //obstacles 배열크기만큼 반복
        for (int i = 0; i < obstacleCount; i++)
        {
            //반복을 하며 장애물들을 띄워서 생성, 마지막 장애물 위치를 변수에 저장
            obstacleLastPos = obstacles[i].SetRandomPlace(obstacleLastPos, obstacleCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //충돌이벤트가 일어난 콜리전의 Tag가 BackGround라면
        if(collision.CompareTag("BackGround"))
        {
            //BackGround 오브젝트의 위치를 collsion사이즈를 통해 얻어서 저장
            float bgObjectWidth = ((BoxCollider2D)collision).size.x;
            //collisio위치를 저장
            Vector3 pos = collision.transform.position;
            //collision.x 위치에 배경의 갯수만큼 더해서 저장
            //=>배경의 끝부분에 재생성
            pos.x += bgObjectWidth * numBgCnt;
            collision.transform.position = pos;
            //이미 collision이 BackGround이기 때문에 아래는 갈 필요없음.
            return;
        }

        // trigger된 obstacle을 저장
        Obstacle obstacle = collision.GetComponent<Obstacle>();
        //충돌된 물체가 obstacle이라면
        if(obstacle)
        {
            //충돌된 장애물을 배치해주고 return으로 배치한 위치를 받아서
            //다음 충돌된 장애물을 다음 위치를 안내해주기 위해서 저장
            obstacleLastPos = obstacle.SetRandomPlace(obstacleLastPos, obstacleCount);
        }
    }


}
