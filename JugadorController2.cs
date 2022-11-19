using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JugadorController2 : MonoBehaviour { 

    public Rigidbody rb;

    public int m_PlayerNumber=2;

    private string m_MovementAxisName;
    private string m_TurnAxisName;

    public float hp = 100f;
    public float damage = 1f;
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 200.0f;
    public float ImpulsoGolpe = 10f;
    public Text HealthPercentage2;
    

    public bool Attacking;
    public bool OneStep;

    public float TiempoInicio = 0.0f;
    public float TiempoFinal = 0.0f;
    
    private Animator anim;
    private float m_MovementInputValue;
    private float m_TurnInputValue;

    [SerializeField] private GameObject MenuGanar2;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        m_MovementAxisName = "Vertical";
        m_TurnAxisName = "Horizontal";

        HealthPercentage2.text = hp.ToString();
        MenuGanar2.SetActive(false);



    }

    private void OnEnable()
    {

        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }

    private void OnDisable()
    {
        
        rb.isKinematic = true;
    }

    
    void FixedUpdate()
    {
        if (!Attacking)
        {
            //transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
            Turn();
            //transform.Translate(0, 0, y * Time.deltaTime * movementSpeed);
            Move();

        }



        if (OneStep)
        {
            rb.velocity = transform.forward * ImpulsoGolpe;
        }

    }

    // Update is called once per frame
    void Update()
    {

        m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
        m_TurnInputValue = Input.GetAxis(m_TurnAxisName);


        if (Input.GetKeyDown(KeyCode.Space) && !Attacking)
        {

            anim.SetTrigger("Golpeo");
            Attacking = true;

        }


        anim.SetFloat("VelX", m_TurnInputValue);
        anim.SetFloat("VelY", m_MovementInputValue);


    }

    private void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.tag == "Punch1")
        {
        
            Debug.Log("Ha recibido casco blanco");

           
            HealthPercentage2.text = hp.ToString() + "%";
            hp -= damage;
            
        }

        if (hp <= 0) {

            
            MenuGanar2.SetActive(true);

        }




    }

   

    private void Move()
    {
       

        Vector3 movement = transform.forward * m_MovementInputValue * movementSpeed * Time.deltaTime;

        rb.MovePosition(rb.position + movement);
    }

    private void Turn()
    {

        float turn = m_TurnInputValue * rotationSpeed * Time.deltaTime;


        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);


        rb.MoveRotation(rb.rotation * turnRotation);
    }

    



    public void StopAttacking()
    {
        Attacking = false;
        OneStep = false;
    }

    public void oneStep()
    {
        OneStep = true;
    }

    public void StopOneStep()
    {
        OneStep = false;

    }

   

}
