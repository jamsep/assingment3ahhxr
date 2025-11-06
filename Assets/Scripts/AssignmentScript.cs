using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class AssignmentScript : Singleton<AssignmentScript> {

    // Task 1: Raycasting

    public (GameObject, Vector3?) RaycastDetectionForARPlane(Vector2 screenPosition) {
        Camera mainCamera = Camera.main;
        Ray dragRay = mainCamera.ScreenPointToRay(screenPosition);

        RaycastHit[] hits = Physics.RaycastAll(dragRay);

        foreach (RaycastHit hit in hits) {
            if (hit.collider.gameObject.CompareTag("ARPlane")) {
                return (hit.collider.gameObject, hit.point);
            }
        }

        return (null, null);
    }

    // Task 2: Geometric Registration

    public void GeometricRegistration(GameObject arObject, Vector3 hitPoint, GameObject arPlane) {
        Vector3 pv = arObject.GetComponent<ARInteractable>().AnchorPointOfObject;
        Vector3 nv = arObject.GetComponent<ARInteractable>().NormalDirectionOfObject;

        Vector3 pr = hitPoint;
        arObject.GetComponent<ARInteractable>().currentAnchorPointInWorld = pr;

        Vector3 nr = arPlane.transform.up;
        arObject.GetComponent<ARInteractable>().currentNormalDirectionInWorld = nr;

        Quaternion rotation = Quaternion.FromToRotation(nv, nr);

        arObject.transform.rotation = rotation;
        arObject.transform.position = pr - (arObject.transform.rotation * pv);
    }

    // Task 3: Object Rotation and Scaling

    public void ObjectRotation(GameObject arObject, float deltaAngle) {
        Vector3 rotationAxis = arObject.GetComponent<ARInteractable>().currentNormalDirectionInWorld;
        Vector3 rotationPoint = arObject.GetComponent<ARInteractable>().currentAnchorPointInWorld;

        arObject.transform.RotateAround(rotationPoint, rotationAxis, deltaAngle);
    }
    public void ObjectScaling(GameObject arObject, float scaleRate) {
        Vector3 newScale = arObject.transform.localScale + new Vector3(scaleRate, scaleRate, scaleRate);

        if (newScale.x > 0.1f && newScale.y > 0.1f && newScale.z > 0.1f) {
            arObject.transform.localScale = newScale;
        }
    }

}
