using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMover : MonoBehaviour
{
    private Mono _input;
    Rigidbody rb;

    bool izquierda;
    bool derecha;
    bool arriba;
    bool abajo;
    float horizontalMov;
    float verticalMov;
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private float moveSpeed;
    private void Awake()
    {
        _input = GetComponent<Mono>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
    }
    void FixedUpdate()
    {
        var targetVector =  new Vector3(_input.InputVector.x, 0 , _input.InputVector.y);
        var movementVector = MoveTowardTarget(targetVector);
        rb.velocity = new Vector3 (horizontalMov * Time.deltaTime,0,verticalMov * Time.deltaTime);

        RotateTowardMovementVector(movementVector);
    }

    private void RotateTowardMovementVector(Vector3 movementVector)
    {
        if (movementVector.magnitude == 0) return;
        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = moveSpeed * Time.fixedDeltaTime;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }

    // BOTON DERECHA
    public void PointerDownDerecha()
    {
        derecha = true;
    }
    public void PointerUpDerecha()
    {
        derecha = false;
    }
    // BOTON IZQUIERDA
    public void PointerDownIzquierda()
    {
        izquierda = true;
    }
    public void PointerUpIzquierda()
    {
        izquierda = false;
    }
    // BOTON ARRIBA
    public void PointerDownArriba()
    {
        arriba = true;
    }
    public void PointerUpArriba()
    {
        arriba = false;
    }
    //BOTON ABAJO
    public void PointerDownAbajo()
    {
        abajo = true;
    }
    public void PointerUpAbajo()
    {
        abajo = false;
    }

    void Movement()
    {
        if (izquierda)
        {
            horizontalMov = -moveSpeed;
        }
        else if (derecha)
        {
            horizontalMov = moveSpeed;
        }
        else
        {
            horizontalMov = 0;
        }

        if (arriba)
        {
            verticalMov = moveSpeed;
        }
        else if (abajo)
        {
            verticalMov = -moveSpeed;
        }
        else
        {
            verticalMov = 0;
        }
    }
}
