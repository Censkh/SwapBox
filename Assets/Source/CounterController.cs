using UnityEngine;

public class CounterController : MonoBehaviour {

    public const float BoxCreationDelay = 8f;

    public static CounterController Instance { get; private set; }

    private Color nextColor;
    float boxTimer = 0f;
    GameObject fillObject;
    Vector3 fillStartScale;

    void Awake()
    {
        Instance = this;
        fillObject = transform.GetChild(0).gameObject;
    }

    void Start()
    {
        fillStartScale = fillObject.transform.localScale;
        SetNextColor();
        CreateBox();
    }

    void Update()
    {
        boxTimer += Time.deltaTime;
        if (boxTimer > BoxCreationDelay)
        {
            boxTimer = 0;
            CreateBox();
        }
        var value = (boxTimer / BoxCreationDelay) * fillStartScale.x;
        fillObject.transform.localScale = Vector3.Lerp(fillObject.transform.localScale, new Vector3(value,value, fillStartScale.z),5f*Time.deltaTime);
        var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = Color.Lerp(meshRenderer.material.color,nextColor,3f*Time.deltaTime);
        var fillMeshRenderer = fillObject.GetComponent<MeshRenderer>();
        fillMeshRenderer.material.color = Color.Lerp(fillMeshRenderer.material.color, nextColor + (Color.white*0.2f), 3f * Time.deltaTime);
    }

    public void ForceSpawn()
    {
        boxTimer = BoxCreationDelay + 0.01f;
    }

    public void SetNextColor()
    {
        nextColor = GameController.Instance.CurrentColorManager.GetRandomColor();
    }

    public void CreateBox()
    {
        GameController.Instance.CreateBox(nextColor);
        SetNextColor();
    }

}
