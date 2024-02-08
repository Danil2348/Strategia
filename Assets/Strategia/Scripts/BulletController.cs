using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletController : MonoBehaviour, IMoveble
{
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] float damage;
    [SerializeField] GameObject explosionParticle;
    public string _purpose;

    private void OnEnable()
    {
        Move();
    }
    private void OnCollisionEnter(Collision collision)
    {
        // c�������� particl ������

        Instantiate(explosionParticle, transform.position, transform.rotation);

        // ���� ��� ���� ���� ������� ������� �����

        if (collision.gameObject.tag== _purpose)
        {
           GlobalParametrs.UnitsScriptContainerHealth[collision.gameObject].Damage(damage);
        }

        // ����������� ���� � ���

        PoolManager.Return(gameObject, GlobalParametrs.bullet);
    }

    // ������� ��������� ����

    public void Move()
    {
        _rigidbody.velocity = transform.forward * 20;
    }
}
