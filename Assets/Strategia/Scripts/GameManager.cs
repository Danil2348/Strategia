using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour, IMoveble
{
    [SerializeField] LayerMask layer;
    [SerializeField] GameObject _building;
    [SerializeField] GameObject _bullet;
    void Start()
    {
        AngarEnemySpawn();
        BulletControllerPool();
    }

    void FixedUpdate()
    {
        MouseRaycast();
    }

    void OnEnable()
    {
        GlobalEventManager.ClickRigth += Move;
    }
    void OnDisable()
    {
        GlobalEventManager.ClickRigth -= Move;
    }

    // Заполнение пула и коллекции пулями

    private void BulletControllerPool()
    {
        GameObject bullet = Instantiate(_bullet, Vector3.zero, Quaternion.identity);
        GlobalParametrs.bullet.Enqueue(bullet);
        GlobalParametrs.bulletScriptContainer.Add(bullet, bullet.GetComponent<BulletController>());
        
    }

    // Создание Вражеских ангаров

    void AngarEnemySpawn()
    {
        int rand = Random.Range(3, 10);
        for (byte i = 0; i < rand; i++)
        {
            _building.tag = "AngarEnemy";
            _building.transform.Rotate(new Vector3(0f,Random.Range(0f,360f),0f));
            Instantiate(_building, GlobalEventManager.ReceivingRandomPointInvoke(), _building.transform.rotation);
        }
    }

    // Движение всех активных машин

    public void Move()
    {
        foreach (GameObject player in GlobalParametrs.playersActive)
        {
           GlobalParametrs.UnitsScriptContainerNavMeshAgent[player].SetDestination(GlobalParametrs._mouseTerrainPosition);
        }
    }

    // Считывание положение мыши на террайне

    private void MouseRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000f, layer))
        {
            GlobalParametrs._mouseTerrainPosition = hit.point;
        }
    }
}
