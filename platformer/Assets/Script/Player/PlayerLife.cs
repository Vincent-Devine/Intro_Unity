using UnityEngine;
using UnityEngine.UI;

// Requirement
[RequireComponent(typeof(PlayerData))]
[RequireComponent(typeof(Rigidbody))]

public class PlayerLife : MonoBehaviour
{
    PlayerData data;

    // Checkpoint
    Rigidbody rb;
    [HideInInspector] public Transform lastCheckPoint;

    public Text lifeUI;

    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<PlayerData>();
        rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        lifeUI.text = data.life.ToString();
    }

    public void TakeDamage(int damage)
    {
        data.life -= damage;
        MoveToLastCheckPoint();

        if (data.life <= 0)
        {
            // Draw life when player have 0 hp
            lifeUI.text = data.life.ToString();
            
            gameObject.SetActive(false);
        }
    }

    void MoveToLastCheckPoint()
    {
        rb.transform.position = lastCheckPoint.position;
    }
}
