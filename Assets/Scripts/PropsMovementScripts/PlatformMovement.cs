using UnityEngine;

public class PlatformMovement : PropsMovement
{
	public override void Move(Transform initPos, Transform finalPos)
	{

		if (transform.position == initPos.position)
		{
			nextPos = finalPos.position;
		}

		if (transform.position == finalPos.position)
		{
			nextPos = initPos.position;
		}

		transform.position = Vector3.MoveTowards(transform.position, nextPos, moveSpeed * Time.deltaTime);
	}
}
