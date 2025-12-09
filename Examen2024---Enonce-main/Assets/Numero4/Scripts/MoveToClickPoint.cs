using UnityEngine;
using UnityEngine.AI;

public class MoveToClickPoint : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;

    private Vector3 destination;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100000))
        {
            if (Input.GetMouseButtonDown(0))
            {
                agent.destination = destination = hit.point;
                agent.isStopped = false;
            }
            else
            {
                Debug.Log("No move required to : " + hit.point);
            }
        }


        if ((transform.position - destination).sqrMagnitude < .01f)
        {
            agent.isStopped = true;
        }

        if (agent.velocity.sqrMagnitude > .01f)
        {
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
        }

    }
}                                                                                                                                                                                                                                                                                      

