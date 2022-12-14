using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;

using Com.Google.VRToolkit.CardBoard;

namespace ShootAtoZ
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : CardboardActivity
    {
        private const int MP = ViewGroup.LayoutParams.MatchParent;
        private const int WC = ViewGroup.LayoutParams.WrapContent;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // layoutは利用せず、プログラムコードで画面を作成。
            var frame = new FrameLayout(this);
            SetContentView(frame);

            // create CardboardView and set.
            // CardboarViewの作成。
            var glview = new CardboardView(this);
            glview.SetAlignedToNorth(false);
            frame.AddView(glview, MP, MP);
            SetCardboardView(glview);

            // dont work on my AQUOS sense4 lite without below.
            // これがないと私のAQUOS sense4 liteで下記ログが表示され動作しない。
            // Surface size 2064x1008 does not match the expected screen size 2280x1080. Rendering is disabled.
            var screen = glview.GetScreenParams();
            glview.Holder.SetFixedSize(screen.getWidth(), screen.getHeight());
        }
    }

    class VrRenderer : Java.Lang.Object, CardboardView.StereoRenderer
    {
        public VrRenderer(Context context)
        {

        }

        public void OnSurfaceCreated(Javax.Microedition.Khronos.Egl.EGLConfig config)
        {

        }

        public void OnSurfaceChanged(int width, int height)
        {

        }

        // OnNewFrame→OnDrawEye(Left Eye)→OnDrawEye(Right Eye)→OnFinishFrame→OnNewFrame→…の繰り返し(repeat)
        public void OnNewFrame(HeadTransform transform)
        {

        }

        public void OnDrawEye(EyeTransform transform)
        {

        }

        public void OnFinishFrame(Viewport viewport)
        {
            // 特にやることは無し。
        }

        public void OnRendererShutdown()
        {
            // 特にやることは無し。
        }
    }
}