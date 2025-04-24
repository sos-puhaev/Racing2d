using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPositions;
    [SerializeField] CoinPool coinPool;

    public void CreateCoin(float speed)
    {
        int randomIndex = Random.Range(0, spawnPositions.Length);
        Vector3 spawnPos = spawnPositions[randomIndex].position;

        GameObject coin = coinPool.GetObject(spawnPos);
        if (coin.TryGetComponent(out CoinMove coinMove))
        {
            coinMove.speed = speed;
            coinMove.Init(coinPool);
        }
    }
}