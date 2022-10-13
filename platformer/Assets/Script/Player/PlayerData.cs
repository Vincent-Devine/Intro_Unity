using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int damage = 1;
    public int life = 5;

    [Header("Jump")]
    public float jumpHeight = 7f;
    public int jumpLimit = 1;

    [Header("Move")]
    public float speed = 350f;
    [HideInInspector] public bool isBumped = false;
}
