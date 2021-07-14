using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public SpriteRenderer Main, Leaderboard, Settings, Another, Minigames;
    private float ScreenWidth;
    // Start is called before the first frame update
    void Start()
    {
        MenuSetup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuSetup()
    {
        float halfHeight = Camera.main.orthographicSize;
        float aspect = Camera.main.aspect;
        ScreenWidth = halfHeight * 2 * aspect;

        Main.transform.position = new Vector2(0, 0);
        Minigames.transform.position = new Vector2(ScreenWidth, 0);
        Leaderboard.transform.position = new Vector2(ScreenWidth * 2, 0);
        Another.transform.position = new Vector2(-ScreenWidth, 0);
        Settings.transform.position = new Vector2(-ScreenWidth * 2, 0);

        float y = halfHeight * 2;
        float x = aspect * y;

        Vector2 screenScale = new Vector2(x, y);
        Main.transform.localScale = screenScale;
        Minigames.transform.localScale = screenScale;
        Leaderboard.transform.localScale = screenScale;
        Another.transform.localScale = screenScale;
        Settings.transform.localScale = screenScale;
    }

    int screenIndex = 0;
    int screenIndexMin = -2;
    int screenIndexMax = 2;

    public void LeftButton()
    {
        screenIndex = Mathf.Clamp(screenIndex - 1, screenIndexMin, screenIndexMax);
        SetScreen();
    }

    public void RightButton()
    {
        screenIndex = Mathf.Clamp(screenIndex + 1, screenIndexMin, screenIndexMax);
        SetScreen();
    }

    public void SetScreen()
    {
        Camera.main.transform.position = new Vector3(screenIndex * ScreenWidth, 0, -10);
    }
}
