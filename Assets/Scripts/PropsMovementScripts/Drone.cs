using UnityEngine;

public class Drone : PropsMovement
{
	private Vector3 scale;

	private void Update()
	{
		Move(initPos, finalPos);
	}

	public override void Move(Transform initPos, Transform finalPos)
	{
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

		transform.position = Vector3.MoveTowards(transform.position, nextPos, moveSpeed * Time.deltaTime);
	}

	private void Flip()
	{
		scale = transform.localScale;
		scale.x = scale.x * -1.0f;
		transform.localScale = scale;
	}
}
