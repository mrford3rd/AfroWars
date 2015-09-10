//This mini_map is based off the new Unity 5 UI https://www.youtube.com/watch?v=EeyZ2y2Jpz4
/*---------------------------------------------------------------------
Use Instructions: 

Player Object
	Add blip script
	Target = Player
	
Enemy Object
	Add blip script
	Target = Enemy
	
Create Panel
	Anchor to Corner
	Add two UI Images
		1. Player Blip - set color and scale
		2. Enemy Blip  - set color and scale
	Add MiniMap Script
		Target = player blip
		Change the execution order to process the mini map script first before the blip script
	Add UI Image - Level Texture
		Set scale	

Note: Requiers miniMapBlip script
--------------------------------------------------------------------------*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MiniMap : MonoBehavior
{
	public Transform Target;
	public float ZoomLevel = 10f;
	public bool LockRotation = false;
	
	Vector2 XRotation = Vector2.right;
	Vector2 YRotation = Vector2.up;
	
	void LateUpdate()
	{
		if (!LockRotation)
		{
			XRotation = new Vector2(Target.right.x, -Target.right.z);	
			YRotation = new Vector2(-Target.forward.x, Target.forward.z);	
		}
		
	}
	
	public Vector2 TransformfromPosition(Vector3 position)
	{
		Vector3 offset = position - Target.position;
		Vector2 newPosition = offset.x * XRotation;
		        newPosition += offset.z * YRotation;
		
		newPosition *= ZoomLevel;
		
		return newPosition;
	}
	
	public Vecoter3 TransformRotation(Vector3 rotation)
	{
		if(LockRotation)
			return new Vector3 (0,0, -rotation.y)
		else
			return new Vecoter3(0,0, Target.eulerAngles.y - rotation.y)	;
	}
	
	}
	public Vector2 MoveInside(Vector2 point)
	{
		Rect mapRect = GetComponent<Rectransform>().rect;
		point = Vector2.Max(point, mapRect.min);
		point = Vector2.Min(point, mapRect.max);
		
		return point;
	}
	
}
