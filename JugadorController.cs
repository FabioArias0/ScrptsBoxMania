using Mono.Cecil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JugadorController : MonoBehaviour
{

    public Rigidbody rb;

    public int m_PlayerNumber=1;

    private string m_MovementAxisName;
    private string m_TurnAxisName;
    public Text HealthPercentage1;
    public Text Ganador;

    
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 200.0f;
    public float hp = 100f;
    public float damage = 1f;
    public float ImpulsoGolpe = 10f;

    public bool Attacking;
    public bool OneStep;

    public float TiempoInicio = 0.0f;
    public float TiempoFinal = 0.0f;
    private Animator anim;
    private float m_MovementInputValue;
    private float m_TurnInputValue;
    // Start is called before the first frame update

    [SerializeField] private GameObject MenuGanar;

    private void OnEnable()
    {
       
       // rb.isKinematic = false;
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }
    private void OnDisable()
    {
        
        rb.isKinematic = true;
    }

    void Start()
    {
        anim=GetComponent<Animator>();
        m_MovementAxisName = "VerticalUI";
        m_TurnAxisName = "HorizontalUI";
        HealthPercentage1.text = hp.ToString();

        MenuGanar.SetActive(false);


    }

    void FixedUpdate()
    {
        if (!Attacking) {
            Turn();
            //transform.Translate(0, 0, y * Time.deltaTime * movementSpeed);
            Move();
            
        }

       

        if (OneStep) {
            rb.velocity = transform.forward * ImpulsoGolpe;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

       //x = Input.GetAxis(m_MovementAxisName);
        //y = Input.GetAxis(m_TurnAxisName);

        m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
        m_TurnInputValue = Input.GetAxis(m_TurnAxisName);

        if (Input.GetKeyDown(KeyCode.Return)&& !Attacking) {

            anim.SetTrigger("Golpeo");
            Attacking = true;
            
        }


        anim.SetFloat("VelX", m_TurnInputValue);
        anim.SetFloat("VelY", m_MovementInputValue);



    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Punch2")
        {

            Debug.Log("Ha recibido casco azul");

            hp -= damage;
            HealthPercentage1.text = hp.ToString();
        }

        if (hp <= 0)
        {

            Ganador.enabled = true;
            MenuGanar.SetActive(true);


        }



    }




    private void Move()
    {
       
        Vector3 movement = transform.forward * m_MovementInputValue * movementSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    private void Turn()
    {
       
        float turn = m_TurnInputValue* rotationSpeed * Time.deltaTime;

        
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        
        rb.MoveRotation(rb.rotation * turnRotation);
    }


   
   


    public void StopAttacking() {
        Attacking = false;
        OneStep = false;
    }

    public void oneStep() {
        OneStep = true;
    }

    public void StopOneStep() { 
        OneStep= false;

    }

   
}
