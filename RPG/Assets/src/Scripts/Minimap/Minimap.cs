using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player;

    private void LateUpdate() //работаем после Update и FixedUpdate , т.е после того, как наш игрок в очередном кадре сделал движение
    {
        Vector3 newMinimapPosition = player.position; // задаём карте позицию игрока
        newMinimapPosition.z = transform.position.z; //отдаляемся от игрока вверх, чтобы видеть местность. Если бы игра была 3Д, то отдалялись бы по Y , а не по Z
        transform.position = newMinimapPosition;
        
        //transform.rotation = Quaternion.Euler(0f,player.eulerAngles.y,90f); пример с вращением мини-карты, но у большинства мини-карт вращение всегда отключено для удобства просмотра карты по типу север всегда сверху

    }
}
