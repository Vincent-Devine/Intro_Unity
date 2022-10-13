using System.Collections;
using UnityEngine;

public class WeakPointsLife : MonoBehaviour
{
    EnemyLife lifeBoss;

    GameObject player;

    public float timeReactivateCollision = 2f;

    // Start is called before the first frame update
    void Start()
    {
        lifeBoss = GetComponentInParent<EnemyLife>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform == player.transform)
        {
            // Push player
            player.GetComponent<PlayerData>().isBumped = true;
            player.GetComponent<Rigidbody>().AddForce(new Vector3(-30f, 25f, 0f), ForceMode.VelocityChange);
            // Desactiveted collision player
            player.GetComponent<CapsuleCollider>().enabled = false;
            
            GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(ReactivateCollision());
        }
    }

    IEnumerator ReactivateCollision()
    {
        yield return new WaitForSeconds(timeReactivateCollision);
        // Activeted collision player
        player.GetComponent<CapsuleCollider>().enabled = true;
        lifeBoss.DoDamage(player.GetComponent<PlayerData>().damage);
        gameObject.SetActive(false);
    }
}
