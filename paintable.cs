using UnityEngine;
using UnityEditor;
public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject agreeText;
    public GameObject[] drawingScreen;
    public GameObject enemyHead;
    public static GameManager instance = null;
    public Sprite sprHead;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }       
        else if (instance != this)
        {
            Destroy(gameObject);  
        } 
    }
    void Start()
    {
        titleScreen.SetActive(true);
        agreeText.SetActive(false);
        foreach(GameObject go in drawingScreen)
        {
            go.SetActive(false);
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && titleScreen.activeSelf == true)
        {
            titleScreen.SetActive(false);
            agreeText.SetActive(true);
        }
    }

    public void Agree()
    {
        agreeText.SetActive(false);
        foreach(GameObject go in drawingScreen)
        {
            go.SetActive(true);
        }
    }

    public void LoadNewSprite() 
    {
        string assetPath = AssetDatabase.GetAssetPath(enemyHead);
        GameObject contentsRoot = PrefabUtility.LoadPrefabContents(assetPath);
        SpriteRenderer sprRnd = contentsRoot.GetComponent<SpriteRenderer>();

        string path = Application.dataPath + "Assets/Resources/savedImage.png";
        sprRnd.sprite = sprHead;
        AssetDatabase.Refresh();
        PrefabUtility.SaveAsPrefabAsset(contentsRoot, assetPath);
        PrefabUtility.UnloadPrefabContents(contentsRoot);
    }

}
