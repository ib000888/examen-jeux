using UnityEngine;
using UnityEngine.AI;

public class WomanGoalManager : GoalManager
{
    [SerializeField] private NavMeshAgent womanAgent;
    [SerializeField] private float stoppingDistance = 0.5f;

    private void Start()
    {
        if (womanAgent == null)
            womanAgent = GetComponent<NavMeshAgent>();

        SetNextDestination();
    }

    private void Update()
    {
        if (womanAgent == null || womanAgent.pathPending)
            return;

        if (womanAgent.remainingDistance <= stoppingDistance)
        {
            SetNextDestination();
        }
    }

    private void SetNextDestination()
    {
        Transform goal = NextGoal();
        if (goal != null && womanAgent != null)
        {
            womanAgent.SetDestination(goal.position);
        }
    }
}
