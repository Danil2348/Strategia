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
        // cсоздание particl взрыва

        Instantiate(explosionParticle, transform.position, transform.rotation);

        // если это наша цель вызвать функцию урона

        if (collision.gameObject.tag== _purpose)
        {
           GlobalParametrs.UnitsScriptContainerHealth[collision.gameObject].Damage(damage);
        }

        // возвращаеем пулю в пул

        PoolManager.Return(gameObject, GlobalParametrs.bullet);
    }

    // задание ускорение пуле

    public void Move()
    {
        _rigidbody.velocity = transform.forward * 20;
    }
}
