using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] Transform[] transformSpawners;
    [SerializeField] CarPool carPool;

    public void AddCar(float speed)
    {
        int random_spawn = Random.Range(0, transformSpawners.Length);
        int random_car = Random.Range(0, carPool.PrefabCount);
        float random_speed = Random.Range(1f, 2f) * speed;

        GameObject car = carPool.GetCar(random_car, transformSpawners[random_spawn].position, Quaternion.identity);

        if (car != null)
        {
            CarMove carMove = car.GetComponent<CarMove>();
            if (carMove != null)
            {
                carMove.speed = random_speed;
            }
        }
    }
}

