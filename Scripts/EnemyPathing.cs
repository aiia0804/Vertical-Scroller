using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig wayconfig;
    List<Transform> wayPoints;
    int wayPointIndex = 0;

    void Start()
    {
        wayPoints = wayconfig.GetWayPoints();
        transform.position = wayPoints[wayPointIndex].transform.position;

    }

    void Update()
    {
        Move();
    }

    public void SetWayConvig(WaveConfig wayconfig)
    {
        this.wayconfig = wayconfig;
    }

    private void Move()
    {
        if (wayPointIndex < wayPoints.Count)
        {
            var targetPosition = wayPoints[wayPointIndex].transform.position;
            var movementThisFrame = wayconfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
