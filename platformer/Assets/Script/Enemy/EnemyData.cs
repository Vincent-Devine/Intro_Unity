using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public int damage = 1;

    [Header("Life")]
    public int life = 1;
    public int luckDropExtraLife = 75; // % 100

    [Header("Move")]
    public int speed = 3;

    [Header("Smart Enemy")]
    public bool isSmartEnemy = false;
    public int range = 3;

    [Header("Boss")]
    public float rangeShoot = 10f;
    public float rateFire = 5f;
}
