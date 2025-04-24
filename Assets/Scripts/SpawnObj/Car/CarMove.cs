using UnityEngine;

public class CarMove : MonoBehaviour, IEnemyCarHitPlayer
{
    public float speed { set; get; }
    GameManager _gm;
    private CarPool carPool;
    private IReactEnemy reaction = new EnemyReplusion();

    public void Init(CarPool pool)
    {
        carPool = pool;
    }

    void Start()
    {
        _gm = GameManager.Instance;
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime, Space.World);

        if (transform.position.y / 2 < _gm.TopCamBorder)
        {
            if (carPool != null)
            {
                carPool.ReturnCarToPool(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void CarHitPlayer(Car car)
    {
         StartCoroutine(reaction.React(gameObject, car.transform.position));
         speed += 4;
    }
}
