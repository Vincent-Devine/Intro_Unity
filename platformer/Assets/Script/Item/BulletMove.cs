using UnityEngine;

[RequireComponent(typeof(BulletData))]

public class BulletMove : MonoBehaviour
{
    BulletData data;

    Rigidbody rb;

    Vector3 directionPlayer;

    float deathTime;

    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<BulletData>();
        rb = GetComponent<Rigidbody>();

        directionPlayer = Vector3.Normalize(GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(0f, 0.75f, 0f) - transform.position) * data.speed;

        deathTime = Time.deltaTime + data.lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = directionPlayer;

        //Death
        if (deathTime <= Time.deltaTime)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.GetComponent<PlayerLife>())
            Destroy(gameObject);
    }
}
