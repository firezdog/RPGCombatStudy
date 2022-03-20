using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;


namespace RPG.Movement
{
    [RequireComponent(typeof(NavMesh))]
	[RequireComponent(typeof(Animator))]
    public class PlayerMover : MonoBehaviour
    {
		NavMeshAgent agent;
		Animator animator;

		public void Start()
		{
			agent = GetComponent<NavMeshAgent>();
			animator = GetComponent<Animator>();
		}

		void Update()
		{
			UpdateAnimator();
		}

		public void MoveTo(Vector3 destination)
		{
			agent.destination = destination;
		}

		void UpdateAnimator()
		{
			Vector3 agentVelocity = agent.velocity;
			Vector3 localVelocity = transform.InverseTransformDirection(agentVelocity);
			animator.SetFloat("Forward", localVelocity.z);
		}

	}
}