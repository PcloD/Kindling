﻿using UnityEngine;
using System.Collections;

public class ClickableObject : MonoBehaviour {

	bool isGazedAt = false;
	Color originalColor;

	// Use this for initialization
	void Start () {
		originalColor = GetComponent<Renderer>().material.color;
		UpdateClickVisuals();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void SetGazedAt(bool gaze){
		isGazedAt = gaze;
		UpdateClickVisuals();
	}

	public virtual void ClickObject(){
		ClickableObject[] cos = GetComponents<ClickableObject>(); //Get all scripts that are/derive from ClickableObject on this GameObject
		foreach (ClickableObject co in cos){ //For each of them,
			if(co.GetType().IsSubclassOf(typeof(ClickableObject)) && co != this){ //If we're looking at a subclass of this class,
				co.ClickObject(); //Then call ClickObject() on that script
			} else {
				Debug.Log("Your object does not have a class that derives from ClickableObject that overrides ClickObject()");
			}
		}
	}

	public virtual void UpdateClickVisuals(){
		GetComponent<Renderer>().material.color = isGazedAt ? Color.yellow : originalColor;
	}
}
