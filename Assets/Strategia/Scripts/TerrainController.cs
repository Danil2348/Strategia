using UnityEngine;

public class TerrainController : MonoBehaviour
{
    Terrain _terrain;

    private void Awake()
    {
        _terrain = GetComponent<Terrain>();
    }

    // �������� �� �������
    private void OnEnable()
    {
        GlobalEventManager.ReceivingRandomPoint += TerrainRandomPointPosition;
    }

    // ������� �� �������

    private void OnDisable()
    {
        GlobalEventManager.ReceivingRandomPoint -= TerrainRandomPointPosition;
    }

    // ������ ��������� ����� �� ��������
    Vector3 TerrainRandomPointPosition()
    {
        float spawnX = Random.Range(transform.position.x, _terrain.terrainData.size.x);
        float spawnZ = Random.Range(transform.position.z, _terrain.terrainData.size.z);
        float spawnY = _terrain.SampleHeight(new Vector3(spawnX, transform.position.y, spawnZ));
        return new Vector3(spawnX, spawnY, spawnZ);
    }
}
