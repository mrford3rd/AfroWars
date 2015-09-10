//This code is from my own thoughts
Create a panel
	on level load
		set background inage to level
	
		set player blip to spawn player point
		move blip in rotation and direction of player
	
		set enemy blip to enemy
		on swawn of enemy
			create a new blip 
	
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

	public Transfrom target;
	MiniMap map;
	RectTransform myRectTransform;
	
	void Start()
	{	
		//On startup get map and blip transfrom
		map = GetComponentInParrent<MiniMap>();
		myRectTransform = GetComponent<RectTransform>();
	}

	void LateUpdate()
	{
		//Set blip location to player location relitave to map
	}
	}
