using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    //Tags
    public const string TAG_HOLE = "Hole";

    //Triggers
    public const string ANIM_OPEN = "Open";
    public const string ANIM_CLOSE = "Close";

    //Sounds
    public const string SOUND_HIT = "hit";
    public const string SOUND_HOLE = "hole";
    public const string SOUND_SONG = "song";

    public enum Levels
    {
        Menu,
        Level1,
        Level2
    }
}
