using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatistics", menuName = "Create PlayerStatistics")]
public class PlayerStatisticsData : ScriptableObject
{
    //private PlayerQuest _playerQuest;
    private void OnEnable()
    {
        SkeletonHealth.Died += IncreaseNumberOfKilledSkeletons;
        BoxHealth.Died += IncreaseNumberOfDestroyedBoxes;
    }

    private void OnDisable()
    {
        SkeletonHealth.Died -= IncreaseNumberOfKilledSkeletons;
        BoxHealth.Died -= IncreaseNumberOfDestroyedBoxes;
    }

    [Header("Enemies")]
    public int NumberOfKilledSkeletons;
    private void IncreaseNumberOfKilledSkeletons()
    {
        NumberOfKilledSkeletons++;
    }
    public int NumberOfKilledEnemies => NumberOfKilledSkeletons; // + other enemies


    [Header("Environment")]
    public int NumberOfDestroyedBoxes;
    private void IncreaseNumberOfDestroyedBoxes()
    {
        NumberOfDestroyedBoxes++;
    }
}
