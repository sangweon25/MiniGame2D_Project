using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //Y 값만큼 위 또는 아래로 위치를 이동시키기 위한 필드
    public float highPosY = 1f;
    public float lowPosY = -1f;

    //top과 bottom Obstacle의 간격 
    public float gapSizeMin = 1f;
    public float gapSizeMax = 4f;

    //top,bottom 장애물 위치
    public Transform topObstacle;
    public Transform bottomObstacle;

    //값만큼 장애물을 띄워주는 역할
    public float widthPadding = 4f;

    public Vector3 SetRandomPlace(Vector3 lastPos, int obstacleCnt)
    {
        //top과 bottom 장애물의 간격의 최소와 최대값을 저장
        float gapSize = Random.Range(gapSizeMin, gapSizeMax);
        float halfGapSize = gapSize / 2;

        //장애물들에 위치를 부모의 위치에서 y값만 halfGapSize만큼 올려주거나 내려준다.
        //=> 장애물을 통과하는 사이 공간이 계속 생성될때마다 다르다.
        topObstacle.localPosition = new Vector3(0,halfGapSize);
        bottomObstacle.localPosition = new Vector3(0, -halfGapSize);

        //마지막위치를 받아와서 widthPadding 값만큼 x축 간격을 띄워준다.
        Vector3 placePos = lastPos + new Vector3(widthPadding, 0);
        //y값은 변수들의 사이값으로 위,아래 생성될때마다 다르다.
        placePos.y = Random.Range(lowPosY,highPosY);

        //장애물의 위치를 재 생성
        transform.position = placePos;

        return placePos;
    }


}
