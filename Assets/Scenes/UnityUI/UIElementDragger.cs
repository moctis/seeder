using UnityEngine;
using UnityEngine.EventSystems;

public class UIElementDragger : EventTrigger
{
    public bool dragging;
    public GameObject Target;
    public Vector2 startPointer;

    public void Start()
    {
        if (Target == null) Target = gameObject.GetComponent<TargetBehaviour>()?.targetObject;
        if (Target == null) Target = gameObject.GetComponentInChildren<TargetBehaviour>()?.targetObject;
        if (Target == null) Target = gameObject.GetComponentInParent<TargetBehaviour>()?.targetObject;
        if (Target == null) Target = gameObject;
    }

    public void FixedUpdate()
    {
        if (dragging)
        {
            Target.transform.position = new Vector2(Input.mousePosition.x + startPointer.x,
                Input.mousePosition.y + startPointer.y);
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        startPointer = new Vector2(Target.transform.position.x - Input.mousePosition.x,
            Target.transform.position.y - Input.mousePosition.y);

        dragging = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
    }
}