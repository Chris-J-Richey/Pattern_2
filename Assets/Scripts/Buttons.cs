﻿using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

	public trainstate switcher;

	private bool clicked;

	public GameObject btnLeft;
	public GameObject btnRight;
	public GameObject btnStop;
	public GameObject btnRandom;

	public Vector3 thingy = new Vector3(0, .5f, 0);

	void Start(){
	}

	void Update(){
		if (Input.GetMouseButtonDown(0)) {
			var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.tag == "Left") {
					switcher.which = 1;
					StartCoroutine (DownUp(btnLeft)); 
				}
				if (hit.collider.tag == "Right") {
					switcher.which = 0;
					StartCoroutine (DownUp(btnRight)); 
				}
				if (hit.collider.tag == "Stop") {
					switcher.which = 2;
					StartCoroutine (DownUp(btnStop)); 
				}
				if (hit.collider.tag == "Random") {
					int choose = Random.Range (0, 3);
					switcher.which = choose;
					StartCoroutine (DownUp(btnRandom)); 
				}
			}
		}
	}
	IEnumerator DownUp(GameObject btn){
		btn.transform.position -= thingy;
		yield return new WaitForSeconds (.1f);
		btn.transform.position += thingy;
	}
}
