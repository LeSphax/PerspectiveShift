﻿

class Paths
{
    public static char FOLDER_SEPARATOR_CHAR
    {
        get
        {
            return FOLDER_SEPARATOR[0];
        }
    }
    public const string FOLDER_SEPARATOR = "/";
    public const string PARTICLES = "Prefabs" + FOLDER_SEPARATOR + "Particles" + FOLDER_SEPARATOR;
    public const string FAIRY_DUST = PARTICLES + "FairyDust";
    public const string BRICK_SMOKE = PARTICLES + "BrickSmoke";
    private const string MECHANICS = "Prefabs" + FOLDER_SEPARATOR + "Mechanics" + FOLDER_SEPARATOR;
    public const string TILE = MECHANICS + "Tile";
    public const string NO_OBJECTIVE_BALL = MECHANICS + "BallO0";
    public const string WALL = MECHANICS + "Wall";
    public const string OBJECTIVE1_BALL = MECHANICS + "BallO1";
    public const string OBJECTIVE2_BALL = MECHANICS + "BallO2";
    public const string OBJECTIVE1_TILE = MECHANICS + "TileO1";
    public const string OBJECTIVE2_TILE = MECHANICS + "TileO2";
    public const string LEVEL_FILES = "LevelFiles" + FOLDER_SEPARATOR;
    public const string RESOURCES = "Resources" + FOLDER_SEPARATOR;


    public const string DIR_3D = "3D" + FOLDER_SEPARATOR;
    public const string DIR_2D = "2D" + FOLDER_SEPARATOR;
    public const string SCREEN_FADER = "Prefabs" + FOLDER_SEPARATOR + "ScreenFader";
}
