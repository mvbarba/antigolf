using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    //Tags
    public const string TAG_HOLE = "Hole";
    public const string TAG_BUTTON = "Button";
    public const string TAG_TRANS = "Trans";

    //Triggers
    public const string ANIM_OPEN = "Open";
    public const string ANIM_CLOSE = "Close";

    //Sounds
    public const string SOUND_HIT = "hit";
    public const string SOUND_HOLE = "hole";
    public const string SOUND_SONG = "song";
    public const string SOUND_PUT = "put";
    public const string SOUND_SELECT = "select";
    public const string SOUND_BUTTON = "button";

    public enum Levels
    {
        Menu,
        Level1,
        Level2
    }
}
