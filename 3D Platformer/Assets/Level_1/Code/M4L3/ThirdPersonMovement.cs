using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public float speed = 5f;
    public bool canRun = true;
    public bool isRunning;
    public float runSpeed = 9f;
    float targetMovingSpeed;

    public KeyCode runningKey = KeyCode.LeftShift;

    private Rigidbody playerRigidbody;

    void Awake()
    {
        //Получение ссылки на компонент Rigidbody объекта, к которому прикреплён этот скрипт 
        playerRigidbody = this.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        //Скрывает курсор в начале игры
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        //Проверка того, что механика бега включена и зажат левый Shift
        //Короткая запись: IsRunning = canRun && Input.GetKey(runningKey);
        if (canRun && Input.GetKey(runningKey))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        //Обновление целевой скорости в зависимости от выполненного условия
        //Короткая запись: targetMovingSpeed = isRunning ? runSpeed : speed;
        if (isRunning)
        {
            targetMovingSpeed = runSpeed;
        }
        else
        {
            targetMovingSpeed = speed;
        }

        //Увеличение скорости
        playerRigidbody.velocity = transform.rotation * new Vector3(Input.GetAxis("Horizontal"), playerRigidbody.velocity.y,
             Input.GetAxis("Vertical") * targetMovingSpeed);

        //Поворот объекта на месте
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * (100f * Time.deltaTime), Space.Self);
    }
}