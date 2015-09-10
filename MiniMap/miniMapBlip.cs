//This mini map blip is based off the new Unity 5 UI https://www.youtube.com/watch?v=EeyZ2y2Jpz4
/*---------------------------------------------------------------------
Use Instructions: 

Player Object
	Add blip script
	Target = Player
	
Enemy Object
	Add blip script
	Target = Enemy	

Note: Requiers miniMap script
--------------------------------------------------------------------------*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class miniMapBlip : MonoBehavior
{
	public Transform Target;
	public bool KeepInBounds = true;
	public bool LockScale = false;
	public bool LockRotation = false;
	public float MinScale = .2f;
	
	MiniMap map;
	RectTransform myRectTransform;
	
	void Start()
	{
		map = GetComponentInParrent<MiniMap>();
		myRectTransform = GetComponent<RectTransform>();
	}
	
	void LateUpdate()
	{
		Vector2 newPosition = map.TransformPosition(Target.position);
		
		if (KeepInBounds)
			newPosition = map.MoveInside(newPosition);
		
		if(!LockScale)
		{
			float scale = Mathf.Max(MinScale, map.zoomLevel);
			myRectTransform.localScale = new Vector3(scale, scale, 1);
		}
					
		if(!LockRotation)
			myRectTransform.localEulerAngels = map.TransformRotation(Target.EularAngels);
		
		myRectTransform.localPosition = newPosition;
	}
	
	
}
