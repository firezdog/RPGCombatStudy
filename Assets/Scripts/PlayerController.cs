using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

using RPG.Movement;

namespace RPG.Control
{
    [RequireComponent(typeof(PlayerMover))]
    public class PlayerController : MonoBehaviour
    {
		PlayerMover playerMover;

		// Start is called before the first frame update
		void Start()
        {
            playerMover = GetComponent<PlayerMover>();
        }

        // Update is called once per frame
        void Update()
        {
            if (InteractWithMovement()) { return; }
        }

        bool InteractWithMovement()
        {
            bool hasInteraction = false;
            if (Input.GetMouseButton(0))
            {
                // it's more efficient to only do the raycast if the player clicks the mouse!
                Ray worldIntersection = GetMouseRay();
                bool hasDestination = Physics.Raycast(worldIntersection, out RaycastHit hit);
                if (hasDestination)
				{
                    playerMover.MoveTo(hit.point);
                    hasInteraction = true;
				}
            }
            return hasInteraction;
        }

        static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}