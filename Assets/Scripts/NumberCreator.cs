using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberCreator : MonoBehaviour {

	/*public GameObject pooledObject;
	public int pooledAmount;
	public List <GameObject> pooledObjects;
	private int length;
	private int numberSelector;
	*/

	/*void Start () {
		pooledObjects = new List <GameObject> ();

		for (int i = 0; i < pooledAmount; i++){
			GameObject obj = Instantiate (pooledObject);
			obj.SetActive (false);
			pooledObjects.Add (obj);
		}

		foreach (GameObject o in pooledObjects) {
			length++;
		}
	}*/


	/*public GameObject GetPooledObject () {
		
		for (int i = 0; i < pooledObjects.Count; i++){
			if (!pooledObjects [i].activeInHierarchy) {
				return pooledObjects [i];
			}
		}

		GameObject obj = Instantiate (pooledObject);
		obj.SetActive (false);
		pooledObjects.Add (obj);

		return obj;
	}*/

	void GenerateNumber (){

		/*numberSelector = Random.Range (0, length);
		distanceToGenerate = Random.Range (-maxDistanceToGenerate, maxDistanceToGenerate);
		rotationAngle = Random.Range (-maxRotationAngle, maxRotationAngle);

		GameObject newNumber = theObjectPools[numberSelector].GetPooledObject ();

		newNumber.transform.position = new Vector3 (transform.position.x + distanceToGenerate, transform.position.y, transform.position.z);
		newNumber.transform.eulerAngles = new Vector3 (0, 0, rotationAngle);
		newNumber.transform.Rotate (Vector3.up * Time.deltaTime, Space.World);
		newNumber.SetActive (true);*/

		//transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

		//generateNumber = false;
	}

}