using UnityEngine;
using STP.Input;

namespace STP.Ship
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private InputReader inputReader;

        public Camera cam;

        ShipController ship;
        CannonController cannons;
        CannonDoors cannonDoors;

        private Vector2 mousePos;

        private void Awake() {
            ship = GetComponent<ShipController>();
            cannons = GetComponentInChildren<CannonController>();
            cannonDoors = GetComponentInChildren<CannonDoors>();
        }

        private void OnEnable() {
            inputReader.mouseMoveEvent += OnMouseMove;
            inputReader.mouseClickEvent += OnMouseClick;
            inputReader.fireEvent += OnFire;
            inputReader.toggleDoorsEvent += OnToggleDoors;
        }

        private void OnDisable() {
            inputReader.mouseMoveEvent -= OnMouseMove;
            inputReader.mouseClickEvent -= OnMouseClick;
            inputReader.fireEvent -= OnFire;
            inputReader.toggleDoorsEvent += OnToggleDoors;
        }

        private void OnMouseMove(Vector2 pos) {
            mousePos = pos;
        }

        private void OnMouseClick() {
            Ray ray = cam.ScreenPointToRay(mousePos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                ship.Move(hit.point);
            }
        }

        private void OnFire() {
            cannons.Fire();
        }

        private void OnToggleDoors() {
            cannonDoors.ToggleDoors();
            cannons.ToggleCannons();
        }
    }
}
