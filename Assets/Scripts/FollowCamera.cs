using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform followTarget;
    private BoxCollider2D cameraCollider2D;
    private Collider2D collider2D;

    [SerializeField]private float lerpSpeed = 1.0f;

    private Vector3 offset;
    private Vector3 targetPos;

    void Start()
    {
        if (followTarget == null) return;

        cameraCollider2D = GetComponent<BoxCollider2D>();

        offset = transform.position - followTarget.position;

        if(cameraCollider2D == null)
            Debug.Log("Null");
    }

    void Update()
    {
        if (followTarget == null) return;

        targetPos = followTarget.position + offset;

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

}
