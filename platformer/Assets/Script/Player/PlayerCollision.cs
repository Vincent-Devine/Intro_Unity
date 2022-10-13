using UnityEngine;

[RequireComponent(typeof(PlayerData))]
[RequireComponent(typeof(PlayerLife))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class PlayerCollision : MonoBehaviour
{
    PlayerData data;

    PlayerLife life;

    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<PlayerData>();
        life = GetComponent<PlayerLife>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Checkpoint
        if (other.transform.CompareTag("CheckPoint"))
            life.lastCheckPoint = other.transform;

        // DeathZone
        if (other.transform.GetComponent<DeathZoneData>())
            life.TakeDamage(other.transform.GetComponent<DeathZoneData>().damage);

        // Damage to enemy
        if (other.transform.GetComponent<EnemyLife>())
            other.transform.GetComponent<EnemyLife>().DoDamage(data.damage);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Enemy
        if (collision.transform.GetComponent<EnemyData>())
            life.TakeDamage(collision.transform.GetComponent<EnemyData>().damage);

        // Trap
        if (collision.transform.GetComponent<TrapData>())
            life.TakeDamage(collision.transform.GetComponent<TrapData>().damage);

        // Extra life
        if (collision.transform.GetComponent<ExtraLifeData>())
        {
            data.life += collision.transform.GetComponent<ExtraLifeData>().lifeToAdd;
            Destroy(collision.gameObject);
        }

        // Bullet
        if (collision.transform.GetComponent<BulletData>())
        {
            life.TakeDamage(collision.transform.GetComponent<BulletData>().damage);
            Destroy(collision.gameObject);
        }
    }
}
