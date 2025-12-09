using System.Collections;
using System.Collections.Generic;


using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float vitesseMax = 4.0f;
    public float vitesseRotation = 75.0f;
    public float acceleration = 1f;
    public float deceleration = 2f;


    private float Speed = 0.0f;


    private Animator animator;
    private int variableVitesseHash;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //recupere la variable Speed de notre animator
        variableVitesseHash = Animator.StringToHash("Speed");
    }

    // Update is called once per frame
    void Update()
    {
        float translation = 0f;
        float avance = Input.GetAxis("Vertical");

        //Tant qu'on appuie sur avance, la Speed augmente
        if (avance !=0 & Speed < vitesseMax)
        {
            Speed += Time.deltaTime * acceleration ;

        }
        if (avance == 0 && Speed > 0)
        {
            Speed -= Time.deltaTime * deceleration;
            if (Speed < 0.1f)
            {
                Speed = 0;
            }            
        }

        translation = Speed * Time.deltaTime;
        transform.Translate(Vector3.forward * translation);
        animator.SetFloat(variableVitesseHash, Speed);
        if(Speed != 0)
        {
            float rotation = Input.GetAxis("Horizontal") * vitesseRotation * Time.deltaTime;
            transform.Rotate(0, rotation, 0);
         }
    }
}
