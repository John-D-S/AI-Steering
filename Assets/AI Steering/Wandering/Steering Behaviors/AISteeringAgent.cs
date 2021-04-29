using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Steering
{
    public class AISteeringAgent : MonoBehaviour
    {
        public Vector3 position => transform.localPosition;
        public Quaternion rotation => transform.localRotation;

        public Vector3 Forward => Vector3.forward;
        public Vector3 Right => transform.right;
        public Vector3 Up => Vector3.up;

        public Vector3 CurrentForce => currentForce;
        [System.NonSerialized] public Vector3 velocity;

        public float Speed => speed;
        public float MovementSmoothing => smoothing;

        [SerializeField, Range(.01f, .1f)] private float smoothing = .05f;
        [SerializeField] private new MeshRenderer renderer;
        [SerializeField] private AISteeringBehavior behaviour;

        private Vector3 currentForce;
        private float speed;

        public void Initialise(float _speed) => speed = _speed;
        public void UpdateAgent() => behaviour?.UpdateAgent(this);
        public void UpdateCurrentForce(Vector3 _force) => currentForce = _force;
        public void SetColor(Color _color) => renderer.material.color = _color;

        public void ApplyPosAndRot(Vector3 _pos, Quaternion _rot)
        {
            transform.localPosition = _pos;
            transform.localRotation = _rot;
        }
    }
}
