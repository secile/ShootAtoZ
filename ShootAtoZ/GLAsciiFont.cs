using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShootAtoZ
{
    public static class GLAsciiFont
    {
        // ASCII font data with X, Y coordinate range of -1 to +1. This data expected to be used in OpenGL.
        // The data contains only the X and Y coordinates. (Z coordinates are not included)

        // space
        static float[] font_space = { };

        // !
        static float[] font_exclamation =
        {
            +0,+1,+0,-0.25f,
            +0,-0.75f,+0,-1,
        };

        // "
        static float[] font_quotes =
        {
            // short vertical lines
            -0.25f,+1,-0.25f,+0.5f,
            +0.25f,+1,+0.25f,+0.5f,
        };

        // #
        static float[] font_sharp =
        {
            // horizontal lines
            -1,+0.5f,+1,+0.5f,
            -1,-0.5f,+1,-0.5f,

            // vertical lines
            -0.5f,+1, -0.5f,-1,
            +0.5f,+1, +0.5f,-1,
        };

        // $
        static float[] font_dollar =
        {
            // little s
            +1,+0.75f,-1,+0.75f,
            -1,+0.75f,-1,+0f,
            -1,+0f,+1,+0f,
            +1,+0f,+1,-0.75f,
            +1,-0.75f,-1,-0.75f,

            // vertical line
            +0f,+1, +0f,-1,
        };

        // %
        static float[] font_percent =
        {
            // left upper o
            -1, +1, -0.25f, +1,
            -0.25f, +1,-0.25f,+0.25f,
            -0.25f,+0.25f,-1,+0.25f,
            -1,+0.25f,-1,+1,

            // right lower o
            +0.25f,-0.25f,+1,-0.25f,
            +1,-0.25f,+1,-1,
            +1,-1,+0.25f,-1,
            +0.25f,-1,+0.25f,-0.25f,

            // slash /
            +1,+1,-1,-1,

        };

        // &
        static float[] font_and =
        {
            // upper o
            -0.75f,+1,+0.25f,+1,
            +0.25f,+1,+0.25f,+0,
            +0.25f,+0,-0.75f,+0,
            -0.75f,+0,-0.75f,+1,

            // left leg
            -0.5f, 0, -1,-0.5f,
            -1,-0.5f,-1,-1,
            -1,-1,+0.25f,-1,
            +0.25f,-1,+1,-0.25f,

            // right leg
            0,0,+1,-1,
        };

        // '
        static float[] font_apostrophe =
        {
            // short vertical line
            0,+1,0,+0.5f,
        };

        // (
        static float[] font_parenthesis_start =
        {
            +0.25f,+1,-0.25f,+0.25f,
            -0.25f,+0.25f,-0.25f,-0.25f,
            -0.25f,-0.25f,+0.25f,-1,
        };

        // )
        static float[] font_parenthesis_end =
        {
            -0.25f,+1,+0.25f,+0.25f,
            +0.25f,+0.25f,+0.25f,-0.25f,
            +0.25f,-0.25f,-0.25f,-1,
        };

        // *
        static float[] font_asterisk =
        {
            // left upper to right down
            -0.75f,+0.50f,+0.75f,-0.50f,

            // right upper to left down
            +0.75f,+0.50f,-0.75f,-0.50f,

            // vertical
            +0,+0.75f,+0,-0.75f,
        };

        // +
        static float[] font_plus =
        {
            // vertical
            +0,+0.75f,+0,-0.75f,

            // horizontal
            -0.75f,+0,+0.75f,+0,
        };

        // ,
        static float[] font_comma =
        {
            // short vertical line
            +0.1f,-0.75f,-0.1f,-1,
        };

        // -
        static float[] font_minus =
        {
            // horizontal line
            -0.75f,+0,+0.75f,+0,
        };

        // .
        static float[] font_period =
        {
            // short vertical line
            0,-0.75f,0,-1,
        };

        // /
        static float[] font_slash =
        {
            // right upper to left down
            +0.5f,+1f,-0.5f,-1f,
        };


        static float[] font_0 =
        {
            -1,+1,-1,-1,
            -1,-1,+1,-1,
            +1,-1,+1,+1,
            +1,+1,-1,+1,
            -1,+1,+1,-1,
        };

        static float[] font_1 =
        {
            -0.5f,+1f,+0f,+1f,
            +0,+1,+0,-1,
            -0.5f,-1f,+0.5f,-1f
        };

        static float[] font_2 =
        {
            -1,+1,+1,+1,
            +1,+1,+1,+0,
            +1,+0,-1,+0,
            -1,+0,-1,-1,
            -1,-1,+1,-1,
        };

        static float[] font_3 =
        {
            -1,+1,+1,+1,
            +1,+1,+1,-1,
            +1,-1,-1,-1,
            -1,+0,+1,+0,
        };

        static float[] font_4 =
        {
            -1,+1,-1,+0,
            -1,+0,+1,+0,
            +1,+1,+1,-1,
        };

        static float[] font_5 =
        {
            +1,+1,-1,+1,
            -1,+1,-1,+0,
            -1,+0,+1,+0,
            +1,+0,+1,-1,
            +1,-1,-1,-1,
        };

        static float[] font_6 =
        {
            +1,+1,-1,+1,
            -1,+1,-1,-1,
            -1,-1,+1,-1,
            +1,-1,+1,+0,
            +1,+0,-1,+0,
        };

        static float[] font_7 =
        {
            -1,+0,-1,+1,
            -1,+1,+1,+1,
            +1,+1,+1,-1,
        };

        static float[] font_8 =
        {
            -1,+1,-1,-1,
            -1,-1,+1,-1,
            +1,-1,+1,+1,
            +1,+1,-1,+1,
            -1,+0,+1,+0,
        };

        static float[] font_9 =
        {
            +1,+0,-1,+0,
            -1,+0,-1,+1,
            -1,+1,+1,+1,
            +1,+1,+1,-1,
            +1,-1,-1,-1,
        };

        // :
        static float[] font_collon =
        {
            // upper vertical line
            0,+0.75f,0,+0.5f,

            // lower vertical line
            0,-0.5f,0,-0.8f,
        };

        // ;
        static float[] font_semicollon =
        {
            // upper vertical line
            0,+0.75f,0,+0.5f,

            // lower vertical line
            0,-0.5f,0,-0.8f,
            0,-0.8f,-0.1f, -0.9f,
        };

        // <
        static float[] font_lessthan =
        {
            +0.75f,+0.5f,-0.75f,+0.0f,
            -0.75f,+0.0f,+0.75f,-0.5f,
        };

        // =
        static float[] font_equal =
        {
            -0.75f,+0.25f,+0.75f,+0.25f,
            -0.75f,-0.25f,+0.75f,-0.25f,
        };

        // >
        static float[] font_overthan =
        {
            -0.75f,+0.5f,+0.75f,+0.0f,
            +0.75f,+0.0f,-0.75f,-0.5f,
        };

        // ?
        static float[] font_question =
        {
            // upper circle
            -0.5f,+0,-0.75f,+0.25f,
            -0.75f,+0.25f,-0.75f,+0.5f,
            -0.75f,+0.5f,-0.5f,+0.75f,
            -0.5f,+0.75f,+0.5f,+0.75f,
            +0.5f,+0.75f,+0.75f,+0.5f,
            +0.75f,+0.5f,+0.75f,+0.25f,
            +0.75f,+0.25f,+0.5f,+0f,
            +0.5f,+0f,+0,+0,

            // vertical
            +0,+0,+0,-0.4f,

            // lower dot.
            +0,-0.75f,+0,-1f,
        };

        // @
        static float[] font_atmark =
        {
            // start from right bottom.
            +1,-1,-0.5f,-1,            // ←
            -0.5f,-1,-0.75f,-0.5f,
            -0.75f,-0.5f,-0.75f,+0.5f, // ↑
            -0.75f,+0.5f,-0.5f,+1,
            -0.5f,+1,+0.5f,+1,         // →
            +0.5f,+1,+0.75f,+0.5f,
            +0.75f,+0.5f,+0.75f,-0.5f, // ↓
            +0.75f,-0.5f,-0.3f,-0.5f,  // ←
            -0.3f,-0.5f,-0.3f,+0.3f,   // ↑
            -0.3f,+0.3f,+0.3f,+0.3f,   // →
            +0.3f,+0.3f,+0.3f,-0.5f,   // ↓
        };
        
        static float[] font_A =
        {
            -1,-1,-1,+0,
            -1,+0,+0,+1,
            +0,+1,+1,+0,
            +1,+0,+1,-1,
            -1,+0,+1,+0,
        };

        static float[] font_B =
        {
            -1,+1,+0.25f,+1,
            +0.25f,+1,+1,+0.75f,
            +1,0.75f,+1,0.25f,
            +1,0.25f,0.25f,0,
            0.25f,0,1,-0.25f,
            1,-0.25f,1,-0.75f,
            1,-0.75f,+0.25f,-1,
            +0.25f,-1,-1,-1,
            -1,-1,-1,+1,
            -1,+0,+0.25f,0,
        };

        static float[] font_C =
        {
            +1,+1,-1,+1,
            -1,+1,-1,-1,
            -1,-1,+1,-1,
        };

        static float[] font_D =
        {
            -1,+1,+0,+1,
            +0,+1,+1,+0.5f,
            +1,+0.5f,+1,-0.5f,
            +1,-0.5f,+0,-1,
            +0,-1,-1,-1,
            -1,-1,-1,+1,
        };

        static float[] font_E =
        {
            +1,+1,-1,+1,
            -1,+1,-1,-1,
            -1,-1,+1,-1,
            -1,+0,+1,+0,
        };

        static float[] font_F =
        {
            +1,+1,-1,+1,
            -1,+1,-1,-1,
            -1,+0,+1,+0,
        };

        static float[] font_G =
        {
            +1,+1,-1,+1,
            -1,+1,-1,-1,
            -1,-1,+1,-1,
            +1,-1,+1,+0,
            +1,+0,+0,+0,
        };

        static float[] font_H =
        {
            -1,+1,-1,-1,
            -1,+0,+1,+0,
            +1,+1,+1,-1,
        };

        static float[] font_I =
        {
            -0.5f,+1f,+0.5f,+1f,
            +0,+1,+0,-1,
            -0.5f,-1f,+0.5f,-1f,
        };

        static float[] font_J =
        {
            +0,1,+1,+1,
            +0.5f,+1,0.5f,-1,
            +0.5f,-1,-1,-1,
            -1,-1,-1,+0,
        };

        static float[] font_K =
        {
            -1,+1,-1,-1,
            +1,+1,-1,+0,
            -1,+0,+1,-1,
        };

        static float[] font_L =
        {
            -1,+1,-1,-1,
            -1,-1,+1,-1,
        };

        static float[] font_M =
        {
            -1,-1,-1,+1,
            -1,+1,+0,+0,
            +0,+0,+1,+1,
            +1,+1,+1,-1,
        };

        static float[] font_N =
        {
            -1,-1,-1,+1,
            -1,+1,+1,-1,
            +1,-1,+1,+1,
        };

        static float[] font_O =
        {
            -1,+1,-1,-1,
            -1,-1,+1,-1,
            +1,-1,+1,+1,
            +1,+1,-1,+1,
        };

        static float[] font_P =
        {
            -1,-1,-1,+1,
            -1,+1,+1,+1,
            +1,+1,+1,+0,
            +1,+0,-1,+0,
        };

        static float[] font_Q =
        {
            -1,+1,-1,-1,
            -1,-1,+1,-1,
            +1,-1,+1,+1,
            +1,+1,-1,+1,
            +0,+0,+1,-1,
        };

        static float[] font_R =
        {
            -1,-1,-1,+1,
            -1,+1,+1,+1,
            +1,+1,+1,+0,
            +1,+0,-1,+0,
            +0,+0,+1,-1,
        };

        static float[] font_S =
        {
            +1,+0.75f,+1,+1,
            +1,+1,-1,+1,
            -1,+1,-1,+0,
            -1,+0,+1,+0,
            +1,+0,+1,-1,
            +1,-1,-1,-1,
            -1,-1,-1,-0.75f,
        };

        static float[] font_T =
        {
            -1,+1,+1,+1,
            +0,+1,+0,-1,
        };

        static float[] font_U =
        {
            -1,+1,-1,-1,
            -1,-1,+1,-1,
            +1,-1,+1,+1,
        };

        static float[] font_V =
        {
            -1,+1,+0,-1,
            +0,-1,+1,+1,
        };

        static float[] font_W =
        {
            -1,+1,-0.5f,-1f,
            -0.5f,-1f,+0,1f,
            +0,+1,+0.5f,-1f,
            +0.5f,-1f,+1,+1,
        };

        static float[] font_X =
        {
            -1,+1,+1,-1,
            +1,+1,-1,-1,
        };

        static float[] font_Y =
        {
            -1,+1,+0,+0,
            +1,+1,+0,+0,
            +0,+0,+0,-1,
        };

        static float[] font_Z =
        {
            -1,+1,+1,+1,
            +1,+1,-1,-1,
            -1,-1,+1,-1,
        };

        static float[] font_a =
        {
            -1, +0.15f, +0.5f, +0.15f,
            +0.5f, +0.15f, +0.5f, -0.35f,

            // o
            -1,-0.35f,+0.5f,-0.35f,
            +0.5f,-0.35f,+0.5f,-1,
            +0.5f,-1,-1,-1,
            -1,-1,-1,-0.35f,
            // right hand
            +0.5f,-0.5f,+1,-1,
        };

        static float[] font_b =
        {
            -1,+0.75f,-1,-1,
            -1,-1,+1,-1,
            +1,-1,+1,0,
            +1,0,-1,0,
        };


        static float[] font_c =
        {
            +1,0,-1,0,
            -1,0,-1,-1,
            -1,-1,+1,-1,
        };

        static float[] font_d =
        {
            +1,+0.75f,+1,-1,
            +1,-1,-1,-1,
            -1,-1,-1,+0,
            -1,+0,+1,+0,
        };

        static float[] font_e =
        {
            -1,-0.45f,+1,-0.45f,
            +1,-0.45f,+1,+0.1f,
            +1,+0.1f,-1,+0.1f,
            -1,+0.1f,-1,-1,
            -1,-1,+1,-1,
        };

        static float[] font_f =
        {
            +0.75f,+0.5f,+0,+0.5f,
            +0,+0.5f,+0,-1,
            -0.75f,-0.1f,+0.75f,-0.1f,
        };

        static float[] font_g =
        {
            +1,-0.45f,-1,-0.45f,
            -1,-0.45f,-1,+0.1f,
            -1,+0.1f,+1,+0.1f,
            +1,+0.1f,+1,-1,
            +1,-1,-1,-1,
            -1,-1,-1,-0.75f,
        };

        static float[] font_h =
        {
            -1,+0.5f,-1,-1,
            -1,0,+1,0,
            +1,0,+1,-1,
        };

        static float[] font_i =
        {
            0,0.5f,0,0.3f,
            0,0,0,-1,
        };

        static float[] font_j =
        {
            0.75f,0.5f,0.75f,0.3f,
            0.75f,0,0.75f,-1,
            0.75f,-1,-0.75f,-1,
            -0.75f,-1,-0.75f,-0.5f,
        };

        static float[] font_k =
        {
            -1,+1,-1,-1,
            +1,+0f,-1,-0.4f,
            -1,-0.4f,+1,-1,
        };

        static float[] font_l =
        {
            -0.5f,+0.5f,0,+0.5f,
            0,+0.5f,0,-1,
            0,-1,+0.5f,-1,
        };

        static float[] font_m =
        {
            -1,-1,-1,0,
            -1,0,1,0,
            1,0,1, -1,
            0,0,0,-1,
        };

        static float[] font_n =
        {
            -1,-1,-1,0,
            -1,-0.5f,-0.5f,0,
            -0.5f,0,1,0,
            1,0,1,-1,
        };

        static float[] font_o =
        {
            -1,0,+1,0,
            +1,0,+1,-1,
            +1,-1,-1,-1,
            -1,-1,-1,0,
        };

        static float[] font_p =
        {
            -1,-1,-1,+0f,
            -1,+0f,+1,+0f,
            +1,+0f,+1,-0.55f,
            +1,-0.55f,-1,-0.55f,
        };

        static float[] font_q =
        {
            +1,-1,+1,+0f,
            +1,+0f,-1,+0f,
            -1,+0f,-1,-0.55f,
            -1,-0.55f,+1,-0.55f,
        };

        static float[] font_r =
        {
            -1,0,-0.5f, 0,
            -0.5f,0,-0.5f,-1,
            -0.5f,-0.5f,+0.5f,0,
            +0.5f,0,+1,0,
        };

        static float[] font_s =
        {
            +1,0,-1,0,
            -1,0,-1,-0.5f,
            -1,-0.5f,+1,-0.5f,
            +1,-0.5f,+1,-1,
            +1,-1,-1,-1,
        };

        static float[] font_t =
        {
            -0.75f,0,+0.5f,0,
            -0.25f,+0.5f,-0.25f,-1,
            -0.25f,-1,+0.5f,-1,
        };

        static float[] font_u =
        {
            -1,0,-1,-1,
            -1,-1,+0.5f,-1,
            +0.5f,-1,+1,-0.5f,
            +1,-1,+1,0,
        };

        static float[] font_v =
        {
            -1,0,0,-1,
            0,-1,+1,0,
        };

        static float[] font_w =
        {
            -1,0,-0.5f,-1,
            -0.5f,-1,0,0,
            0,0,+0.5f,-1,
            +0.5f,-1,+1,0,
        };

        static float[] font_x =
        {
            -1,0,+1,-1,
            +1,0,-1,-1,
        };

        static float[] font_y =
        {
            -1,0,0,-0.5f,
            +1,0,0,-0.5f,
            0,-0.5f,0,-1,
        };

        static float[] font_z =
        {
            -1,0,+1,0,
            +1,0,-1,-1,
            -1,-1,+1,-1,
        };

        // [
        static float[] font_bracket_start =
        {
            +0.25f,+1,-0.25f,+1,
            -0.25f,+1,-0.25f,-1,
            -0.25f,-1,+0.25f,-1,
        };

        // \
        static float[] font_backslash =
        {
            // left upper to right down
            -0.5f,+1,+0.5f,-1,
        };

        // ]
        static float[] font_bracket_end =
        {
            -0.25f,+1,+0.25f,+1,
            +0.25f,+1,+0.25f,-1,
            +0.25f,-1,-0.25f,-1,
        };

        // ^
        static float[] font_caret =
        {
            -0.5f,+0.75f,+0.0f,+0.90f,
            +0.0f,+0.90f,+0.5f,+0.75f,
        };

        // _
        static float[] font_underscore =
        {
            -0.75f,-0.9f,+0.75f,-0.9f,
        };

        // `
        static float[] font_accent =
        {
            -0.1f,+0.9f,+0.1f,+0.8f,
        };

        // {
        static float[] font_brace_start =
        {
            +0.25f,+1,+0f,+1,
            +0f,+1,+0f,+0.2f,
            +0f,+0.2f,-0.25f,+0f,
            -0.25f,+0f,+0f,-0.2f,
            +0f,-0.2f,+0f,-1,
            +0f,-1,+0.25f,-1,
        };

        // |
        static float[] font_vertical =
        {
            +0,+1,+0,-1,
        };

        // }
        static float[] font_brace_end =
        {
            -0.25f,+1,+0f,+1,
            +0f,+1,+0f,+0.2f,
            +0f,+0.2f,+0.25f,+0f,
            +0.25f,+0f,+0f,-0.2f,
            +0f,-0.2f,+0f,-1,
            +0f,-1,-0.25f,-1,
        };

        // ~
        static float[] font_tilde =
        {
            -0.50f,+0.75f,-0.25f,+0.90f,
            -0.25f,+0.90f,+0.25f,+0.60f,
            +0.25f,+0.60f,+0.50f,+0.75f,
        };

        public static float[][] Chars = {
            font_space, font_exclamation, font_quotes, font_sharp, font_dollar, font_percent, font_and, font_apostrophe, font_parenthesis_start, font_parenthesis_end,
            font_asterisk, font_plus, font_comma, font_minus, font_period, font_slash,
            font_0, font_1, font_2, font_3, font_4, font_5, font_6, font_7, font_8, font_9,
            font_collon, font_semicollon, font_lessthan, font_equal, font_overthan, font_question, font_atmark,
            font_A, font_B, font_C, font_D, font_E, font_F, font_G, font_H, font_I, font_J, font_K, font_L, font_M, font_N, font_O, font_P, font_Q, font_R, font_S, font_T, font_U, font_V, font_W, font_X, font_Y, font_Z,
            font_bracket_start, font_backslash, font_bracket_end, font_caret, font_underscore, font_accent,
            font_a, font_b, font_c, font_d, font_e, font_f, font_g, font_h, font_i, font_j, font_k, font_l, font_m, font_n, font_o, font_p, font_q, font_r, font_s, font_t, font_u, font_v, font_w, font_x, font_y, font_z,
            font_brace_start, font_vertical, font_brace_end, font_tilde,
        };

        public static float[] ControlChar =
        {
            // short horizontal line
            -0.25f,+0,+0.25f,+0,
        };
    }
}
