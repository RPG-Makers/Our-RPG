using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    private NavMeshAgent navAgent;
    private float wanderDistance = 3f;

    public EnemyData EnemyData;

    private void Start()
    {
        if (navAgent == null) navAgent = this.GetComponent<NavMeshAgent>();

        if (EnemyData != null) LoadEnemy(EnemyData);
    }

    private void LoadEnemy(EnemyData data)
    {
        // Remove children objects i.e. visuals.
        foreach (Transform child in this.transform)
        {
            if (Application.isEditor) DestroyImmediate(child.gameObject);
            else Destroy(child.gameObject);
        }

        // Load current enemy visuals.
        GameObject visuals = Instantiate(EnemyData.EnemyModel);
        visuals.transform.SetParent(this.transform);
        visuals.transform.localPosition = Vector3.zero;
        visuals.transform.rotation = Quaternion.identity;

        // Use stats data to set up enemy.
        if (navAgent == null) navAgent = this.GetComponent<NavMeshAgent>();

        this.navAgent.speed = data.Speed;
    }

    private void Update()
    {
        if (EnemyData == null) return;

        if (navAgent.remainingDistance < 1f) GetNewDestination();
    }

    private void GetNewDestination()
    {
        Vector3 nextDestination = this.transform.position;
        nextDestination += wanderDistance * new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(nextDestination, out hit, 3f, NavMesh.AllAreas)) navAgent.SetDestination(hit.position);
    }
}
