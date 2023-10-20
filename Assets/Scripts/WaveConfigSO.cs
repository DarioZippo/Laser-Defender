using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    //Fattore di casualità dei ritardi
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;

    public int GetEnemyCount() {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index) {
        return enemyPrefabs[index];
    }

    public Transform GetStartingWaypoint() {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints() {
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform child in pathPrefab) {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float GetMoveSpeed() {
        return moveSpeed;
    }

    //Richiamato dall'enemySpawner ad ogni spawn
    public float GetRandomSpawnTime() {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance,
                                        timeBetweenEnemySpawns + spawnTimeVariance);
        //Essendo che la randomness tocca anche numeri negativi attorno a ad un perno (timeBetween), arrotondo 
        //tramite il minimumSpawnTime
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
