using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickLayer : MonoBehaviour
{
    public Brick OneHit;
    public Brick TwoHit;
    public Brick ThreeHit;

    public GameObject FirstLevel;
    public GameObject SecondLevel;
    public GameObject ThirdLevel;


	// Use this for initialization
	void Start ()
    {
        FirstLevel = new GameObject();
        SecondLevel = new GameObject();
        ThirdLevel = new GameObject();

        FirstLevel.name = "FirstLevel";
        SecondLevel.name = "SecondLevel";
        ThirdLevel.name = "ThirdLevel";

        FirstLevel.transform.position = new Vector3();
        SecondLevel.transform.position = new Vector3();
        ThirdLevel.transform.position = new Vector3();

        OneHit = Resources.Load<Brick>("Prefabs/One hit block");
        TwoHit = Resources.Load<Brick>("Prefabs/One hit block 1");
        ThreeHit = Resources.Load<Brick>("Prefabs/One hit block 2");

        for (int x = 0; x < 3; x++)
        {
            for (int i = 0; i < 16; i++)
            {
                if (x == 0)
                {
                    var fab = Instantiate<Brick>(OneHit);
                    fab.transform.position = new Vector3(i + 0.51f, x + 7.82f, 0f);
                    fab.transform.parent = FirstLevel.transform;
                }
                if(x == 1)
                {
                    var fab = Instantiate<Brick>(TwoHit);
                    fab.transform.position = new Vector3(i + 0.51f, (7.82f + 0.36f), 0f);
                    fab.transform.parent = SecondLevel.transform;
                }
                if(x == 2)
                {
                    var fab = Instantiate<Brick>(ThreeHit);
                    fab.transform.position = new Vector3(i + 0.51f, (7.82f + 0.36f + 0.36f), 0f);
                    fab.transform.parent = ThirdLevel.transform;
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
