using UnityEngine;

public class RollTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Animator anim = other.GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetTrigger("Roll");
            }
        }
    }
}
