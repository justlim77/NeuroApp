using UnityEngine;
using System.Collections;

namespace NeuroApp
{
    public static class Constants
    {
        public static float const_tapper_delay = 0.1f;
        public static float const_reaction_delay = 1f;
    }

    public enum Orientation
    {
        Left,
        Right
    }

    public enum SwingDirection
    {
        Up,
        Down
    }

    public enum ToolSwingDirection
    {
        Up,
        Down
    }

    public enum PupilState
    {
        Default,
        Dilated,
        Constricted
    }

    public enum FaceState
    {
        Smile,
        Shocked,
        OMG,
        Ouch,
        Neutral,
        NoReaction,
        RightEyebrowUp,
        LeftEyebrowUp,
        BothEyebrowsUp,
        RightSquint,
        LeftSquint,
        BothSquint,
        RightGritTeeth,
        LeftGritTeeth,
        BothGritTeeth
    }

    public enum MouthState
    {
        Smile,
        Shocked,
        OMG,
        Ouch,
        Neutral
    }

    public enum PanelType
    {
        Main
    }
}