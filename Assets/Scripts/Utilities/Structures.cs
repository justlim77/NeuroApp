using UnityEngine;
using System.Collections;

namespace NeuroApp
{
    public static class Constants
    {
        public static float const_tapper_delay = 0.1f;
        public static float const_pin_reaction_delay = 0.25f;
        public static float const_power_reaction_delay = 0.5f;
        public static float const_absent_delay = 0.5f;
        public static float const_tap_active_radius = 25.0f;
        public static float const_pin_active_radius = 50.0f;
        public static float const_alpha_fade_duration = 0.1f;

        public static Color const_background_color = new Color32(13, 65, 89, 255);
        public static Color const_normal_color = new Color32(251, 221, 97, 255);
        public static Color const_areflexia_color = new Color32(36, 36, 36, 255);
        public static Color const_hyperreflexia_color = new Color32(251, 97, 97, 255);
        public static Color const_tool_used_color = new Color32(65, 255, 84, 255);

        public static string const_hyper_msg = "Ouch!";
        public static string const_norm_msg = "Ow!";
        public static string const_hypo_msg = "Hmm.";
        public static string const_absent_msg = "...";
        public static string const_mouth_open_msg = "Ahhh!";

        public static float const_default_delta = 1.0f;
        public static float const_zoom_delta = 6.0f;

        public static float const_default_pupil_normal = 8.0f;
        public static float const_default_pupil_dilation = 9.0f;
        public static float const_default_pupil_constrict = 3.0f;
        public static float const_default_pupil_half = 5.0f;
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

    public enum ColorType
    {
        Background,
        NoReaction,
        Reaction
    }

    public enum TestType
    {
        Single,
        Multiple
    }
    public enum Tone
    {
        Normal,
        Abnormal
    }
    public enum Answer
    {
        A = 0,
        B = 1,
        C = 2,
        D = 3,
        E = 4
    }
}