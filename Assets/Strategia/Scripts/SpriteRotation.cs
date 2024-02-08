using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotation : MonoBehaviour, IRotation
{
    Transform _camera;

    private void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // ������� ����������� � ������

    void FixedUpdate()
    {
        Rotation();
    }

    public void Rotation()
    {
        transform.LookAt(_camera);
    }
}
