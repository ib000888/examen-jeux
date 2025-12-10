using UnityEngine;
using UnityEngine.AI;

// Hérite de GoalManager pour réutiliser NextGoal() et le tableau de goals
public class PoliceGoalManager : GoalManager
{
    [SerializeField] private NavMeshAgent policeAgent;
    [SerializeField] private float stoppingDistance = 0.5f;

    private void Start()
    {
        // Si on a oublié de l’assigner dans l’inspecteur, on essaie de le trouver
        if (policeAgent == null)
        {
            policeAgent = FindObjectOfType<NavMeshAgent>();
        }

        SetNextDestination();
    }

    private void Update()
    {
        if (policeAgent == null || policeAgent.pathPending)
            return;

        // Quand le policier est proche de son but, on demande le suivant
        if (policeAgent.remainingDistance <= stoppingDistance)
        {
            SetNextDestination();
        }
    }

    private void SetNextDestination()
    {
        Transform goal = NextGoal();   // NextGoal() vient de GoalManager
        if (goal != null && policeAgent != null)
        {
            policeAgent.SetDestination(goal.position);
        }
    }
}