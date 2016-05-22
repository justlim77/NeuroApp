using UnityEngine;
using System.Collections;

namespace NeuroApp
{
    public static class Constants
    {
        public static float const_tapper_delay = 0.1f;
        public static float const_reaction_delay = 1.0f;
        public static float const_absent_delay = 1.0f;
        public static float const_tap_active_radius = 25.0f;
        public static Color const_tap_reaction_color = new Color32(251, 221, 97, 255);
        public static Color const_tap_no_reaction_color = new Color32(36, 36, 36, 255);
        public static string const_tap_hyper_msg = "Ouch!";
        public static string const_tap_norm_msg = "Ow!";
        public static string const_tap_hypo_msg = "Hmm.";
        public static string const_tap_absent_msg = "...";
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
    public enum State
    {
        Normal,
        Abnormal
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