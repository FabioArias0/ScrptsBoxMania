using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarScene : MonoBehaviour
{
    public float TiempoInicio = 0.0f;
    public float TiempoFinal = 0.0f;
   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TiempoInicio += Time.deltaTime;
        if (TiempoInicio >= TiempoFinal)
        {
            SceneManager.LoadScene(0);
        }
    }
}
