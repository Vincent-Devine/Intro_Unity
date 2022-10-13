using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    PlayerData playerData;
    EnemyData bossData;

    public GameObject gameOver;
    public GameObject victory;

    // Start is called before the first frame update
    void Start()
    {
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        bossData = GameObject.FindGameObjectWithTag("Boss").GetComponent<EnemyData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerData.life == 0)
            gameOver.SetActive(true);
        if (bossData.life == 0)
            victory.SetActive(true);
    }

    public void RetryButton(InputAction.CallbackContext context)
    {
        if (playerData.life == 0)
            SceneManager.LoadScene(0);
    }
}
