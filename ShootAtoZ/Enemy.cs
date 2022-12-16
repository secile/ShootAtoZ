using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.ES20;

namespace ShootAtoZ
{
    class Enemy
    {
        /// <summary>表示位置角度をラジアンで。</summary>
        public double Angle { get; set; }

        /// <summary>中心からの距離。0.0-1.0範囲</summary>
        public double Distance { get; set; }

        /// <summary>移動速度</summary>
        public double Speed { get; set; }

        public bool Destroy { get; set; }

        // Downするときの角度。
        private float DownAngle;

        private Shapes.Shape ShapeText;
        private Shapes.Shape ShapeRect;

        public char Char { get; private set; }
        public Enemy(char c)
        {
            Char = c;
            ShapeText = new Shapes.AsciiChar(c);
            ShapeRect = new Shapes.Rectangle(1);
        }

        public enum StatusTypes { Wait, Move, Beat, Down }
        public StatusTypes Status { get; private set; } = StatusTypes.Wait;

        private int StatusTimer;

        public void SetStatus(StatusTypes status)
        {
            Status = status;
            StatusTimer = 0;
        }

        public void Update()
        {
            switch (Status)
            {
                case StatusTypes.Move:
                    StatusMove();
                    break;

                case StatusTypes.Down: // 倒れる。
                    if (StatusTimer < 18)
                    {
                        DownAngle += -5;
                    }
                    else if (StatusTimer < 80)
                    {
                        // しばらく倒れている。
                    }
                    else if (StatusTimer < 98)
                    {
                        DownAngle += 5;
                    }
                    else
                    {
                        SetStatus(StatusTypes.Move);
                    }
                    break;

                case StatusTypes.Beat:
                    DownAngle += 5;
                    if (DownAngle >= 90)
                    {
                        Destroy = true;
                    }
                    break;
            }

            StatusTimer++;
        }

        private void StatusMove()
        {
            this.Distance -= this.Speed;
            if (this.Distance < 0) this.Distance = 0;
        }

        public void Draw(Shader shader)
        {
            // [座標系]右手座標系。右手で親指(X軸)・人差指(Y軸)・中指(Z軸)の方向。
            //
            // Y軸(上)
            //     |
            //     |
            //  (  A  )----X軸(右)
            //    /
            //   /
            // Z軸(前)

            shader.PushMatrix();
            {
                // 倒す。
                shader.Translate(0, -0.5f, 0);
                shader.Rotate(DownAngle, Vector3.UnitX);
                shader.Translate(0, +0.5f, 0);

                // 四角い板を描画。
                shader.SetMaterial(GetColor(Char));
                ShapeRect.Draw(shader);

                // 文字描画。
                shader.SetMaterial(Color4.Black);
                shader.Translate(0, 0, 0.05f); // ちょっと手前にしないと板に埋もれる。
                GL.LineWidth(10);
                shader.Scale(0.5f, 0.5f, 0.5f);
                ShapeText.Draw(shader);
            }
            shader.PopMatrix();
        }

        private Color4 GetColor(int no)
        {
            Color4[] colors = {
                Color4.Salmon,
                Color4.Chocolate,
                Color4.Gold,
                Color4.Khaki,
                Color4.Yellow,
                Color4.DarkOrange,
                Color4.GreenYellow,
                Color4.Chartreuse,
                Color4.LightGreen,
                Color4.LimeGreen,
                Color4.MediumSpringGreen,
                Color4.Aquamarine,
                Color4.Turquoise,
                Color4.PaleTurquoise,
                Color4.Aqua,
                Color4.LightCyan,
                Color4.DarkTurquoise,
                Color4.DeepSkyBlue,
                Color4.LightSkyBlue,
                Color4.CornflowerBlue,
                Color4.Violet,
                Color4.DarkViolet,
                Color4.Fuchsia,
                Color4.DeepPink,
                Color4.Pink,
                Color4.LightPink,
            };
            no = no % colors.Length;
            return colors[no];
        }
    }
}
