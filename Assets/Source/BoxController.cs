using UnityEngine;
using System.Collections;

public class BoxController : MonoBehaviour
{

    public static int CurrentlySelectedBox = -1;
    public Color CurrentColor { get; private set; }

    void Start()
    {
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)));
    }

    public void SetColor(Color color)
    {
        var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = CurrentColor = color;
    }

    public void SwapPosition()
    {
        transform.position = new Vector3(Random.Range(-3f, 3f), 8.5f);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        var catchZoneController = collider.GetComponent<CatchZoneController>();
        if (catchZoneController != null)
        {
            if (catchZoneController.CurrentColor.Equals(CurrentColor))
            {
                GameController.Instance.Score();
            } else
            {
                GameController.Instance.GameOver();
            }
            CurrentlySelectedBox = -1;
            Destroy(gameObject);
        }
        if (collider.GetComponent<KillZoneController>()!=null)
        {
            GameController.Instance.GameOver();
            CurrentlySelectedBox = -1;
            Destroy(gameObject);
        }
    }

}
