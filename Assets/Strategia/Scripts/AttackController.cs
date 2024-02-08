using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackController : MonoBehaviour
{
    [SerializeField] string _purpose;
    [SerializeField] UnityEvent shotParticls;
    LayerMask layerPurpose;
    private void Start()
    {
        layerPurpose = 1 << LayerMask.NameToLayer(_purpose);
        StartCoroutine(Atack());
    }

    // �����
    IEnumerator Atack()
    {
        while (true)
        {
            // � ������� raycast ���������� ���� ����

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 15, layerPurpose))
            {
                // ���� ���� �� ���� ,������� �� ����, � ������������� particl ��������

                GameObject bullet = PoolManager.Spawn(GlobalParametrs.bullet, transform);
                GlobalParametrs.bulletScriptContainer[bullet]._purpose = _purpose;
                shotParticls?.Invoke();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
