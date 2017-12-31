using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour {
    public enum TileType { GROUND, WALL, ENTRY, EXIT };
    private enum Direction { NORTH, EAST, SOUTH, WEST };

    #region inspectorVars
    [SerializeField]
    private Transform dungeonGroundPrefab;
    [SerializeField]
    private Transform dungeonWallPrefab;
    [SerializeField]
    private Transform playerPrefab;
    [SerializeField]
    private int dungeonLength;
    [SerializeField]
    private int dungeonHeight;
    [SerializeField]
    private int numberOfPathsInEachDirection;
    [SerializeField]
    private int dungeonHallSize;
    #endregion

    public static int length, height, paths, hallSize;  // hallSize is the scale of each tile
    public static Transform ground, wall, player;
    public static TileType[,] dungeon;
    private static GameObject dungeonHolder;

    #region inspectorVarsToStaticVars
    private void Awake() {
        ground = dungeonGroundPrefab;
        wall = dungeonWallPrefab;
        player = playerPrefab;
        length = dungeonLength;
        height = dungeonHeight;
        paths = numberOfPathsInEachDirection;
        hallSize = dungeonHallSize;
    }
    #endregion

    private void Start() {
        GenerateDungeon();
    }

    private static void CreateGround(Vector2 pos, Vector2 size) {
        Transform g = Instantiate(ground, pos * hallSize, Quaternion.identity, dungeonHolder.transform);
        g.GetComponent<SpriteRenderer>().size = size * hallSize;
    }
    private static void CreateWall(Vector2 pos) {
        Transform w = Instantiate(wall, pos, Quaternion.identity, dungeonHolder.transform);
        w.localScale = new Vector2(hallSize, hallSize);
    }
    private static void CreatePlayer(Vector2 pos) {
        Camera.main.GetComponent<CameraFollow>().target = Instantiate(player, pos, Quaternion.identity, dungeonHolder.transform);
    }

    private static void CreateDungeon() {
        dungeonHolder = new GameObject("Dungeon");
        CompositeCollider2D dungeonComCol = dungeonHolder.AddComponent<CompositeCollider2D>();
        dungeonComCol.geometryType = CompositeCollider2D.GeometryType.Polygons;
        Rigidbody2D dungeonRb = dungeonHolder.GetComponent<Rigidbody2D>();
        dungeonRb.bodyType = RigidbodyType2D.Static;
        Vector2 pos = Vector2.zero;
        CreateGround(new Vector2(pos.x + (length / 2f) - 0.5f, pos.y + (height / 2f) - 0.5f), new Vector2(length, height));
        for (int h = 0; h < height; h++) {
            for (int i = 0; i < length; i++) {
                TileType tile = dungeon[i, h];
                if (tile == TileType.WALL) {
                    CreateWall(pos);
                } else if (tile == TileType.ENTRY) {
                    CreatePlayer(pos);
                    // Create Entry Point of Dungeon which can be used to exit
                } else if (tile == TileType.EXIT) {
                    // Create Exit to new world location
                }
                pos.x += hallSize;
            }
            pos.x = 0f;
            pos.y += hallSize;
        }
        CreateDungeonBorder();
    }

    public static void DestroyDungeon() {
        Destroy(dungeonHolder);
    }

    public static void CreateDungeonBorder() {
        Vector2 pos = new Vector2(0f, -hallSize);
        // Create bottom and top border
        for (int h = 0; h < 2; h++) {
            for (int i = 0; i < length; i++) {
                CreateWall(pos);
                pos.x += hallSize;
            }
            pos.x = 0f;
            pos.y = height * hallSize;
        }
        // Create right and left border
        pos.x = -hallSize;
        pos.y = -hallSize;
        for (int i = 0; i < 2; i++) {
            for (int h = -2; h < height; h++) {
                CreateWall(pos);
                pos.y += hallSize;
            }
            pos.x = length * hallSize;
            pos.y = -hallSize;
        }
    }

    public static void GenerateDungeon() {
        dungeon = new TileType[length, height];
        // Set all tiles to Wall, to break them after which will make the paths
        for (int h = 0; h < height; h++) {
            for (int i = 0; i < length; i++) {
                dungeon[i, h] = TileType.WALL;
            }
        }

        // Entry Point (Player will spawn)
        Vector2Int mapPos = new Vector2Int(Random.Range(0, length), Random.Range(0, height));
        dungeon[mapPos.x, mapPos.y] = TileType.ENTRY;

        // Loops for number of paths that needed to be created
        for (int p = 0; p < paths; p++) {
            // List of all possible directions the path can go, will remove direction if path cannot be created that way
            List<Direction> possibleDirections = new List<Direction>(new Direction[] { Direction.NORTH, Direction.EAST, Direction.SOUTH, Direction.WEST });
            // Breaks out of while loop once a path is created
            do {
                Direction dir = possibleDirections[Random.Range(0, possibleDirections.Count)];
                if (GeneratePath(dir, ref mapPos, ref possibleDirections)) {
                    break;
                } else if (possibleDirections.Count == 0) {
                    break;
                }
            } while (true);
        }

        CreateDungeon();
    }

    private static bool GeneratePath(Direction dir, ref Vector2Int pos, ref List<Direction> possibleDirections) {
        if (dir == Direction.NORTH) {
            try {
                if (dungeon[pos.x, pos.y + 1] == TileType.WALL) {
                    pos.y++;
                    dungeon[pos.x, pos.y] = TileType.GROUND;
                    return (true);
                } else {
                    possibleDirections.Remove(dir);
                }
            } catch (System.IndexOutOfRangeException) {
                possibleDirections.Remove(dir);
            }
        } else if (dir == Direction.EAST) {
            try {
                if (dungeon[pos.x + 1, pos.y] == TileType.WALL) {
                    pos.x++;
                    dungeon[pos.x, pos.y] = TileType.GROUND;
                    return (true);
                } else {
                    possibleDirections.Remove(dir);
                }
            } catch (System.IndexOutOfRangeException) {
                possibleDirections.Remove(dir);
            }
        } else if (dir == Direction.SOUTH) {
            try {
                if (dungeon[pos.x, pos.y - 1] == TileType.WALL) {
                    pos.y--;
                    dungeon[pos.x, pos.y] = TileType.GROUND;
                    return (true);
                } else {
                    possibleDirections.Remove(dir);
                }
            } catch (System.IndexOutOfRangeException) {
                possibleDirections.Remove(dir);
            }
        } else {
            try {
                if (dungeon[pos.x - 1, pos.y] == TileType.WALL) {
                    pos.x--;
                    dungeon[pos.x, pos.y] = TileType.GROUND;
                    return (true);
                } else {
                    possibleDirections.Remove(dir);
                }
            } catch (System.IndexOutOfRangeException) {
                possibleDirections.Remove(dir);
            }
        }
        return (false);
    }
}
