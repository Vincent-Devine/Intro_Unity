using UnityEngine;

// Requirement
[RequireComponent(typeof(EnemyData))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]

public class EnemyMove : MonoBehaviour
{
    // Data
    EnemyData data;

    // Move
    Rigidbody rb;
    [HideInInspector] public bool goOnRighttDirection = true;
    Transform raycastLeft;
    Transform raycastRight;

    // Smart Enemy
    Transform player = null;
    [SerializeField] float distanceToPlayer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<EnemyData>();

        rb = GetComponent<Rigidbody>();
        raycastLeft = transform.GetChild(0);
        raycastRight = transform.GetChild(1);

        if (data.isSmartEnemy)
            player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (data.isSmartEnemy)
            distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (data.isSmartEnemy && distanceToPlayer < data.range)
            FollowPlayer();
        else
            Move();
    }

    void Move()
    {
        // check for direction changes
        if(!Physics.Raycast(raycastLeft.position, Vector3.down, 3f))
            goOnRighttDirection = true;
        else if(!Physics.Raycast(raycastRight.position, Vector3.down, 3f))
            goOnRighttDirection = false;

        // go on right or left
        if (goOnRighttDirection)
            rb.velocity = new Vector3(data.speed, rb.velocity.y, 0f);
        else
            rb.velocity = new Vector3(-data.speed, rb.velocity.y, 0f);
    }

    void FollowPlayer()
    {
        // check don't fall
        if (!Physics.Raycast(raycastLeft.position, Vector3.down, 3f) || !Physics.Raycast(raycastRight.position, Vector3.down, 3f))
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
            return;
        }

        rb.velocity = new Vector3(Vector3.Normalize(player.position - transform.position).x * data.speed, rb.velocity.y, 0f);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (data.isSmartEnemy && other.transform.GetComponent<PlayerMove>())
            player = other.transform;
    }
*/
      
}
