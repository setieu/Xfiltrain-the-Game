using UnityEngine;
using System.Collections.Generic;

public class Gizmo : MonoBehaviour
{
    public Color gizmoColor = Color.red;
    public float gizmoRadius = 1f;

    [SerializeField]
    public List<Vector3> spawnPoints = new List<Vector3>();

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;

        foreach (Vector3 spawnPoint in spawnPoints)
        {
            Gizmos.DrawSphere(spawnPoint, gizmoRadius);
        }
    }

    public void AddSpawnPoint(Vector3 spawnPoint)
    {
        spawnPoints.Add(spawnPoint);
    }

    public void RemoveSpawnPoint(Vector3 spawnPoint)
    {
        spawnPoints.Remove(spawnPoint);
    }

    public Vector3 GetValidSpawnPosition(int index)
    {
        if (spawnPoints.Count > 0 && index < spawnPoints.Count)
        {
            return spawnPoints[index];
        }
        else
        {
            return Vector3.zero;
        }
    }
}


