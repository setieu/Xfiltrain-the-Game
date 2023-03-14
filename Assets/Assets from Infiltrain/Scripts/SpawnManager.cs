using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Gizmo gizmo;

    public Vector3 GetRandomSpawnPoint()
    {
        int index = Random.Range(0, gizmo.spawnPoints.Count);
        return gizmo.GetValidSpawnPosition(index);
    }
}












