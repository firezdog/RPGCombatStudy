using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

using RPG.Movement;
using RPG.Combat;

namespace RPG.Control
{
    [RequireComponent(typeof(PlayerMover))]
    [RequireComponent(typeof(CombatFighter))]
    public class PlayerController : MonoBehaviour
    {
		PlayerMover playerMover;
		CombatFighter playerFighter;

		// Start is called before the first frame update
		void Start()
        {
            playerMover = GetComponent<PlayerMover>();
            playerFighter = GetComponent<CombatFighter>();
        }

        // Update is called once per frame
        void Update()
        {
            if (InteractWithCombat()) { return; }
            if (InteractWithMovement()) { return; }
        }

        bool InteractWithMovement()
        {
            Ray worldIntersection = GetMouseRay();
            bool hasHit = Physics.Raycast(worldIntersection, out RaycastHit hit);
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
				{
                    playerMover.MoveTo(hit.point);
				}
                return true;
			}
            return false;
        }

        bool InteractWithCombat()
		{
            Ray worldIntersection = GetMouseRay();
            RaycastHit[] hits = Physics.RaycastAll(worldIntersection);
            foreach (RaycastHit hit in hits)
			{
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target == null) { continue; }

                if (Input.GetMouseButtonDown(0))
				{
                    playerFighter.Fight();
				}

                return true;
			}
            return false;
		}

        static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}