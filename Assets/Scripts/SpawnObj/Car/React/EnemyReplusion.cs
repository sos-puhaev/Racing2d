using System.Collections;
using UnityEngine;

public class EnemyReplusion : IReactEnemy
{
    public IEnumerator React(GameObject enemy, Vector2 awayFrom)
    {
        float pushDistance = 1f;
        float rotationAngle = 20f;
        float duration = 0.3f;
        float elapsed = 0f;

        Vector3 startPosition = enemy.transform.position;
        Vector3 direction = (enemy.transform.position - (Vector3)awayFrom).normalized;

        Vector3 targetPosition;
        float targetRotationZ;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                targetPosition = startPosition + new Vector3(pushDistance, 0, 0);
                targetRotationZ = -rotationAngle;
            }
            else
            {
                targetPosition = startPosition + new Vector3(-pushDistance, 0, 0);
                targetRotationZ = rotationAngle;
            }
        }
        else
        {
            targetPosition = startPosition + new Vector3(0, -pushDistance, 0);
            targetRotationZ = 0f;
        }

        float startAngle = enemy.transform.rotation.eulerAngles.z;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            enemy.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            float angle = Mathf.LerpAngle(startAngle, targetRotationZ, t);
            enemy.transform.rotation = Quaternion.Euler(0, 0, angle);

            yield return null;
        }
    }
}

