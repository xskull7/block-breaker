using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pixel : MonoBehaviour {
    [SerializeField] float Screenwidthis = 16f;
    [SerializeField] float MinX = 1.98f;
    [SerializeField] float MaxX = 14.03f;
    Gamestatus theGamestatus;
    ball TheBall;
    


    // Use this for initialization
    void Start () {
        theGamestatus = FindObjectOfType<Gamestatus>();
        TheBall = FindObjectOfType<ball>();
		
	}
	
	// Update is called once per frame
	void Update () {
      
        Vector2 padllepos = new Vector2(transform.position.x ,transform.position.y);
        padllepos.x = Mathf.Clamp(GetxPos(), MinX, MaxX);
        transform.position = padllepos;
	}
    private float GetxPos()
    {
        if(theGamestatus.Isautoplayenabled())
        {
           return TheBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * Screenwidthis;
        }
    }
}
