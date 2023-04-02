using TMPro;
using UnityEngine;

public class GameManger : Singleton<GameManger>
{
    public GameObject Woods;
    public GameObject Town;
    public GameObject Home;
    public GameObject ResourcesPrefab;
    public Transform ResourcesParent;
    public TMP_Text TimeText;
    public GameObject Timer;
    public GameObject PassButton;
    public Vendor[] Vendors;
    private enum Scene { NULL = 0, Woods = 1, Home = 2, Town = 3}
    private Scene currentScene = 0;
    public void ChangeScene()
    {
        CharacterControler.Instance.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        if(currentScene == Scene.Woods)
        {
            Woods.SetActive(false);
            Destroy(ResourcesParent.GetChild(0).gameObject);
            Timer.SetActive(false);
            PassButton.SetActive(true);
        }
        else if(currentScene == Scene.Home)
        {
            Home.SetActive(false);
        }
        else if (currentScene == Scene.Town)
        {
            Town.SetActive(false);
        }
        //
        if (currentScene == Scene.Woods)
        {
            currentScene = Scene.Home;
            Home.SetActive(true);
        }
        else if (currentScene == Scene.Home)
        {
            currentScene = Scene.Town;
            foreach (Vendor v in Vendors)
                v.SetItem();
            Town.SetActive(true);
        }
        else
        {
            PassButton.SetActive(false);
            Timer.SetActive(true);
            currentScene = Scene.Woods;
            Instantiate(ResourcesPrefab, ResourcesParent);
            time = 60f;
            Woods.SetActive(true);
        }
    }
    public void Start()
    {
        ChangeScene();
    }
    private float time;
    private void Update()
    {
        if(currentScene == Scene.Woods)
        {
            if (time<=0)
                ChangeScene();
            else
            {
                time -= Time.deltaTime;
                TimeText.text = Mathf.FloorToInt(time / 60) + ":" + Mathf.FloorToInt(time - time / 60);
            }
        }
    }
    public GameObject End;
    public void Win()
    {
        End.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}