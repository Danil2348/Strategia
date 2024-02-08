using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    float _hp;
    [SerializeField] float maxhp;
    [SerializeField] UnityEvent<float> HpChanged;
    [SerializeField] UnityEvent<bool> HpChangedSetActive;

    // �������� ������
    public float HP
    {
        get => _hp;
        set
        {
            _hp = value;
            HpChanged?.Invoke(_hp/maxhp);
            if (_hp <= 0)
            {
                Destroy(gameObject);
                if (gameObject.tag == "Player")
                {
                    GlobalParametrs.playersActive.Remove(gameObject);
                    GlobalParametrs.players.Remove(gameObject);
                }
            }
        }
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        HP = maxhp;
    }

    // ��������� ����� 

    public void Damage(float damage)
    {
        HP -= damage;
        StartCoroutine(Display());
    }

    // ����������� ������ ����� �� 2 �������

    IEnumerator Display()
    {
        HpChangedSetActive?.Invoke(true);
        yield return new WaitForSeconds(2f);
        HpChangedSetActive?.Invoke(false);
    }
}
