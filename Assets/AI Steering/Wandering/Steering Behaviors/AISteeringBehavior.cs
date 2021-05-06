using UnityEngine;

namespace Steering
{
    public abstract class AISteeringBehavior : ScriptableObject
    {
        /// <summary>
        /// runs the calculations for the position and rotations fo the passed
        /// agent using the force calculated in the <see cref="Calculate(AISteeringAgent)"/> function.
        /// </summary>
        public void UpdateAgent(AISteeringAgent _agent)
        {
            Vector3 force = Calculate(_agent).normalized;
            _agent.UpdateCurrentForce(force);

            //calculate the rotation using Slerp,m the current rotation and the force of the target.
            Quaternion rotation = Quaternion.Slerp(
                _agent.rotation,
                Quaternion.LookRotation(_agent.CurrentForce != Vector3.zero ? _agent.CurrentForce : _agent.Forward),
                Time.deltaTime * 10f);

            //calculate the position by finding the correct movement then damping the difference
            Vector3 movement = (_agent.Forward + force * _agent.Speed) * Time.deltaTime;
            Vector3 position = Vector3.SmoothDamp(
                _agent.position,
                movement + _agent.position,
                ref _agent.velocity,
                _agent.MovementSmoothing);

            // Apply the calculated rotation and position
            _agent.ApplyPosAndRot(position, rotation);
        }

        /// <summary>
        /// the function that behaviors need to overrde to calculate
        /// their forces for te agent.
        /// </summary>
        public abstract Vector3 Calculate(AISteeringAgent _agent);
    }
}

