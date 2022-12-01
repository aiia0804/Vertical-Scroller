using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefb;
    [SerializeField] Transform pathPrefb;
    [SerializeField] float timeBetweenSpawn = 0.5f;
    [SerializeField] float numberOfEnemy = 5;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float randonFactor = 0.3f;

    public GameObject GetEnemyPrefb() { return enemyPrefb; }
    public List<Transform> GetWayPoints()
    {
        var waveWayPoints = new List<Transform>();
        foreach (Transform child in pathPrefb.transform)
        {
            waveWayPoints.Add(child);
        }
        return waveWayPoints;
    }
    public float GetTimeBetweenSpawn() { return timeBetweenSpawn; }
    public float GetNumberOfEnemy() { return numberOfEnemy; }
    public float GetMoveSpeed() { return moveSpeed; }
    public float GetRandomFactor() { return randonFactor; }






}
