using UnityEngine;

public class PropsMovement : MonoBehaviour
{
	[SerializeField]
	protected Transform initPos, finalPos;

	protected Vector3 nextPos;

	[SerializeField]
	protected float moveSpeed;

	private void Start()
	{
		if (initPos == null || finalPos == null)
		{
			Debug.LogError("Either initial position or final position is null. Please check.");
		}
		nextPos = initPos.position;
	}

	private void Update()
	{
		Move(initPos, finalPos);
	}

	public virtual void Move(Transform initPos, Transform finalPos)
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

	private void OnDrawGizmos()
	{
		Gizmos.DrawLine(initPos.position, finalPos.position);
	}
}
