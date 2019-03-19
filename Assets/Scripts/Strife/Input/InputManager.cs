using Fizz6.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizz6.Strife
{
    public class InputManager : Singleton<InputManager>
    {
        private readonly float SelectDelta = 0.2f;

        private readonly float SelectDepth = 1000.0f;

        [SerializeField]
        private Camera camera = null;

        private Vector2 startPosition = Vector2.zero;

        private Vector2 endPosition = Vector2.zero;

        private List<Unit> selectedUnits = new List<Unit>();

        private MeshCollider meshCollider = null;

        protected override void Awake()
        {
            base.Awake();

            Rigidbody rigidbody = this.gameObject.AddComponent<Rigidbody>();
            rigidbody.isKinematic = true;

            this.meshCollider = this.gameObject.AddComponent<MeshCollider>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.startPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                this.endPosition = Input.mousePosition;
                this.Select();
            }

            if (Input.GetMouseButtonDown(1))
            {
                if (this.selectedUnits.Count > 0)
                {
                    RaycastHit raycastHit;
                    Ray ray = this.camera.ScreenPointToRay(Input.mousePosition);
                    Physics.Raycast(ray, out raycastHit);
                    this.selectedUnits.ForEach(unit => this.Move(unit, raycastHit.point));
                }
            }

            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            this.camera.transform.position = new Vector3(this.camera.transform.position.x + x, this.camera.transform.position.y, this.camera.transform.position.z + y);

        }

        private void Select()
        {
            this.selectedUnits.Clear();
            if (Vector2.Distance(this.startPosition, this.endPosition) < this.SelectDelta)
            {
                RaycastHit raycastHit;
                Ray ray = this.camera.ScreenPointToRay(this.startPosition);
                Physics.Raycast(ray, out raycastHit);
                Unit unit = raycastHit.transform.gameObject.GetComponentInParent<Unit>();
                if (unit != null)
                {
                    this.selectedUnits.Add(unit);
                }
            }
            else
            {
                Mesh selectionMesh = this.GenerateSelectionMesh();
                this.meshCollider.sharedMesh = selectionMesh;
                this.meshCollider.convex = true;
                this.meshCollider.isTrigger = true;
            }
        }

        private void OnTriggerEnter(Collider collider)
        {
            Unit unit = collider.GetComponentInParent<Unit>();
            if (unit != null)
            {
                this.selectedUnits.Add(unit);
            }
        }

        private Mesh GenerateSelectionMesh()
        {
            float left = Mathf.Min(this.startPosition.x, this.endPosition.x);
            float right = Mathf.Max(this.startPosition.x, this.endPosition.x);
            float bottom = Mathf.Min(this.startPosition.y, this.endPosition.y);
            float top = Mathf.Max(this.startPosition.y, this.endPosition.y);

            Vector2 lb = new Vector2(left, bottom);
            Vector2 lt = new Vector2(left, top);
            Vector2 rb = new Vector2(right, bottom);
            Vector2 rt = new Vector2(right, top);

            Vector3 lbf = this.camera.ScreenToWorldPoint(lb);
            Vector3 ltf = this.camera.ScreenToWorldPoint(lt);
            Vector3 rbf = this.camera.ScreenToWorldPoint(rb);
            Vector3 rtf = this.camera.ScreenToWorldPoint(rt);

            Ray lbRay = this.camera.ScreenPointToRay(lb);
            Ray ltRay = this.camera.ScreenPointToRay(lt);
            Ray rbRay = this.camera.ScreenPointToRay(rb);
            Ray rtRay = this.camera.ScreenPointToRay(rt);

            Vector3 lbb = lbf + lbRay.direction * this.SelectDepth;
            Vector3 ltb = ltf + ltRay.direction * this.SelectDepth;
            Vector3 rbb = rbf + rbRay.direction * this.SelectDepth;
            Vector3 rtb = rtf + rtRay.direction * this.SelectDepth;

            List<Vector3> vertices = new List<Vector3>()
            {
                lbf, // 0
                ltf, // 1
                rtf, // 2
                rbf, // 3
                lbb, // 4
                ltb, // 5
                rtb, // 6
                rbb, // 7
            };

            int[] indices =
            {
                4, 5, 1, 0, // Left
                3, 2, 6, 7, // Right
                1, 5, 6, 2, // Top
                3, 7, 4, 0, // Bottom
                0, 1, 2, 3, // Front
                7, 6, 5, 4, // Back
            };

            Mesh mesh = new Mesh();
            mesh.SetVertices(vertices);
            mesh.SetIndices(indices, MeshTopology.Quads, 0);

            return mesh;
        }

        private void Move(Unit unit, Vector3 target)
        {
            UnitMovementBehavior unitMovementBehavior = unit.GetComponent<UnitMovementBehavior>();
            if (unitMovementBehavior != null)
            {
                unitMovementBehavior.Target = target;
            }
        }
    }
}