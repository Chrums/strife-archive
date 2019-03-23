using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizz6.Core
{
    public class RTSCameraController : MonoBehaviour
    {
        [SerializeField]
        private float acceleration = 10.0f;

        [SerializeField]
        private float deceleration = 0.5f;

        [SerializeField]
        private float mouseScrollSize = 10.0f;

        public Vector3 Acceleration
        {
            get;
            private set;
        }
        = Vector3.zero;

        public Vector3 Velocity
        {
            get;
            private set;
        }
        = Vector3.zero;

        protected void Update()
        {
            float horizontal = Input.GetAxis("Horizontal") != 0.0f
                ? Input.GetAxis("Horizontal")
                : Input.mousePosition.x < this.mouseScrollSize
                    ? -1.0f
                    : Input.mousePosition.x > Screen.width - this.mouseScrollSize
                        ? 1.0f
                        : 0.0f;
            float vertical = Input.GetAxis("Vertical") != 0.0f
                ? Input.GetAxis("Vertical")
                : Input.mousePosition.y < this.mouseScrollSize
                    ? -1.0f
                    : Input.mousePosition.y > Screen.height - this.mouseScrollSize
                        ? 1.0f
                        : 0.0f;
            this.Acceleration = new Vector3(horizontal, 0.0f, vertical).normalized * this.acceleration * Time.deltaTime;
            this.Velocity += this.Acceleration;
            this.transform.position += Quaternion.AngleAxis(this.transform.rotation.eulerAngles.y, Vector3.up) * this.Velocity;
            this.Velocity *= this.deceleration;
        }
    }
}