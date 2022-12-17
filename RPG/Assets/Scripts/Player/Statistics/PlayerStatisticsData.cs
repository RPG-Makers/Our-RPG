using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatistics", menuName = "Create PlayerStatistics")]
public class PlayerStatisticsData : ScriptableObject
{
    [SerializeField] public int NumberOfKilledEnemies => NumberOfKilledSkeletons; // Add other enemies.





    private int numberOfKilledSkeletons;
    [SerializeField] public int NumberOfKilledSkeletons
    {
        get { return numberOfKilledSkeletons; }
        set
        {
            numberOfKilledSkeletons = value;
            Debug.Log($"NumberOfKilledSkeletons: {numberOfKilledSkeletons}");
        }
    }






    [SerializeField] public int NumberOfDestroyedBoxes;
}
