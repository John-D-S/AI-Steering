using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Steering
{
    [CreateAssetMenu(menuName = "Steering/Wander", fileName = "Wander")]
    public class AIWanderBehavior : AISteeringBehavior
    {
        [SerializeField, Range(-.1f, .1f)] private float jitter = .05f;

        public override Vector3 Calculate(AISteeringAgent _agent)
        {
            Vector3 force = _agent.CurrentForce;

            Vector2 offset = new Vector2(Random.Range(-jitter, jitter), Random.Range(-jitter, jitter));

            force += _agent.Right * offset.x;
            force += _agent.Up * offset.y;

            // the force is strong with this one.
            return force;
        }
    }
}