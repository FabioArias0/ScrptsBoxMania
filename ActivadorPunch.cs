using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorPunch : MonoBehaviour
{
    public BoxCollider fistColl;
    public JugadorController jugadorController;
    public JugadorController2 jugadorController2;

    // Start is called before the first frame update
    void Start()
    {
        DesactivarColliderFist();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivarCollidersFist() {
        fistColl.enabled = true;
    }

    public void DesactivarColliderFist() {
        fistColl.enabled = false;
    }
}
