using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speedBall;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private GameObject effect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(speedBall, speedBall) * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        Instantiate(effect, transform.position, transform.rotation);       
    }
}
