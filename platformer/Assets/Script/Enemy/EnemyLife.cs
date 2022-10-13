using UnityEngine;

[RequireComponent(typeof(EnemyData))]
public class EnemyLife : MonoBehaviour
{
    // Data
    EnemyData data;

    public GameObject itemFolder;
    public GameObject extraLife;

    private void Start()
    {
        data = GetComponent<EnemyData>();
    }

    public void DoDamage(int damage)
    {
        data.life -= damage;

        if (data.life <= 0)
        {
            // Extra life
            if (Random.Range(0, 100) <= data.luckDropExtraLife)
                Instantiate(extraLife, transform.position, transform.rotation, itemFolder.transform);
            gameObject.SetActive(false);
        }
    }
}
