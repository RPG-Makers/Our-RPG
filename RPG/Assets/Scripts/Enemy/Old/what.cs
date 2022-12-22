using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// ScriptableObject that holds the base stats for an enemy. These can then be modified at object creation time to buff up enemies
/// and reset theire stats if they died or were modified at runtime.
/// </summary>
public abstract class what : ScriptableObject
{
    // Enemy stats.
    public int Health = 100;

    // NavMeshAgentConfigs.
    public float AIUpdateInterval = 0.1f;

    public float Acceleration = 8;
    public float AngularSpeed = 120;
    public int AreaMask = -1; // -1 means everything.
    public int AvoidancePriority = 50;
    public float BaseOffset = 0f;
    public float Height = 2f;
    public ObstacleAvoidanceType ObstacleAvoidanceType = ObstacleAvoidanceType.LowQualityObstacleAvoidance;
    public float Radius = 0.5f;
    public float Speed = 3f;
    public float StoppingDistance = 0.5f;
}
