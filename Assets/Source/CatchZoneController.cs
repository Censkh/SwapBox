using UnityEngine;

public class CatchZoneController : MonoBehaviour {

    public Color CurrentColor { get; private set; }

    public void SetColor(Color color)
    {
        var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = color;
        CurrentColor = color;
    }

    public void SwapPosition() {
        transform.localPosition = new Vector3(Random.Range(-2.8f, 2.8f), -5.65f);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<CatchZoneController>()!=null)
        {
            SwapPosition();
        }
    }

}
