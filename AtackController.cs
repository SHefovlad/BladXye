using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackController : MonoBehaviour
{
    [SerializeField] Transform hitzone;

    void Update()
    {
        RotateHitzone();
    }
    void RotateHitzone()
    {
        // Получаем позицию курсора в мировых координатах
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Сохраняем Z координату объекта, чтобы избежать смещения
        mousePosition.z = hitzone.position.z;

        // Рассчитываем направление от игрока к курсору
        Vector3 direction = mousePosition - hitzone.position;

        // Вычисляем угол в градусах
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Устанавливаем поворот игрока
        hitzone.rotation = Quaternion.Euler(0, 0, angle + 90);
    }
}
