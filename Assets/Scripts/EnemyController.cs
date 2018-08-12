using UnityEngine;
using System.Collections;
using System;

public class EnemyController : MonoBehaviour
{
    public Single Speed = 1f;
    private Single xDirection;

    // Use this for initialization
    void Start()
    {
        xDirection = 1;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xDirection, 0) * Speed;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == StaticNames.TagEnemyWall)
        {
            xDirection *= -1;
        }
    }
}
