using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // вытаскивание из пула свободный обьект, и назначение ему нужных параметров

    public static GameObject Spawn(Queue<GameObject> objs, Transform point)
    {
        GameObject obj = objs.Dequeue();
        if (objs.Count == 0)
        {
            GameObject newobj = Instantiate(obj, Vector3.zero, Quaternion.identity);
            objs.Enqueue(newobj);
            GlobalParametrs.bulletScriptContainer.Add(newobj, newobj.GetComponent<BulletController>());
        }
        obj.transform.position = point.position;
        obj.transform.rotation = point.rotation;
        obj.SetActive(true);
        return obj;
    }

    // возвращение в пул обьекта, и сбрасывание ему параметров

    public static void Return(GameObject obj, Queue<GameObject> objs)
    {
        obj.transform.position = Vector3.zero;
        obj.transform.rotation = Quaternion.identity;
        obj.SetActive(false);
        objs.Enqueue(obj);
    }
}
