using UnityEngine;

public class JoystickControl
{
    private float maxDisplacement = 30;
    private Vector2 startPos;
    private RectTransform handle;

    public static float Horizontal { get; private set; }
    public static float Vertical { get; private set; }
        
    //init in Start 
    public JoystickControl(RectTransform handle, float maxDisplacement)
    {
        this.handle = handle;
        this.maxDisplacement = maxDisplacement;

        startPos = handle.position;
    }

    private void UpdateHandle(Vector2 position)
    {
        var delta = position - startPos;
        delta = Vector2.ClampMagnitude(delta, maxDisplacement);
        handle.position = startPos + delta;
        Horizontal = delta.x / maxDisplacement;
        Vertical = delta.y / maxDisplacement;
    }

    public void Dragging(Vector2 position)
    {
        UpdateHandle(position);
    }
    public void PointerDown(Vector2 position)
    {
        startPos = handle.position;
        UpdateHandle(position);
    }

    public void PointerUp()
    {
        UpdateHandle(startPos);
    }

}
