using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private bool isJumping;
    private bool isGrounding;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public Rigidbody2D rigidBodyPlayer;
    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        isGrounding = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        if (Input.GetButtonDown("Jump") && isGrounding) //correspond à la barre espace
        {
            isJumping = true;
        }

        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rigidBodyPlayer.velocity.y);
        rigidBodyPlayer.velocity = Vector3.SmoothDamp(rigidBodyPlayer.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping)
        {
            rigidBodyPlayer.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }
}
