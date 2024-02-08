using System.Collections;
using UnityEngine;

public class RainController : MonoBehaviour
{
    [SerializeField] ParticleSystem _ps;
    private void Start()
    {
        StartCoroutine(WeatherChanges());
    }
    // Включение или отключение ParticleSystem(дождь)
    IEnumerator WeatherChanges()
    {
        while (true)
        {
            if (Random.value > 0.5f)
            {
                _ps.Play();
            }
            else
            {
                _ps.Stop();
            }
            yield return new WaitForSeconds(Random.Range(10f,15f));
        }
    }
}
