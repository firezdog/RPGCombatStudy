using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMesh))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
		{
            MoveToClick();
		}
        UpdateAnimator();
    }

    void MoveToClick()
	{
        Ray worldIntersection = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(worldIntersection, out hit);
        agent.destination = hit.point;
	}

    void UpdateAnimator()
	{
        Vector3 agentVelocity = agent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(agentVelocity);
        animator.SetFloat("Forward", localVelocity.z);
	}
}
