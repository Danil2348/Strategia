using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GlobalParametrs
{
    public static Vector3 _mouseTerrainPosition;
    public static List<GameObject> players = new();
    public static List<GameObject> playersActive = new();
    public static Queue<GameObject> bullet = new();
    public static Dictionary<GameObject, BulletController> bulletScriptContainer = new();
    public static Dictionary<GameObject, HealthController> UnitsScriptContainerHealth = new();
    public static Dictionary<GameObject, NavMeshAgent> UnitsScriptContainerNavMeshAgent = new();
}
