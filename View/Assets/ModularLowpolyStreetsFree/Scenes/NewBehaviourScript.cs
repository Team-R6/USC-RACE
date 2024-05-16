using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicpersonajemain : MonoBehaviour
{
    public float velocidadM = 5.0f;
    public float velocidadLateral = 4.0f;
    private Animator anim;
    public float x , y;
    public Vector2 sensitivity;
    public new Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void UpdateMovement()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
    
        // Movimiento lateral
        transform.Translate(x * Time.deltaTime * velocidadLateral, 0, 0);

        // Movimiento hacia adelante y atrás
        transform.Translate(0, 0, y * Time.deltaTime * velocidadM);



        anim.SetFloat("VelX",x);
        anim.SetFloat("VelY",y);
    }
    private void UpdateMouseLook()
    {
        float hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Mouse Y");

        if(hor != 0)
        {
            transform.Rotate(0, hor * sensitivity.x,0);
        }
        if(ver !=0)
        {
            Vector3 rotation = camera.localEulerAngles;
            rotation.x = (rotation.x -ver * sensitivity.y + 360) % 360;
            if(rotation.x > 80 && rotation.x < 180){rotation.x = 80;} else
            if(rotation.x <280 && rotation.x >180){rotation.x = 280;}
            camera.localEulerAngles = rotation;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateMouseLook();
    }
}