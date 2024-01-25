using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController2 : MonoBehaviour
{

    // Настройки
    public float MoveSpeed = 15; // Скорость движения
    public float MaxSpeed = 15; // Максимальная скорость
    public float Drag = 0.98f; // Сопротивление движению
    public float SteerAngle = 20; // Угол поворота
    public float Traction = 1; // Сцепление

    private Vector3 MoveForce; // Сила движения

    public TrailRenderer[] trails;
    private bool emiting;

    private Vector2 touch_kord;


    void FixedUpdate()
    {
        // Движение
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            touch_kord = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            if(touch_kord.x > (Screen.width / 2))
            {
                MoveForce += transform.forward * MoveSpeed * Time.deltaTime;
                transform.position += MoveForce * Time.deltaTime;
            }
            else 
            {
                MoveForce += -transform.forward * MoveSpeed * Time.deltaTime;
                transform.position += MoveForce * Time.deltaTime;
            }
        }
        // MoveForce += transform.forward * MoveSpeed * gas.dumpenPress * Time.deltaTime;
        

        // Управление
        float steerInput = Input.acceleration.x;
        transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * SteerAngle * Time.deltaTime);

        // Сопротивление и ограничение максимальной скорости
        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed);
        // startEmiting();
               
        // Debug.DrawRay(transform.position, MoveForce.normalized * 3); // Отрисовка луча для отладки
        // Debug.DrawRay(transform.position, transform.forward * 3, Color.blue); // Отрисовка луча для отладки
        
        // Сцепление
        MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, Traction * Time.deltaTime) *
                    MoveForce.magnitude;
    }

    // public void startEmiting()
    // {
    //     emiting = true;
    //     foreach (TrailRenderer t in trails)
    //     {
    //         t.emitting = true;
    //     }
    // }
    // public void stopEmiting()
    // {
    //     emiting = false;
    //     foreach (TrailRenderer t in trails)
    //     {
    //         t.emitting = false;
    //     }
    // }
}
