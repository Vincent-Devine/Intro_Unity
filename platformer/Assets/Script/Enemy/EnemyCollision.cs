using UnityEngine;

[RequireComponent(typeof(EnemyMove))]
[RequireComponent(typeof(Rigidbody))]
public class EnemyCollision : MonoBehaviour
{
    EnemyMove move;

    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<EnemyMove>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Change direction if touche enemy
        if (collision.transform.GetComponent<EnemyMove>())
            move.goOnRighttDirection = !move.goOnRighttDirection;
    }
}
