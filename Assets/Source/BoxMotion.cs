using UnityEngine;

public class BoxMotion : MonoBehaviour
{

    static int currentId = -1;
    bool hasMouse = false;
    float timer;
    Vector3 startPos;

    void Update()
    {
        if (hasMouse&&Input.GetMouseButtonDown(0))
        {
            currentId = GetInstanceID();
            startPos = transform.position;
        }
        if (currentId==GetInstanceID())
        {
            timer += Time.deltaTime;
            if (!Input.GetMouseButton(0)||timer>0.2f)
            {
                var rigidbody = GetComponent<Rigidbody2D>();
                var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var force = (mousePos - startPos).normalized;
                force.z = 0;
                rigidbody.AddForceAtPosition(force * (Vector2.Distance(mousePos, startPos)) * -5f,mousePos, ForceMode2D.Impulse);
                currentId = -1;
                timer = 0f;
            }
        }
        
    }

    void OnMouseEnter()
    {

        if (currentId==-1)
        hasMouse = true;
    }

    void OnMouseExit()
    {
        if (hasMouse)
        {
            hasMouse = false;
        }
    }

}