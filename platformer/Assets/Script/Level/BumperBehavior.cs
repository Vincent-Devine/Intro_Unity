using UnityEngine;

public class BumperBehavior : MonoBehaviour
{
    public float jumpStrenght = 10;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<PlayerData>())
        {
            Rigidbody rb = collision.transform.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.AddForce(transform.up * jumpStrenght, ForceMode.Impulse);
            collision.transform.GetComponent<PlayerData>().isBumped = true;
        }
    }
}
