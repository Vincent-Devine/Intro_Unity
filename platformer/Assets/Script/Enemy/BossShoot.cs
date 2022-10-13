using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyData))]
public class BossShoot : MonoBehaviour
{
    EnemyData data;

    GameObject player;

    public GameObject Bullet;
    public GameObject BulletFolder;

    [SerializeField] float distanceToPlayer;
    bool isStartShooting = false;

    // Shoot
    Transform canon;

    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<EnemyData>();
        player = GameObject.FindGameObjectWithTag("Player");
        canon = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {        
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if (data.rangeShoot > distanceToPlayer && !isStartShooting)
        {
            isStartShooting = true;
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        Instantiate(Bullet, canon.position, canon.rotation, BulletFolder.transform);
        yield return new WaitForSeconds(data.rateFire);
        StartCoroutine(Shoot());

    }
}
