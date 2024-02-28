using UnityEngine;
using System.Collections;
using System.Linq;
using System;
using System.Xml.Linq;
using System.Runtime.ConstrainedExecution;

public class CarDetectorScript : MonoBehaviour {

	public float angle = 360;
	public bool ApplyThresholds, ApplyLimits;
	public float MinX, MaxX, MinY, MaxY;
	private bool useAngle = true;

	public float output;
	public int numObjects;

	void Start()
	{
		output = 0;
		numObjects = 0;

		if (angle > 360)
		{
			useAngle = false;
		}
	}

	void Update()	
	{

		GameObject[] cars;
		GameObject closestBlock = null;
		GameObject closestCar = null;
		float dis = -1.0f;
		float r = 0.0f;


		//função que devolve todos os carros do cenário com a tag "carToFollow"
        cars = GetAllCars();

		output = 0;

		// YOUR CODE HERE

		//iterar todos os carros do ArrayList e verificar qual é o mais próximo do carro com os sensores  
		foreach (GameObject car in cars)
		{
            
			if(dis == -1.0f)
			{
                dis = Vector3.Distance(transform.position, car.transform.position);
				closestCar = car;
			} else if (dis > Vector3.Distance(transform.position, car.transform.position))
			{
				dis = Vector3.Distance(transform.position, car.transform.position);
				closestCar = car;
			}
			
            
            
        }

		//aumentar a velocidade da roda
        output += 1.0f / ((transform.position - closestCar.transform.position).sqrMagnitude / dis + 1);
        //Debug.DrawLine(transform.position, closestCar.transform.position, Color.red);

    }

    public virtual float GetOutput() { throw new NotImplementedException(); }

    // Returns all "CarToFollow" tagged objects. The sensor angle is not taken into account.
    GameObject[] GetAllCars()
	{
		return GameObject.FindGameObjectsWithTag("CarToFollow");
	}



}
