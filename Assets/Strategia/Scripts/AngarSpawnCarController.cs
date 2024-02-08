using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class AngarSpawnCarController : MonoBehaviour
{
    [SerializeField] GameObject _enemy;
    [SerializeField] GameObject _player;

    private void OnEnable()
    {
        StartCoroutine(SpawnCar());
    }

    // �������� ����� �� ������ � ���������� �� ����, ��������� ������, ������������ �������������� ������
    IEnumerator SpawnCar()
    {
        for(byte i=0; i < 3; i++)
        {
            yield return new WaitForSeconds(2);

            switch (tag)
            {
                case "AngarPlayer":

                    // �������� ������� ������

                    GlobalParametrs.players.Add(CreateCar(_player, i));
                    break;
                case "AngarEnemy":

                    // �������� ��������� ������

                    CreateCar(_enemy, i);
                    break;
            }

        }
    }

    // �������� ������

    GameObject CreateCar(GameObject car, byte i)
    {
        GameObject unit= Instantiate(car, transform.GetChild(1).position + new Vector3(i, 0, i), transform.rotation);
        GlobalParametrs.UnitsScriptContainerHealth.Add(unit, unit.GetComponent<HealthController>());
        GlobalParametrs.UnitsScriptContainerNavMeshAgent.Add(unit, unit.GetComponent<NavMeshAgent>());
        return unit;
    }
}
