using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public Texture2D cursorTexture;

    [SerializeField] private GameObject LeftTower;
    [SerializeField] private GameObject MiddleTower;
    [SerializeField] private GameObject RightTower;


    //Changing texture of mouse cursor
    void Start()
    {
        //Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);    //Changing cursor texture to crosshair
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            LaunchOnKey(LeftTower);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            LaunchOnKey(MiddleTower);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            LaunchOnKey(RightTower);
        }
    }

    private void LaunchOnKey(GameObject tower)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Assign mouse position for later use
        if (mousePos.y < -3)
            mousePos.y = -3;

        Vector2 startingPos = tower.GetComponent<Tower>().TowerPosition();
        if (startingPos != new Vector2(-10, -10))
        {
            MissileSpawnPool.Instance.LaunchMissile(startingPos, mousePos, 0.5f, "Player"); //Spawn missile
        }
    }
}
