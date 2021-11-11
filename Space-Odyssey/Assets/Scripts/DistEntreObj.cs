using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistEntreObj : MonoBehaviour
{
    public GameObject object1;
	//public GameObject object2;
	private float distance;
	/*

    // Start is called before the first frame update
	
    private enum Distance
    {
    	Space,
    	XYPlane
    }

    [SerializeField]
    private GameObject object1;
    [SerializeField]
    private GameObject object2;
    [SerializeField]
    private TextMesh distanceIndicator;
    
    [SerializeField]
    private Distance distanceType;
	
    //private float distance;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    
    void Update()
    {
    	lineRenderer.SetPosition(0, object1.transform.position);
		lineRenderer.SetPosition(1, object2.transform.position);

		switch (distanceType)
		{
			case Distance.Space:
				distance = CalculateDistanceInSpace();
				Debug.Log(distance);
				//distanceIndicator.text = "Distance in Space: " + distance.ToString();
				break;
		}
        
    }
    */
	
    void Update() {
    	distance = calcularDistancia();    	
    	//Debug.Log(distance);
    }
    

    public float calcularDistancia(){
    	distance = (object1.transform.position-this.transform.position).magnitude;
    	return distance;

    }
}
