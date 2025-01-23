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
        // �������� ������� ������� � ������� �����������
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // ��������� Z ���������� �������, ����� �������� ��������
        mousePosition.z = hitzone.position.z;

        // ������������ ����������� �� ������ � �������
        Vector3 direction = mousePosition - hitzone.position;

        // ��������� ���� � ��������
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ������������� ������� ������
        hitzone.rotation = Quaternion.Euler(0, 0, angle + 90);
    }
}
