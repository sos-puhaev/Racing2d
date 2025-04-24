using System.Collections;
using UnityEngine;

public class CoinSettings : MonoBehaviour
{
    CoinSpawner coinSpawner;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float speedCoin = 5f;
    void Start()
    {
        coinSpawner = GetComponent<CoinSpawner>();
        StartCoroutine(SpawnCoin());

    }

    IEnumerator SpawnCoin()
    {
        while (true)
        {
            coinSpawner.CreateCoin(speedCoin);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
