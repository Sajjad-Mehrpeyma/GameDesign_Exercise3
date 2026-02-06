using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject obstaclePrefab;

    public Transform playerTransform;

    public float minDistance = 3f;

    public float maxDistance = 7f;

    public int maxObstacles = 10;

    public float laneOffset = 2f;

    private readonly List<GameObject> _spawned = new();
    private float _nextSpawnZ;

    private void Start()
    {
        if (playerTransform != null)
            _nextSpawnZ = playerTransform.position.z + 10f;
        else
            _nextSpawnZ = 10f;
    }

    private void Update()
    {
        if (obstaclePrefab == null || playerTransform == null) return;

        if (_spawned.Count < maxObstacles)
        {
            SpawnObstacle();
        }

        CleanupPassedObstacles();
    }

    private void SpawnObstacle()
    {
        int lane = Random.Range(0, 3);
        float laneX = (lane - 1) * laneOffset;

        Vector3 pos = new Vector3(laneX, 0.5f, _nextSpawnZ);
        GameObject obs = Instantiate(obstaclePrefab, pos, Quaternion.identity);
        _spawned.Add(obs);

        float distance = Random.Range(minDistance, maxDistance);
        _nextSpawnZ += distance;
    }

    private void CleanupPassedObstacles()
    {
        for (int i = _spawned.Count - 1; i >= 0; i--)
        {
            if (_spawned[i] == null)
            {
                _spawned.RemoveAt(i);
                continue;
            }

            if (_spawned[i].transform.position.z < playerTransform.position.z - 5f)
            {
                Destroy(_spawned[i]);
                _spawned.RemoveAt(i);
            }
        }
    }
}

