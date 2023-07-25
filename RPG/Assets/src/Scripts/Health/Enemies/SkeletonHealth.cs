using UnityEngine;

[RequireComponent(typeof(ISkeleton))]
public class SkeletonHealth : EnemyHealth
{
    protected override void Death()
    {
        base.Death();
        EventBus.SkeletonDeath.Publish();
        Debug.Log("Skeleton did something after death.");
    }
}
