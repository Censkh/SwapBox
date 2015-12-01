using UnityEngine;

public class GameController : MonoBehaviour {


	public static GameController Instance { get; private set; }
    
    public ColorManager CurrentColorManager { get; private set; }
    public int CurrentScore { get; private set; }

    void Awake()
    {
        Instance = this;
        CurrentColorManager = new ColorManager();
        CurrentColorManager.AddRandomColor();
        CurrentColorManager.AddRandomColor();
    }

    public GameObject CreateCatchZone(Color color)
    {
        var catchZoneObj = Instantiate(Resources.Load<GameObject>("CatchZone_P"));
        var catchZoneController = catchZoneObj.GetComponent<CatchZoneController>();
        catchZoneController.SetColor(color);
        catchZoneController.SwapPosition();
        return catchZoneObj;
    }

    public void Score()
    {
        CurrentScore++;
        FindObjectOfType<TextMesh>().text = CurrentScore + "";
        CounterController.Instance.ForceSpawn();
    }

    public GameObject CreateBox(Color color)
    {
        var boxObj = Instantiate(Resources.Load<GameObject>("Box_P"));
        var boxController = boxObj.GetComponent<BoxController>();
        boxController.SetColor(color);
        boxController.SwapPosition();
        return boxObj;
    }

    public void GameOver()
    {
        var textMesh = FindObjectOfType<TextMesh>();
        textMesh.text = "Game Over";
        textMesh.fontSize = (int)(textMesh.fontSize * 0.8f);
    }

}
