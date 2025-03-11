using TMPro;
using UnityEngine;

public class MathDistance : MonoBehaviour
{
    public TextMeshPro infoText;

    public Transform pointA;
    public Transform pointB;
    public Transform pointC;

    public LineRenderer line2Points;
    public LineRenderer line2Floor;

    void Update()
    {
        infoText.text = "Red Vector3: " + pointA.position.ToString() + "\n";

        infoText.text += "Distance: " + 
           (Vector3.Distance(pointA.position, pointB.position)*100).ToString("0000 cm")+ "\n";

        // show line between two points
        line2Points.positionCount = 2;
        line2Points.SetPosition(0, pointA.position); // red point
        line2Points.SetPosition(1, pointB.position);

        float magnitude = Vector3.Magnitude(pointA.position);
        infoText.text += "Magnitude: " + (magnitude*100).ToString("0000 cm") + "\n";

        // show line to floor
        line2Floor.positionCount = 2;
        line2Floor.SetPosition(0, pointB.position); // red yellow
        line2Floor.SetPosition(1, new Vector3(pointB.position.x, 0, pointB.position.z)); 

        pointC.position = new Vector3(pointB.position.x, 0, pointB.position.z);
    }
}
