using UnityEngine;
using UnityEngine.Events;
using System;

public class BuildController : MonoBehaviour, IMoveble, IRotation
{
    [SerializeField] GameObject _building;
    [SerializeField] UnityEvent BuildBritch;
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Rotation();
        }
    }
    private void FixedUpdate()
    {
        Move();
    }

    void OnEnable()
    {
        GlobalEventManager.ClickLeft+=Create;
    }

    void OnDisable()
    {
        GlobalEventManager.ClickLeft-=Create;
    }

    // перемещение созданного образа по террайну за мышкой

    public void Move()
    {
        transform.position = GlobalParametrs._mouseTerrainPosition;
    }

    // вращение образа

    public void Rotation()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 100);
    }

    // уничтожение образа и  установка здания с тегом, показывающим что это здание игрока

    void Create()
    {
        _building.tag = "AngarPlayer";
        Instantiate(_building, transform.position, transform.rotation);
        BuildBritch?.Invoke();
    }
}
