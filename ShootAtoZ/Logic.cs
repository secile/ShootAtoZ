using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.ES20;

using Com.Google.VRToolkit.CardBoard;

namespace ShootAtoZ
{
    class Logic
    {
        private Shapes.Shape Floor;
        private Shapes.Shape Timer;
        private Shader Shader;

        public void Init()
        {
            GL.Enable(EnableCap.DepthTest); // Depthバッファの有効化(Z座標で手前に表示)

            Floor = new Shapes.Rectangle(50);
            Timer = new Shapes.AsciiText("", 1, 1, true);

            Shader = new Shader();
        }

        private int ViewWidth, ViewHeight;

        public void SetViewSize(int width, int height)
        {
            ViewWidth = width;
            ViewHeight = height;
            GL.Viewport(0, 0, width, height);
        }

        public bool VrMode { get; set; }
        private void SetSight(EyeTransform transform)
        {
            Matrix4 mat;
            if (VrMode)
            {
                mat = transform.GetPerspective().ToMatrix4();
            }
            else
            {
                var fovy = (float)(45 * Math.PI / 180);     // 視野角
                var aspect = (float)ViewWidth / ViewHeight; // 縦横比
                mat = Matrix4.CreatePerspectiveFieldOfView(fovy, aspect, 1, 100); // 距離1～100が見える範囲。
            }

            Shader.SetProjection(mat);
        }

        public bool VrView { get; set; }
        private void SetCamera(EyeTransform transform)
        {
            if (VrView)
            {
                // 通常視点。
                // カメラは原点にあって、Y軸を上にし、-Z軸を向いている。
                // それに右目or左目にするマトリクスを掛けて、右目or左目の視点にする。
                var mat = transform.GetEyeView().ToMatrix4();
                var lookat = Matrix4.LookAt(Vector3.Zero, -Vector3.UnitZ, Vector3.UnitY);
                Shader.SetLookAt(lookat * mat);
            }
            else
            {
                // 上空から眺める視点。カメラはY軸30の位置にあって、-Z軸を上にし、原点を向いている。
                var lookat = Matrix4.LookAt(Vector3.UnitY * 30, Vector3.Zero, -Vector3.UnitZ);
                Shader.SetLookAt(lookat);
            }
        }


        public void Update()
        {
            // これがないとなぜかVRモードで表示されない、
            Shader.Activate();
        }

        public void Draw(EyeTransform transform, Model model)
        {
            // [座標系]右手座標系。右手で親指(X軸)・人差指(Y軸)・中指(Z軸)の方向。
            //
            // Y軸(上)
            //     |
            //     |
            //     |
            //     +-------X軸(右)
            //    /
            //   /
            // Z軸(前)
            //
            // カメラは原点にあって、Y軸を上にし、-Z軸を向いている。

            GL.ClearColor(Color4.Black); // 消去色を設定
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            
            SetCamera(transform);

            SetSight(transform);

            RenderModel(model);
            
            if (VrView)
            {
                RenderMsg(model);
            }
        }

        private void RenderModel(Model model)
        {
            Shader.IdentityMatrix();

            // 床を描画。
            Shader.PushMatrix();
            {
                Shader.Translate(0, -0.51f, 0);   // 少し下げる。
                Shader.Rotate(90, Vector3.UnitX); // X軸を中心に90度回転し、平置きする。

                var color = model.GameStatus == Model.GameStatusType.Over || model.GameStatus == Model.GameStatusType.Result? Color4.LightPink : Color4.SkyBlue;
                Shader.SetMaterial(color);
                Floor.Draw(Shader);
            }
            Shader.PopMatrix();

            // Enemy描画。
            foreach (var enemy in model.Enemies)
            {
                Shader.PushMatrix();
                {
                    // 描画位置まで移動。
                    // カメラの正面(-Z軸)を起点にY軸中心に回転して、距離を離す。
                    Shader.Rotate((float)enemy.Angle.RadianToDegree(), Vector3.UnitY);
                    Shader.Translate(0, 0, (float)enemy.Distance * -20);

                    // 描画。
                    enemy.Draw(Shader);
                }
                Shader.PopMatrix();
            }

            // 上空にタイマーとNEXT表示。
            if (model.GameStatus == Model.GameStatusType.Game)
            {
                Shader.PushMatrix();
                {
                    Shader.Rotate(90, Vector3.UnitX);
                    Shader.Translate(0, 0, -10);
                    Shader.Scale(0.5f, 1, 1);
                    if (VrView == false) Shader.Rotate(180, Vector3.UnitX);
                    Shader.SetMaterial(Color4.White);
                    GL.LineWidth(5);
                    var text = model.Stopwatch.Elapsed.ToString(@"mm\:ss") + "\nNEXT:" + model.Target;
                    (Timer as Shapes.AsciiText).Update(text);
                    Timer.Draw(Shader);
                }
                Shader.PopMatrix();
            }

            // Player描画（上空から眺める視点のみ）
            if (VrView == false)
            {
                Shader.PushMatrix();
                {
                    model.Player.Draw(Shader);
                }
                Shader.PopMatrix();
            }
        }

        private void RenderMsg(Model model)
        {
            string text = null;
            switch(model.GameStatus)
            {
                case Model.GameStatusType.Title:
                    text = "Tap or Shake\nto Start!";
                    break;

                case Model.GameStatusType.Ready:
                    var countdown = 3 - (int)model.Stopwatch.Elapsed.TotalSeconds;
                    text = countdown > 0 ? countdown.ToString() : "GO!";
                    break;

                case Model.GameStatusType.Over:
                    text = "FINISH!";
                    break;

                case Model.GameStatusType.Result:
                    text = "RESULT:" + model.Stopwatch.Elapsed.ToString(@"mm\:ss");
                    break;
            }
            if (text == null) return;

            // カメラを原点に戻す。
            var lookat = Matrix4.LookAt(Vector3.Zero, -Vector3.UnitZ, Vector3.UnitY);
            Shader.SetLookAt(lookat);

            Shader.PushMatrix();
            {
                // 最前面に描画する。(これがないと他のオブジェクトに隠れる)
                GL.Disable(EnableCap.DepthTest);
                {
                    Shader.Translate(0, 0, -20); // 近すぎたら大きすぎるので遠くに。
                    Shader.SetMaterial(Color4.White);
                    GL.LineWidth(5);
                    (Timer as Shapes.AsciiText).Update(text);
                    Timer.Draw(Shader);
                }
                GL.Enable(EnableCap.DepthTest);
            }
            Shader.PopMatrix();
        }
    }

    public static class Extensions
    {
        public static Vector3 ToVector3(this float[] m)
        {
            return new Vector3(m[0], m[1], m[2]);
        }

        public static Matrix4 ToMatrix4(this float[] m)
        {
            return new Matrix4(m[0], m[1], m[2], m[3], m[4], m[5], m[6], m[7], m[8], m[9], m[10], m[11], m[12], m[13], m[14], m[15]);
        }

        public static double RadianToDegree(this double value)
        {
            return value / Math.PI * 180;
        }
    }
}