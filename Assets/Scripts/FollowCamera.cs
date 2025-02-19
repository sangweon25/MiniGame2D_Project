using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform followTarget;
    private BoxCollider2D cameraCollider2D;
    private Collider2D collider2D;

    [SerializeField]private float lerpSpeed = 1.0f;

    private float offsetX;
    private Vector3 offset;
    private Vector3 targetPos;

    public bool onlyMoveX = false;


    void Start()
    {
        if (followTarget == null) return;

        cameraCollider2D = GetComponent<BoxCollider2D>();

        ChoiceOffset(onlyMoveX);

        if(cameraCollider2D == null)
            Debug.Log("Null");
    }

    void Update()
    {
        if (followTarget == null) return;

        if(onlyMoveX)
        {
            Vector3 pos = transform.position;
            pos.x = followTarget.position.x + offsetX;
            transform.position = pos;
        }
        else
            targetPos = followTarget.position + offset;

        if(onlyMoveX == false)
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime* lerpSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall"))
        {
            Debug.Log("IsWall");
            collider2D = collision;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collider2D = null;
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
