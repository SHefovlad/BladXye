using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

public class AtackController : MonoBehaviour
{
    //[SerializeField] Transform hitzone;
    public Transform weaponHolder;
    bool canHit = true;
    public float hitTime;
    [SerializeField] float angle;
    float weaponAngle;
    float weaponAnglePlus;

    void Update()
    {
        RotateHitzone();
        if (canHit && Input.GetAxis("Fire") != 0) { StartCoroutine(Hit(hitTime)); }
    }
    void RotateHitzone()
    {
        // Получаем позицию курсора в мировых координатах
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Сохраняем Z координату объекта, чтобы избежать смещения
        mousePosition.z = weaponHolder.position.z;

        // Рассчитываем направление от игрока к курсору
        Vector3 direction = mousePosition - weaponHolder.position;

        // Вычисляем угол в градусах
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Устанавливаем поворот игрока
        //hitzone.rotation = Quaternion.Euler(0, 0, angle + 90);

        //weaponAngle += (int)((angle + 180 + 22.5f) / 45) * 45;
        //weaponAngle -= 202.5f;
        if (canHit)
        {
            if (angle < 157.5f)
            {
                weaponAnglePlus = (int)((angle + 180 - 22.5f) / 45) * 45 - 180 + 45;
            }
            else
            {
                weaponAnglePlus = 180;
            }
        }
        weaponAngle += weaponAnglePlus;
        weaponHolder.transform.rotation = Quaternion.Euler(0, 0, weaponAngle + 120);
        weaponAngle = 0;
    }
    IEnumerator Hit(float time)
    {
        canHit = false;
        float ctime = 0;
        while (ctime < time)
        {
            ctime += (float)(1f / (time * 2 * 60f));
            weaponAngle += ctime * -30 * 1 / time;
            yield return new WaitForSeconds(1 / 60);
        }
        ctime = 0;
        while (ctime < time)
        {
            ctime += (float)(1f / (time * 60f));
            weaponAngle += ctime * 90 * 1 / time;
            weaponAngle -= 30;
            yield return new WaitForSeconds(1 / 60);
        }
        ctime = 0;
        while (ctime < time)
        {
            ctime += (float)(1f / (time * 2 * 60f));
            weaponAngle += 90 - ctime * 60 * 1 / time;
            weaponAngle -= 30;
            yield return new WaitForSeconds(1 / 60);
        }
        canHit = true;
    }
}
