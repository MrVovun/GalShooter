using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject Enemy;
    [SerializeField]
    private GameObject[] powerups;

    private GameManager _gameManager;

    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (_gameManager.gameOver == false)
        {
            Instantiate(Enemy, new Vector3(Random.Range(-6, 6), 8, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }

    public void StartSpawnRoutines()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    IEnumerator SpawnPowerupRoutine()
    {
        while (_gameManager.gameOver == false)
        {
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(powerups[randomPowerUp], new Vector3(Random.Range(-6, 6), 8, 0), Quaternion.identity);
            yield return new WaitForSeconds(15.0f);
        }
    }

}
