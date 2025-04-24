using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float TopCamBorder {get; private set;}
    public float BottomCamBorder {get; private set;}
    public int Gold {get; private set;}

    void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    void Start()
    {
        TopCamBorder = Camera.main.ViewportToWorldPoint(new Vector2(0,0)).y;
        BottomCamBorder = Camera.main.ViewportToWorldPoint(new Vector2(0,1)).y;
        Gold = 0;
    }

    void Update()
    {
        
    }

    public void AddGold(int _gold)
    {
        Gold += _gold;
    }
}
