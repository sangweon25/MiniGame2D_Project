using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FollowCamera : MonoBehaviour
{
    //카메라가 따라다닐 위치
    public Transform followTarget;

    //카메라 보간 속도
    [SerializeField]private float lerpSpeed = 1.0f;

    //카메라의 영역제한 범위
    public float limitMinX, limitMinY, limitMaxX, limitMaxY;

    //카메라의 size를 계산받을 변수
    float cameraHalfWidth, cameraHalfHeight;

    //X축 카메라 위치 수정 값
    private float offsetX;
    //x,y축 카메라 위치 수정 값
    [SerializeField] private Vector2 offset;

    //카메라를 x축만 쓸지에 대한 bool
    public bool onlyMoveX = false;

    void Start()
    {
        if (followTarget == null) return;
        //카메라 높이 절반값을 저장
        cameraHalfHeight = Camera.main.orthographicSize;
        //카메라 너비 절반값을 저장(너비/높이 * 카메라의 사이즈)
        cameraHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;

        //오프셋 선택 메서드
        ChoiceOffset(onlyMoveX);
    }

    void Update()
    {
        if (followTarget == null) return;

        //카메라를 X축 이동만할때
        if(onlyMoveX)
        {
            Vector3 pos = transform.position;
            pos.x = followTarget.position.x + offsetX;
            transform.position = pos;

            return;
        }

        //카메라 영역제한 min ~ max
        //Clamp 첫번째 인수 followTarget.position.x는 limitMinX+ 카메라 절반 너비 , limitMaxX - 카메라 절반 너비를 벗어난 값을 저장받을수 없다.
        //limitPosition에 값이 저장될 new Vector3(x,y,z)에서 x는 제한된 값인 followTarget.position.x + offset.x가 저장되는 것
        //y축도 마찬가지
        Vector3 limitPosition = new Vector3(
        Mathf.Clamp(followTarget.position.x + offset.x, limitMinX + cameraHalfWidth, limitMaxX - cameraHalfWidth),   
        Mathf.Clamp(followTarget.position.y + offset.y, limitMinY + cameraHalfHeight, limitMaxY - cameraHalfHeight), 
        -10);

        //Lerp로 인해(시작위치, 도착위치,카메라의 따라가는 속도)
        //도착위치는 영역에 제한된 값이기때문에 followTarget이 실제로 아무리 멀어져도 limitPosition의 값은
        //제한된 범위의 값을 넘어가지 않기때문에 카메라는 따라가지 못하게된다.
        transform.position = Vector3.Lerp(transform.position, limitPosition, Time.deltaTime* lerpSpeed);
    }

    private void ChoiceOffset(bool useOffsetX)
    {
        if(useOffsetX)
        {
            offsetX = transform.position.x - followTarget.position.x;
        }
        else
        {
            offset = transform.position - followTarget.position;
        }
    }

}
