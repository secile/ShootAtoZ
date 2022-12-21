using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShootAtoZ
{
    class Model
    {
        public Player Player { get; private set; }
        public List<Enemy> Enemies { get; private set; }

        public Action OnGameOver { get; set; }
        public Action<GameStatusType> OnStatusChanged { get; set; }

        public System.Diagnostics.Stopwatch Stopwatch = new System.Diagnostics.Stopwatch();

        public Model()
        {
            Enemies = new List<Enemy>();
            Player = new Player(Enemies);
        }

        public void Action()
        {
            if (GameStatus == GameStatusType.Title)
            {
                SetGameStatus(GameStatusType.Ready);
            }
            else
            {
                Attack();
            }
        }

        private char _Target;
        public char Target
        {
            get { return _Target; }
            set
            {
                _Target = value;
                TargetChanged?.Invoke(value);
            }
        }

        public Action<char> TargetChanged { get; set; }

        private void Attack()
        {
            if (Player.Attack(Target))
            {
                Target++;
            }
        }

        private void InitStage()
        {
            Player.Init();
            Enemies.Clear();

            var rand = new Random();
            for (char c = 'A'; c <= 'Z'; c++)
            {
                var enemy = new Enemy(c);
                enemy.Angle = rand.NextDouble() * Math.PI * 2; // 全周囲にランダムで
                enemy.Distance = 0.25 + (rand.NextDouble() * 0.25); // 0.25-0.5範囲でランダム
                Enemies.Add(enemy);
            }

            Target = 'A';
        }

        private void InitTitle()
        {
            Enemies.Clear();

            var angle = 0.5;
            var text = "Shoot A-Z!";
            foreach (var item in text)
            {
                var enemy = new Enemy(item);
                if (item != ' ')
                {
                    enemy.Angle = angle;
                    enemy.Distance = 0.5;
                    Enemies.Add(enemy);
                }
                angle -= 0.11f;
            }
        }

        public enum GameStatusType { Init, Title, Ready, Game, Over, Result }
        public GameStatusType GameStatus { get; private set; } = GameStatusType.Init;
        private GameStatusType NextStatus = GameStatusType.Init;
        private int StatusTimer;

        private void SetGameStatus(GameStatusType status)
        {
            NextStatus = status;
            StatusTimer = 0;
            OnStatusChanged?.Invoke(status);
        }

        private bool exitStatus => GameStatus != NextStatus;

        public void UpdateStatus()
        {
            // Statusが変わっていたら初期化フラグを立てる。
            var initStatus = false;
            if (GameStatus != NextStatus)
            {
                GameStatus = NextStatus;
                initStatus = true;
            }

            switch (GameStatus)
            {
                case GameStatusType.Init:
                    SetGameStatus(GameStatusType.Title);
                    break;

                case GameStatusType.Title:
                    if (initStatus) InitTitle();
                    break;

                case GameStatusType.Ready:
                    if (initStatus) InitStage();
                    if (initStatus) Stopwatch.Restart();
                    if (StatusTimer > 30 * 4)
                    {
                        SetGameStatus(GameStatusType.Game);
                    }
                    break;

                case GameStatusType.Game:
                    if (initStatus) Stopwatch.Restart();
                    GameMain();
                    if (exitStatus) Stopwatch.Stop();
                    break;

                case GameStatusType.Over:
                    if (StatusTimer > 30 * 5) SetGameStatus(GameStatusType.Result);
                    break;

                case GameStatusType.Result:
                    if (StatusTimer > 30 * 5) SetGameStatus(GameStatusType.Init);
                    break;
            }

            StatusTimer++;
        }

        private void GameMain()
        {
            // Enemyが全滅したらゲームオーバー。
            if (Enemies.Count == 0) SetGameStatus(GameStatusType.Over);

            // PlayerとEnemyの状態を更新。
            Player.Update();
            foreach (var enemy in Enemies)
            {
                enemy.Update();
            }

            // 倒したEnemyをリストから削除（要素の削除はリストの逆から。）
            for (int i = Enemies.Count - 1; i >= 0; i--)
            {
                var enemy = Enemies[i];
                if (enemy.Destroy)
                {
                    Enemies.Remove(enemy);
                }
            }
        }
    }
}