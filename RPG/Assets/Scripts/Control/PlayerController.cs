using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;


namespace RPG.Control
{

    public class PlayerController : MonoBehaviour
    {

        void MoveToCursor(Vector3 targetPosition)
        {
            Ray ray = Camera.main.ScreenPointToRay(targetPosition);
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit);
            if (hasHit)
            {
                //! Call mover function to move player
                GetComponent<Mover>().MoveTo(hit.point);
            }

        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor(Input.mousePosition);

            }
        }
    }

}


