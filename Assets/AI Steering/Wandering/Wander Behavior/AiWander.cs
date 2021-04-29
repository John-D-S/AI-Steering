using UnityEngine;

// Namespaces are like home addresses. Anything under the namespace would live in the house.
// The 'root' namespace should always be the name of your game
// and each module of your game should have it's own sub-namespace; ie: Enemies, Towers, UI
namespace Wandering
{
    public class AiWander : MonoBehaviour
    {
        [SerializeField, Range(.01f, 0.1f)] private float jitter = .05f;
        [SerializeField, Min(1f)] private float speed = 1;
        [SerializeField] private float smoothing = .1f;

        // The force driving the agent. It updates every frame
        private Vector3 currentForce = Vector3.zero;
        // The speed the smoothed position is travelling
        private Vector3 velocity = Vector3.zero;

        // Update is called once per frame
        void Update()
        {
            Vector3 movement = (transform.forward + (CalculateForce() * speed)) * Time.deltaTime;
            Vector3 position = Vector3.SmoothDamp(transform.position, transform.position + movement, ref velocity, smoothing);

            // calculate he rotation from were wer are looking to the new one
            Quaternion rotation = Quaternion.Slerp(
                transform.localRotation,
                Quaternion.LookRotation(currentForce),
                Time.deltaTime);

            transform.position = position;
            transform.rotation = rotation;
        }

        /// <summary>
        /// Calculates the force to be applied to the agent.
        /// it useses jitter to create the wandering effect.
        /// </summary>
        /// <returns></returns>
        private Vector3 CalculateForce()
        {
            // first copy the current force and calculate the random offset using jitter
            Vector3 force = currentForce;
            Vector2 offset = new Vector2(Random.Range(-jitter, jitter), Random.Range(-jitter, jitter));

            // add the offset to the horizontal and vertical axis of the transform
            force += transform.right * offset.x;
            force += transform.up * offset.y;

            force.Normalize();

            // make sure the force is normalised because it is a direction
            currentForce = force;
            return force;
        }
    }
}
