using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public bool isJumping;
    public bool isGrounding;

    private Rigidbody2D rigidBodyPlayer;


    private Vector3 velocity = Vector3.zero;
    private float moveInput;

    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;

    private void Start()
    {
        Invoke(nameof(randomByTime), 10f);
        rigidBodyPlayer = GetComponent<Rigidbody2D>();
        
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rigidBodyPlayer.velocity = new Vector2(moveInput * moveSpeed, rigidBodyPlayer.velocity.y);

    }

    void Update()
    {
        isGrounding = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }else if(moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (isGrounding == true && Input.GetKey(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rigidBodyPlayer.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rigidBodyPlayer.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }

            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }


        void randomByTime()
    {
        float gamma = 5f;
        Debug.Log(gamma * Mathf.Log(1 - (Random.Range(0f, 1f))));
        //return gamma * Mathf.Log(1 - (Random.Range(0f, 1f)));
    }
}
