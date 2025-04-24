using System.Collections;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    public float speed { set; get; }
    private GameManager _gm;
    [SerializeField] ParticleSystem deadEffect;

    private CoinPool _pool;
    private bool _isInitialized = false;


    public void Init(CoinPool pool)
    {
        if (_isInitialized) return;
        _pool = pool;
        _gm = GameManager.Instance;
        _isInitialized = true;
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y / 2 < _gm.TopCamBorder)
        {
            if (_pool != null)
            {
                _pool.ReturnToPool(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            if (deadEffect != null)
            {
                deadEffect.Play();
                StartCoroutine(WaitAndReturnToPool(deadEffect));
            }
            _gm.AddGold(1);
        }
    }

    private IEnumerator WaitAndReturnToPool(ParticleSystem effect)
    {
        yield return new WaitForSeconds(effect.main.duration);
        _pool.ReturnToPool(gameObject);
    }
}
