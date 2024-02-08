using UnityEngine;

public class TerrainController : MonoBehaviour
{
    Terrain _terrain;

    private void Awake()
    {
        _terrain = GetComponent<Terrain>();
    }

    // подписка на событие
    private void OnEnable()
    {
        GlobalEventManager.ReceivingRandomPoint += TerrainRandomPointPosition;
    }

    // отписка от события

    private void OnDisable()
    {
        GlobalEventManager.ReceivingRandomPoint -= TerrainRandomPointPosition;
    }

    // расчёт рандомной точки на террайне
    Vector3 TerrainRandomPointPosition()
    {
        float spawnX = Random.Range(transform.position.x, _terrain.terrainData.size.x);
        float spawnZ = Random.Range(transform.position.z, _terrain.terrainData.size.z);
        float spawnY = _terrain.SampleHeight(new Vector3(spawnX, transform.position.y, spawnZ));
        return new Vector3(spawnX, spawnY, spawnZ);
    }
}
