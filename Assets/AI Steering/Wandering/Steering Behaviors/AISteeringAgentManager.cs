using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Steering
{

    public class AISteeringAgentManager : MonoBehaviour
    {
        [SerializeField, Min(1f)] private float speed = 5;
        [SerializeField] private bool run = false;

        private AISteeringAgent[] agents;

        // Start is called before the first frame update
        void Start()
        {
            // find all agents and make them children of this
            // initialise them.
            agents = FindObjectsOfType<AISteeringAgent>();
            foreach (AISteeringAgent agent in agents)
            {
                agent.transform.parent = transform;
                agent.Initialise(speed);
            }
        }

        // Update is called once per frame
        void Update()
        {
            //if the run variable is stet, each agent will be updated
            foreach (AISteeringAgent agent in agents)
                if (run) agent.UpdateAgent();
        }
    }
}
