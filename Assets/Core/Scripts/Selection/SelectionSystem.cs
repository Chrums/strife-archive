using Fizz6.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizz6.Core
{
    public class SelectionSystem : Singleton<SelectionSystem>
    {
        private readonly int SelectionMouseButton = 0;

        private readonly float GroupSelectionDragDistance = 0.05f;

        private new Camera camera = null;

        [SerializeField]
        private Color selectionColor = new Color(1.0f, 1.0f, 1.0f, 0.2f);

        [SerializeField]
        private Texture2D selectionTexture = null;

        private Vector2? selectionStart = null;

        private Vector2? selectionEnd = null;

        private List<Selectable> selectables = new List<Selectable>();

        public void Add(Selectable selectable)
        {
            this.selectables.Add(selectable);
        }

        public void Remove(Selectable selectable)
        {
            this.selectables.Remove(selectable);
        }

        protected override void Awake()
        {
            base.Awake();
            this.camera = Camera.main;
            if (this.selectionTexture == null)
            {
                this.selectionTexture = new Texture2D(1, 1);
                this.selectionTexture.SetPixel(0, 0, Color.white);
                this.selectionTexture.Apply();
            }
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(this.SelectionMouseButton))
            {
                this.selectionStart = Input.mousePosition;
                this.selectionEnd = Input.mousePosition;
            }
            else if (Input.GetMouseButton(this.SelectionMouseButton))
            {
                this.selectionEnd = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(this.SelectionMouseButton))
            {
                this.Select();
                this.selectionStart = null;
                this.selectionEnd = null;
            }
        }

        private void Select()
        {
            List<Selectable> selectables = new List<Selectable>();
            if (this.selectionStart.HasValue && this.selectionEnd.HasValue)
            {
                if (Vector2.Distance(this.selectionStart.Value, this.selectionEnd.Value) < this.GroupSelectionDragDistance)
                {
                    Ray ray = this.camera.ScreenPointToRay(this.selectionStart.Value);
                    Physics.Raycast(ray, out RaycastHit hitInfo);
                    if (hitInfo.collider != null)
                    {
                        Selectable selectable = hitInfo.collider.gameObject.GetComponent<Selectable>();
                        if (selectable != null)
                        {
                            selectables.Add(selectable);
                        }
                    }
                }
                else
                {
                    Vector3 viewportStart = this.camera.ScreenToViewportPoint(this.selectionStart.Value);
                    Vector3 viewportEnd = this.camera.ScreenToViewportPoint(this.selectionEnd.Value);
                    Vector3 viewportMin = Vector3.Min(viewportStart, viewportEnd);
                    viewportMin.z = this.camera.nearClipPlane;
                    Vector3 viewportMax = Vector3.Max(viewportStart, viewportEnd);
                    viewportMax.z = this.camera.farClipPlane;
                    Bounds viewportBounds = new Bounds();
                    viewportBounds.SetMinMax(viewportMin, viewportMax);

                    this.selectables.ForEach(
                        (Selectable selectable) =>
                        {
                            //Collider collider = selectable.GetComponent<Collider>();
                            //Vector3 colliderMin = collider.bounds.min;
                            //Vector3 colliderMax = collider.bounds.max;
                            //Vector3 colliderViewportMin = this.camera.WorldToViewportPoint(colliderMin);
                            //Vector3 colliderViewportMax = this.camera.WorldToViewportPoint(colliderMax);
                            //if (viewportBounds.Contains(colliderViewportMin) || viewportBounds.Contains(colliderViewportMax))
                            //{
                            //    selectables.Add(selectable);
                            //}
                            Collider collider = selectable.GetComponent<Collider>();
                            Vector3 colliderViewportPosition = this.camera.WorldToViewportPoint(collider.bounds.center);
                            if (viewportBounds.Contains(colliderViewportPosition))
                            {
                                selectables.Add(selectable);
                            }
                        }
                    );
                }
            }
            SelectionEvent selectionEvent = new SelectionEvent(selectables);
            EventSystem.Instance.Emit(selectionEvent);
        }

        private void OnGUI()
        {
            if (this.selectionStart.HasValue && this.selectionEnd.HasValue)
            {
                Vector2 selectionStart = new Vector2(this.selectionStart.Value.x, Screen.height - this.selectionStart.Value.y);
                Vector2 selectionEnd = new Vector2(this.selectionEnd.Value.x, Screen.height - this.selectionEnd.Value.y);
                Vector2 leftTop = Vector2.Min(selectionStart, selectionEnd);
                Vector2 rightBottom = Vector2.Max(selectionStart, selectionEnd);
                Rect selectionRect = Rect.MinMaxRect(leftTop.x, leftTop.y, rightBottom.x, rightBottom.y);
                GUI.color = selectionColor;
                GUI.DrawTexture(selectionRect, this.selectionTexture);
                GUI.color = Color.white;
            }
        }
    }
}