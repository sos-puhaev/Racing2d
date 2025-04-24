using System.Collections;
using UnityEngine;

public class EnemyCarSettings : MonoBehaviour
{
    CarSpawner carSpawner;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float speedCar = 5f;
    void Start()
    {
        carSpawner = GetComponent<CarSpawner>();
        StartCoroutine(SpawnCars());
    }

    IEnumerator SpawnCars()
    {
        while (true)
        {
            carSpawner.AddCar(speedCar);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void ChangeCarSpeed(float newSpeed)
    {
        speedCar = newSpeed;
    }
}
