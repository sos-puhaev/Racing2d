using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    [SerializeField] private GameObject GrassTop, GrassBottom;
    GameManager GM;
    [SerializeField] float speed = 5f;
    private float GrassHeight;

    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        GrassHeight = GrassTop.GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        MoveRoadDown();
        if (GrassTop.transform.position.y + GrassHeight / 2 < GM.BottomCamBorder)
        {
            MoveRoadUp();
        }
    }

    private void MoveRoadDown()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void MoveRoadUp()
    {
        GrassBottom.transform.position = new Vector3(
            GrassBottom.transform.position.x,
            GrassTop.transform.position.y + GrassHeight,
            GrassBottom.transform.position.z
        );

        (GrassTop, GrassBottom) = (GrassBottom, GrassTop);
    }

}
