using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeExplosions : MonoBehaviour
{
    private Transform[] waypointExp;
    public GameObject explosion;
    public GameObject waypointManager;

    public float timeToExplode = 0.5f;

    void Start()
    {
        waypointExp = new Transform[waypointManager.transform.childCount];
        for (int i = 0; i < waypointExp.Length; i++)
        {
            waypointExp[i] = waypointManager.transform.GetChild(i);
        }
    }

    void Update()
    {
        timeToExplode += Time.deltaTime;

        if (timeToExplode > 0.3f)
        {
            explosion.transform.localScale = new Vector3(Random.Range(2.0f, 5.0f), Random.Range(2.0f, 5.0f), Random.Range(2.0f, 5.0f));
            GameObject newExplosion = Instantiate(explosion,
                waypointExp[Random.Range(0, waypointExp.Length)].position + new Vector3(0, Random.Range(-4.5f, 5.0f), 0),
                new Quaternion(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10)));
            Destroy(newExplosion, 4.5f);
            timeToExplode = 0;
        }

    }
}
