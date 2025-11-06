using System.Collections;
using TMPro;
using UnityEngine;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class AssignmentScript : Singleton<AssignmentScript> {

    // Task 1: Raycasting

    public (GameObject, Vector3?) RaycastDetectionForARPlane(Vector2 screenPosition) {
        throw new System.NotImplementedException();
    }

    // Task 2: Geometric Registration

    public void GeometricRegistration(GameObject arObject, Vector3 hitPoint, GameObject arPlane) {
        throw new System.NotImplementedException();
    }

    // Task 3: Object Rotation and Scaling

    public void ObjectRotation(GameObject arObject, float deltaAngle) {
        throw new System.NotImplementedException();
    }
    public void ObjectScaling(GameObject arObject, float scaleRate) {
        throw new System.NotImplementedException();
    }

}