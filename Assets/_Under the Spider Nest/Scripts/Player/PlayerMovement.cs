using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	private CharacterController controller;
	public float speed = 5f;

	float rotSpeed = 10f;

	private Animator animator;
	private Camera camera;
	private bool aim;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		controller = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
		camera = Camera.main;
	}

	// Update is called once per frame
	void Update()
	{
		Movement();
	}

	void Movement()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		aim = Input.GetMouseButton(1);


		controller.Move(new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime);
		animator.SetBool("Walking", true);

		Vector3 targetDirection = new Vector3(horizontal, 0, vertical);

		if (aim)
		{
			Aim();
		}
		else if (targetDirection != Vector3.zero)
		{
			Rotate(targetDirection);

		}
		//    animator.SetBool("Walking", false);
	}

	private void Rotate(Vector3 rotationTarget)
	{
		Quaternion targetRotation = Quaternion.LookRotation(rotationTarget);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
	}

	private void Aim()
	{
		//Hacer un raycast desde la cámara hacia la pocisión del mopuse
		Ray ray = camera.ScreenPointToRay(Mouse.current.position.value);
		RaycastHit hit;
		Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity);

		//Si el racyast golpea un punto ese será el objetivo para mirar, si no obtener el útimo punto del rayo
		Vector3 point = hit.collider != null ? hit.point : ray.GetPoint(Mathf.Infinity);
		Debug.DrawRay(ray.origin, ray.direction * Mathf.Infinity);

		//Obtener la dirección del punto obtenido respecto al jugador, hacer el eje y 0 para que solamente rote en dicho eje.
		Vector3 direction = point - transform.position;
		direction.y = 0;
		Rotate(direction);
	}
}
