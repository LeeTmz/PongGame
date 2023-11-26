using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    [SerializeField] private float speedPlayer;
    [SerializeField] private bool isPlayer1;   

    private void Update()
    {
        if (isPlayer1) MovePlayer1();
        else MovePlayer2();
    }

    void MovePlayer1() 
    {
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -4, 4));

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speedPlayer * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.up * -speedPlayer * Time.deltaTime);
        }
    }
    void MovePlayer2()
    {
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -4, 4));

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * speedPlayer * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.up * -speedPlayer * Time.deltaTime);
        }
    }
}
