using UnityEngine;
using UnityEngine.AI;

// Hérite de GoalManager pour réutiliser NextGoal et le tableau de goals
public class PoliceGoalManager : GoalManager
{
    // l'attribut privé deviens publique dans l'inpecteur 
    [SerializeField] private NavMeshAgent policeAgent;
    [SerializeField] private float stoppingDistance = 0.5f;

    private void Start()
    {
        // Si on a oublié de l’assigner dans l’inspecteur, on essaie de le trouver
        if (policeAgent == null)
        {
            // CHERCHE dans la scène 
            policeAgent = FindObjectOfType<NavMeshAgent>();
        }

        SetNextDestination();
    }
    private void Update()
    {
        // chemin en cours de calcul 
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
        Transform goal = NextGoal();   // Pour atteindre le prochain but 
        if (goal != null && policeAgent != null)
        {
            // le navmesh prends la position du prochain goal a atteindre 
            policeAgent.SetDestination(goal.position);
        }
    }
}