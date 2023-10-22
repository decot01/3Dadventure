using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    public Animator animator;
    int isWalkingHash, isRunningHash, isJumpingHash;

    void Start()
    {
        //Получаем id нужных параметров — так мы сэкономим время на их поиск
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");
    }


    void Update()
    {
        //Получаем по id параметров их булевы значения
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isJumping = animator.GetBool(isJumpingHash);

        //Получаем булевы значения результата проверки ввода игрока
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        bool jumpPressed = Input.GetKey("space");

        //Если игрок не идёт И зажата клавиша W, то включаем анимацию ходьбы
        if (!isWalking && forwardPressed)
        {
            animator.SetBool("isWalking", true);
        }

        //Если игрок идёт И не зажата клавиша W, то выключаем анимацию ходьбы
        if (isWalking && !forwardPressed)
        {
            animator.SetBool("isWalking", false);
        }

        //Если игрок не бежит И зажаты левый шифт И W, то включаем анимацию бега
        if (!isRunning && (forwardPressed && runPressed))
        {
            animator.SetBool("isRunning", true);
        }

        //Если игрок бежит И не зажат левый шифт ИЛИ W, то выключаем анимацию бега
        if (isRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool("isRunning", false);
        }

        //Если игрок не прыгает И зажат пробел, то включаем анимацию прыжка
        if (!isJumping && jumpPressed)
        {
            animator.SetBool("isJumping", true);
        }

        //Если игрок прыгает И не зажат пробел, то выключаем анимацию прыжка
        if (isJumping && !jumpPressed)
        {
            animator.SetBool("isJumping", false);
        }

        //Если игрок нажал левую кнопку мыши, то включаем анимацию атаки
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isAttacking", true);
        }

        //Если игрок не нажал левую кнопку мыши, то выключаем анимацию атаки
        if (!Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isAttacking", false);
        }
    }
}
