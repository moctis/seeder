using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour
{
    public Text Count;
    public Vector3 M0;
    public GameObject TargetObject;
    public Plane TargetPlane;

    Ray GenerateRay(Vector3 touchPos)
    {
        var far = new Vector3(touchPos.x, touchPos.y, Camera.main.farClipPlane);
        var near = new Vector3(touchPos.x, touchPos.y, Camera.main.nearClipPlane);
        var posF = Camera.main.ScreenToWorldPoint(far);
        var posN = Camera.main.ScreenToWorldPoint(near);
        var mr = new Ray(posN, posF - posN);
        return mr;
    }

    void Update()
    {
        if (Count != null) Count.text = Input.touchCount.ToString();
        switch (Input.touchCount)
        {
            case 0 when Input.GetMouseButtonDown(0):
                HandleTouch(10, Input.mousePosition, TouchPhase.Began);
                break;
            case 0 when Input.GetMouseButton(0):
                HandleTouch(10, Input.mousePosition, TouchPhase.Moved);
                break;
            case 0 when Input.GetMouseButtonUp(0):
                HandleTouch(10, Input.mousePosition, TouchPhase.Ended);
                break;
            default:
                foreach (var touch in Input.touches)
                {
                    HandleTouch(touch.fingerId, touch.position, touch.phase);
                }

                break;
        }
    }

    private void HandleTouch(int touchFingerId, Vector3 position, TouchPhase phase)
    {
        switch (phase)
        {
            case TouchPhase.Began:
                Began(position);
                break;
            case TouchPhase.Moved:
                Moved(position);
                break;
            case TouchPhase.Stationary:
                break;
            case TouchPhase.Ended:
                Ended();
                break;
            case TouchPhase.Canceled:
                break;
        }
    }

    private void Ended()
    {
        TargetObject = null;
    }

    private void Moved(Vector2 touchPosition)
    {
        if (TargetObject)
        {
            var touchRay = Camera.main.ScreenPointToRay(touchPosition);
            if (TargetPlane.Raycast(touchRay, out var distance))
            {
                TargetObject.transform.position = touchRay.GetPoint(distance) + M0;
            }
        }
    }

    private void Began(Vector2 touchPosition)
    {
        var ray = GenerateRay(touchPosition);
        if (Physics.Raycast(ray.origin, ray.direction, out var hit))
        {
            TargetObject = hit.transform.gameObject;
            TargetPlane = new Plane(Camera.main.transform.forward * -1, TargetObject.transform.position);

            // calc touch offset
            var touchRay = Camera.main.ScreenPointToRay(touchPosition);
            TargetPlane.Raycast(touchRay, out var distance);
            M0 = TargetObject.transform.position - ray.GetPoint(distance);
        }
    }
}