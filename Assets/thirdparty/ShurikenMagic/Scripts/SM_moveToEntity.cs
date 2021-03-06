using UnityEngine; 
using System; 
using System.Collections.Generic;

class SM_moveToEntity : MonoBehaviour 
{
	public UnityEngine.GameObject target = null;
	public float moveSpeed = 5.0f;
	double lastUpdateTime = 0.0;
	
	void Awake ()   
	{
		lastUpdateTime = Time.time;
	}
	
	void Start() 
	{
	}
	
	void Update () 
	{
		Vector3 targetPos = target.transform.position;
		float thisDeltaTime = (float)(Time.time - lastUpdateTime);
		float deltaSpeed = (moveSpeed * thisDeltaTime);
		
		float dist = Vector3.Distance(transform.position, 
			targetPos);

		if(dist > 0.05f)
		{
			Vector3 pos = transform.position;

			Vector3 movement = targetPos - pos;
			movement.Normalize();
			
			movement *= deltaSpeed;
			
			if(dist > deltaSpeed || movement.magnitude > deltaSpeed)
				pos += movement;
			else
				pos = targetPos;

			transform.position = pos;
		}
		else
		{
			Destroy(gameObject, 0.3f);
		}
		
		lastUpdateTime = Time.time;
	}
}