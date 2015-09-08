using UnityEngine;
using System.Collections;

public class RayCastShooting : MonoBehavior
{

    public float range = 100f;                      // The distance the gun can fire.
	Ray shootRay;                                   // A ray from the gun end forwards.
    RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
	int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.
	
	void ShootRay()
	{
		
		// Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
        shootRay = Camera.main.ScreenPointToRay(Input.mousePosition)
		
		  // Perform the raycast against gameobjects on the shootable layer and if it hits something...
        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        {
         	//As long as your hitting an object in the ShootableMask it will fire   			
			//Instantiate(myPrefab, shootHit.point, Quaternion.identity);
		}	
	}
}
