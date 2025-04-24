using System.Collections;
using UnityEngine;

public interface IReactPlayer
{
    IEnumerator React(Car player, Vector2 direction);
}
