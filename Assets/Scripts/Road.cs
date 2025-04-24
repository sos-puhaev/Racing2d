using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private GameObject RoadTop, RoadBottom;
    GameManager GM;
    [SerializeField] float speed = 5f;
    private float RoadHeight;

    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        RoadHeight = RoadTop.GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        MoveRoadDown();
        if (RoadTop.transform.position.y + RoadHeight / 2 < GM.BottomCamBorder)
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
        RoadBottom.transform.position = new Vector3(
            RoadBottom.transform.position.x,
            RoadTop.transform.position.y + RoadHeight,
            RoadBottom.transform.position.z
        );

        (RoadTop, RoadBottom) = (RoadBottom, RoadTop);
    }

}
