﻿using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // Cube is 10 * 10 * 10m in size;
    private const int GridSize = 10;

    public bool IsExplored = false;
    public Waypoint ExploredFrom = null;
    public bool IsPlaceable = true;

    private Color blueColor = Color.blue;
    private Color greyColor = Color.grey;

    [SerializeField] private Tower _towerPrefab;
    // [SerializeField] private Transform _towersContainer;

    public int GetGridSize() => GridSize;

    public Vector2Int GetGridPosition()
    {
        Vector2Int position = new Vector2Int(
            Mathf.RoundToInt(this.transform.position.x / GridSize),
            Mathf.RoundToInt(this.transform.position.z / GridSize)
        );
        return position;
    }

    public void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (this.IsPlaceable)
            {
                Instantiate(
                    this._towerPrefab,
                    this.transform.position,
                    Quaternion.identity
                );
                this.IsPlaceable = false;
                // this._towerPrefab.transform.parent = this._towersContainer;
            }
        }
    }
}
