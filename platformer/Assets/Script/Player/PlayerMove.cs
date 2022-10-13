using UnityEngine;

// Requirement
[RequireComponent(typeof(GameInputs))]
[RequireComponent(typeof(PlayerData))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

public class PlayerMove : MonoBehaviour
{
    GameInputs gameInputs;
    PlayerData data;

    // Jump
    [SerializeField] int jumpNumber = 0;
    [SerializeField] bool isGrounded = false;

    // Move
    Rigidbody rb;

    // Animation
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        gameInputs = GetComponent<GameInputs>();
        data = GetComponent<PlayerData>();

        // Move
        rb = GetComponent<Rigidbody>();

        // Animation
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();
        if (isGrounded)
            data.isBumped = false;

        if (rb.velocity.y < 0f)
            rb.velocity += Physics.gravity * 2f *  Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Jump();

        if(!data.isBumped)
            Move();

        // Rotate player
        if (gameInputs.horizontalMove != 0f)
            transform.rotation = Quaternion.Euler(0f, 90f * gameInputs.horizontalMove, 0f);
    }

    void Move()
    {
        float horizontalMouvement = gameInputs.horizontalMove * data.speed * Time.deltaTime;
        rb.velocity = new Vector3(horizontalMouvement, rb.velocity.y, 0f);

        // Animator
        animator.SetFloat("Speed", rb.velocity.x);
    }

    void Jump()
    {
        if (gameInputs.jump && jumpNumber < data.jumpLimit)
        {
            rb.AddForce(Vector2.up * data.jumpHeight, ForceMode.VelocityChange);
            gameInputs.jump = false;
            data.isBumped = false;
            jumpNumber++;
        }
    }

    void CheckGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, .5f) && !hit.transform.GetComponent<BumperBehavior>() && !hit.transform.GetComponentInParent<BossShoot>())
        {
            isGrounded = true;

            // Reset jump
            jumpNumber = 0;
        }
        else
            isGrounded = false;
    }
}
