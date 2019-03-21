using Fizz6.Core;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Fizz6.Strife
{
    public class Player : MonoBehaviour
    {
        private new Camera camera = null;

        private List<Unit> selectedUnits = new List<Unit>();

        private void Awake()
        {
            this.camera = Camera.main;
        }

        private void Start()
        {
            Global.Instance.Events.On<SelectionEvent>(this.OnSelectionEvent);
        }

        private void OnSelectionEvent(SelectionEvent selectionEvent)
        {
            this.selectedUnits = selectionEvent.Selectables
                .Aggregate(
                    new List<Unit>(),
                    (List<Unit> state, Selectable selectable) =>
                    {
                        Unit unit = selectable.gameObject.GetComponent<Unit>();
                        if (unit != null && unit.Player == this)
                        {
                            state.Add(unit);
                        }
                        return state;
                    }
                );
            Debug.Log(selectedUnits.Count);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit raycastHit;
                Ray ray = this.camera.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out raycastHit);
                this.selectedUnits.ForEach(
                    (Unit unit) =>
                    {
                        UnitMovementBehavior unitMovementBehavior = unit.GetComponent<UnitMovementBehavior>();
                        if (unitMovementBehavior != null)
                        {
                            unitMovementBehavior.Target = raycastHit.point;
                        }
                    }
                );
            }
        }
    }

}