using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : ProcessingLite.GP21
{

    public Vector2 circlePosition;
    public float diameter = 20;
    //speed
    Vector2 circleVelocity;
    float maxSpeed = 0.25f;





    // Start is called before the first frame update
    void Start()
    {
        
    }

 
        // Update is called once per frame
        void Update()
    {
        
        Background(0);
        

       
        Circle(circlePosition.x, circlePosition.y, diameter);

        //speed gammal
        //circlePosition.x = circlePosition.x + 0.005f;
       // circlePosition.y = circlePosition.y + 0.005f;

       
      
        if(Input.GetMouseButtonDown(0))
        {
            circlePosition.x = MouseX;
            circlePosition.y = MouseY;
            circleVelocity = Vector2.zero; //stannar cirkeln när man klickar
        }

        //When the left mouse button is released (Input.GetMouseButtonUp(0)), it calculates a new circleVelocity based on the mouse's current position
        //and the circle's position. It normalizes the velocity and ensures it doesn't exceed the maxSpeed.
        if (Input.GetMouseButtonUp(0))
        {
            circleVelocity = (new Vector2(MouseX, MouseY) - circlePosition) * 0.01f;

            if (circleVelocity.magnitude > maxSpeed)
            {
                circleVelocity.Normalize();
                circleVelocity *= maxSpeed;
            }


        }

        if (Input.GetMouseButton(0))
        {
            Line(circlePosition.x, circlePosition.y, MouseX, MouseY);
        }

        if (circlePosition.x > Width || circlePosition.x < 0) 
        {
            circleVelocity.x *= -1;
        }
        if (circlePosition.y > Height || circlePosition.y < 0)
        {
            circleVelocity.y *= -1;
        }




        circlePosition += circleVelocity;


        //Line(circlePosition.x, circlePosition.y, MouseX, MouseY);

    }
}
