using UnityEngine;
using Unity.Netcode;



public class CapsulePlayerController : NetworkBehaviour
{
    private const float DEFAULT_SPEED = 2f;

    //Allow to see speed inspector
    [SerializeField]
    private float speed = DEFAULT_SPEED;

    private Vector3 movement;

    public override void OnNetworkSpawn()
    {
        //Gere les positions et les couleurs de joueurs, 
        //Ce code n'est pas optimal, mais il fonctionne pour 2 joueurs
        // vous n'avez pas besoin de le modifier
        //bleu est reservé au joueur associé au serveur
        //rouge a l'Autre
        if (IsHost)
        {
            if (IsOwner)
            {
                transform.position = new Vector3(0, 1, 0);
                GetComponent<Renderer>().material.color = Color.blue;
            }
            else
            {
                transform.position = new Vector3(-10, 1, 0);
                GetComponent<Renderer>().material.color = Color.red;
            }

        }
        else
        {
            if (!IsOwner)
            {
                transform.position = new Vector3(0, 1, 0);

                GetComponent<Renderer>().material.color = Color.blue;
            }
            else
            {
                transform.position = new Vector3(-10, 1, 0);

                GetComponent<Renderer>().material.color = Color.red;
            }
        }

    }

    private void FixedUpdate()
    {
        // empeche de bouger les joueurs des autres 
        if (!IsOwner) return; 

        //Gestion du movement du joueur
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMove;
        Vector3 moveVertical = transform.forward * zMove;

        //calculate Norm and multiply with speed
        movement = (moveHorizontal + moveVertical).normalized * speed * Time.deltaTime;
        transform.Translate(movement);
        //Fin Gestion du movement du joueur
    }


}
