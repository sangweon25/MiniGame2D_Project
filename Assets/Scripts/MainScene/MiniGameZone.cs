using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameZone : MonoBehaviour , IInteractable
{
    [SerializeField] private GameObject go;

    public void Interact(PlayerController player)
    {
        player.isCanIteractive = !player.isCanIteractive;
        //Debug.Log(player.isCanIteractive);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            go.gameObject.SetActive(true);
            PlayerController player = collision.GetComponent<PlayerController>();
            Interact(player);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            go.gameObject.SetActive(false);
            PlayerController player = collision.GetComponent<PlayerController>();
            Interact(player);
        }
    }

    void Start()
    {
        if (go == null)
            Debug.Log("GameObject is Null");
    }

    void Update()
    {
        
    }
}
