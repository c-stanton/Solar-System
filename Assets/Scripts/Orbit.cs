using System.Drawing;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public LineRenderer circleRenderer;
    public float radius;

    void Start()
    {
        circleRenderer.positionCount = 100;
        DrawCircle(100, radius);
    }

    void DrawCircle(int steps, float radius)
    {
        for (int currentStep = 0; currentStep < steps; currentStep++)
        {
            float interval = (float)currentStep / steps;
            float currentRadian = interval * 2 * Mathf.PI;

        
            float xAngle = Mathf.Cos(currentRadian);
            float zAngle = Mathf.Sin(currentRadian);

            float xCurrent = xAngle * radius;
            float zCurrent = zAngle * radius;

            Vector3 currentPosition = new Vector3(xCurrent, 0, zCurrent);
            circleRenderer.SetPosition(currentStep, currentPosition);
        }
    }
}