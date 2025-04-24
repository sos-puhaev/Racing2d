using System.Collections;
using UnityEngine;

public interface IReactEnemy
{
   IEnumerator React(GameObject enemy, Vector2 awayFrom);
}
