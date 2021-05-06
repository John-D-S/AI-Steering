using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Steering
{
    [CreateAssetMenu(menuName = "Steering/Composite", fileName = "Composite", order = -100)]
    public class CompositeBehavior : AISteeringBehavior
    {
        [System.Serializable]
        public struct WeightedBehaviour
        {
            [Min(.1f)]
            public float weighting;
            public AISteeringBehavior behavior;
        }

        [SerializeField] private List<WeightedBehaviour> behaviours = new List<WeightedBehaviour>();

        public override Vector3 Calculate(AISteeringAgent _agent)
        {
            Vector3 force = _agent.CurrentForce;

            behaviours.ForEach(weighted =>
            {
                force += weighted.behavior.Calculate(_agent) * weighted.weighting;
            });

            return force;
        }
    }
}
