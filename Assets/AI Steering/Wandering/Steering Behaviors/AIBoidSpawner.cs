using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Steering.Extras
{
    public class AIBoidSpawner : MonoBehaviour
    {
        [SerializeField] private AISteeringAgent prefab;
        [SerializeField] private float spawnRadius = 10;
        [SerializeField] private int spawnCount = 10;

        private void Awake()
        {
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 pos = transform.position + Random.insideUnitSphere * spawnRadius;
                AISteeringAgent boid = Instantiate(prefab);
                boid.transform.position = pos;
                boid.transform.forward = Random.insideUnitSphere.normalized;

                boid.SetColor(Random.ColorHSV(0, 1, 1, 1, 1, 1));
            }
        }
    }
}