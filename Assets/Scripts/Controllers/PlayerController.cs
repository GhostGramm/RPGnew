using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;

namespace RPG.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        void Update()
        {
            MovementInteraction();
            GetTargetToAttack();
        }

        void MovementInteraction()
        {
            if (Input.GetMouseButton(0))
            {
                MoveToPoint();
            }
        }

        void MoveToPoint()
        {
            RaycastHit hit;
            bool isValid = Physics.Raycast(GetScreenPointRay(), out hit);

            if (isValid)
            {
                GetComponent<Mover>().MoveTo(hit.point);
            }
        }

        void GetTargetToAttack()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetScreenPointRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target != null)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        PerformAttack(target);
                    }
                }
            }
        }

        void PerformAttack(CombatTarget target)
        {
            GetComponent<Fighter>().Attack(target);
        }

        public Ray GetScreenPointRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}

