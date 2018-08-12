using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Single jumpFactor = 120;
    public Single movementSpeed = 8;
    private Rigidbody2D playerBody;
    private Boolean isGrounded;
    private LevelSettings levelSettings;

    // Use this for initialization
    public void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        levelSettings = GameHelpers.GetLevelSettings();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetButtonDown(StaticNames.ButtonJump) && isGrounded)
        {
            playerBody.AddForce(new Vector2(playerBody.velocity.x, jumpFactor * playerBody.mass * playerBody.gravityScale));
            isGrounded = false;
        }

        var move = Input.GetAxis(StaticNames.AxisX);
        playerBody.velocity = new Vector2(move * movementSpeed, playerBody.velocity.y);

        if (playerBody.position.y < (levelSettings.BoundsMin.y - 0.5f))
        {
            Die();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.tag)
        {
            case StaticNames.TagGround:
                isGrounded = true;
                break;
            case StaticNames.TagEnemy:
                Die();
                break;
            default:
                break;
        }
    }

    public void Die()
    {
        GameHelpers.LoadScene(Scene.Captured);
    }
}
