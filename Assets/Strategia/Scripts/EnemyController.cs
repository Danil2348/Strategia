using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, IMoveble
{
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] LayerMask playerlayer;
    private void Start()
    {
        StartCoroutine(RandomMoveEnemy());
    }

    void FixedUpdate()
    {
        Move();
    }

    // перемещение врага если он заметит машины игрока

    public void Move()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 20f, playerlayer);
        if (hitColliders.Length != 0)
        {
            _agent.SetDestination(hitColliders[0].transform.position);
        }
    }

    // рандомное перемещение врага

    IEnumerator RandomMoveEnemy()
    {
        while (true)
        {
            _agent.SetDestination(GlobalEventManager.ReceivingRandomPoint());
            yield return new WaitForSeconds(Random.Range(7f, 10f)); 
        }
    }
}
