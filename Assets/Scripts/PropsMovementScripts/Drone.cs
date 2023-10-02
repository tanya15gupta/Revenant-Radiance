using UnityEngine;
using System.Collections;
public class Drone : PropsMovement
{
	private Vector3 scale;
	//private GameObject laser;
	//private Vector3 randomPosition;
	//private float rand;


	private void Update()
	{
		Move(initPos, finalPos);
	}

	public override void Move(Transform initPos, Transform finalPos)
	{
		/*random = Random.Range(0.0f, upperTimeLimit);
		rotate = transform.localRotation;*/

		if (transform.position == initPos.position)
		{
			nextPos = finalPos.position;
			Flip();
		}


		if (transform.position == finalPos.position)
		{
			nextPos = initPos.position;
			Flip();
		}

		//rand = Random.Range(initPos.position.x, finalPos.position.x);
		//randomPosition = new Vector3(rand, transform.position.y, transform.position.z);
		transform.position = Vector3.MoveTowards(transform.position, nextPos, moveSpeed * Time.deltaTime);
		//transform.position = Vector3.MoveTowards(transform.position, randomPosition, moveSpeed * Time.deltaTime);
		//StartCoroutine(LaserOn());
	}

	/*IEnumerator LaserOn()
	{
		yield return new WaitForSeconds(upperTimeLimit);
		transform.position = Vector3.MoveTowards(randomPosition, nextPos, moveSpeed * Time.deltaTime);
	}*/

	private void Flip()
	{
		scale = transform.localScale;
		scale.x = scale.x * -1.0f;
		transform.localScale = scale;
	}
}
