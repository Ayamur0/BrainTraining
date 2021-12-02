using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SnapDragController : MonoBehaviour {
    public class Tile {
        public Image image;
        public Vector2 basePos;
        public int occupiedLocationIndex = -1;

        public Tile(Image i) {
            image = i;
            basePos = new Vector2(image.transform.position.x, image.transform.position.y);
        }
    }
    private class Location {
        public Vector2 position;
        public bool occupied;

        public Location(Vector2 p) {
            position = p;
        }
    }
    public Image[] tileImages;
    public Tile[] tiles;
    public Vector2[] locations;
    private List<Location> possibleLocations = new List<Location>();
    private int dragging = -1;
    private Vector2 areaMin;
    private Vector2 areaMax;

    void Start() {
        foreach (Vector2 v in locations)
            possibleLocations.Add(new Location(v));
        tiles = new Tile[tileImages.Length];
        for (int i = 0; i < tileImages.Length; i++)
            tiles[i] = new Tile(tileImages[i]);
        Rect rect = GetComponent<RectTransform>().rect;
        areaMin = transform.TransformPoint(new Vector2(rect.xMin, rect.yMin));
        areaMax = transform.TransformPoint(new Vector2(rect.xMax, rect.yMax));
    }

    void Update() {
        if (dragging == -1)
            return;
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        if (x < areaMax.x && x > areaMin.x && y > areaMin.y && y < areaMax.y)
            tiles[dragging].image.transform.position = new Vector2(x, y);
    }

    public void OnPointerDown(int tile) {
        dragging = tile;
        if (tiles[dragging].occupiedLocationIndex != -1)
            possibleLocations[tiles[dragging].occupiedLocationIndex].occupied = false;
        tiles[dragging].occupiedLocationIndex = -1;
    }

    public void OnPointerUp() {
        // need to reset dragging first, else Update will set position while this function is executed
        int lastDrag = dragging;
        dragging = -1;
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

        if (!(x < areaMax.x && x > areaMin.x && y > areaMin.y && y < areaMax.y)) {
            tiles[lastDrag].image.transform.position = tiles[lastDrag].basePos;
        } else {
            bool locationFound = false;
            foreach (Location l in possibleLocations) {
                if (!l.occupied && Vector2.Distance(l.position, transform.InverseTransformPoint(Input.mousePosition)) < 25) {
                    tiles[lastDrag].image.transform.position = transform.TransformPoint(l.position);
                    tiles[lastDrag].occupiedLocationIndex = possibleLocations.IndexOf(l);
                    l.occupied = true;
                    locationFound = true;
                    break;
                }
            }
            if (!locationFound)
                tiles[lastDrag].image.transform.position = tiles[lastDrag].basePos;
        }
    }
}
