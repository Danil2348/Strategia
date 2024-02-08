using UnityEngine;

public abstract class ObjectRotationOfTerrain : MonoBehaviour, IRotation
{
    [SerializeField] LayerMask layer;

    // поворот обьекта относительно поверхности террайна
    public void Rotation()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.GetChild(0).position, -transform.GetChild(0).up, out hit, 20, layer))
        {
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.GetChild(0).rotation;
        }
    }
}
