using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatistics", menuName = "Create PlayerStatistics")]
public class PlayerStatisticsData : ScriptableObject
{
    private PlayerQuest _playerQuest;
    private void OnEnable()
    {
        SkeletonHealth.Dead += IncreaseNumberOfKilledSkeletons;
    }
    private void OnDisable()
    {
        SkeletonHealth.Dead -= IncreaseNumberOfKilledSkeletons;
    }

    [Header("Enemies")]
    public int numberOfKilledSkeletons;
    private void IncreaseNumberOfKilledSkeletons()
    {
        numberOfKilledSkeletons++;
    }
    public int NumberOfKilledEnemies => numberOfKilledSkeletons; // Add other enemies.


    [Header("Environment")]
    public int NumberOfDestroyedBoxes;
}
