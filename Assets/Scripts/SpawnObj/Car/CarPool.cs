using System.Collections.Generic;
using UnityEngine;

public class CarPool : MonoBehaviour
{
    [SerializeField] GameObject[] carPrefabs;
    [SerializeField] int poolSize = 5;

    private Dictionary<int, Queue<GameObject>> poolDictionary = new Dictionary<int, Queue<GameObject>>();

    void Start()
    {
        for (int i = 0; i < carPrefabs.Length; i++)
        {
            Queue<GameObject> carQueue = new Queue<GameObject>();

            for (int j = 0; j < poolSize; j++)
            {
                GameObject car = Instantiate(carPrefabs[i]);
                car.SetActive(false);
                carQueue.Enqueue(car);
            }

            poolDictionary.Add(i, carQueue);

        }
    }

    public GameObject GetCar(int prefabIndex, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(prefabIndex)) return null;

        GameObject car = poolDictionary[prefabIndex].Dequeue();

        car.transform.position = position;
        car.transform.rotation = rotation;
        car.SetActive(true);

        poolDictionary[prefabIndex].Enqueue(car);

        return car;
    }

    public void ReturnCarToPool(GameObject car)
    {
        car.SetActive(false);
    }

    public int PrefabCount => carPrefabs.Length;

}
