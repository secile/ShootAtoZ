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

        public char Target { get; private set; } = 'A';

        public Action Destroied { get; set; }

        private void Attack()
        {
            if (Player.Attack(Target))
            {
                Target++;
                Destroied?.Invoke();
            }
        }

        private void InitStage()
        {
            Player.Init();
            Enemies.Clear();

            var rand = new Random();
            for (char c = 'A'; c <= 'B'; c++)
            {
                var enemy = new Enemy(c);
                enemy.Angle = rand.NextDouble() * Math.PI * 2; // 全周囲にランダムで
                enemy.Distance = 0.25 + (rand.NextDouble() * 0.25); // 0.25-0.5範囲でランダム
                //enemy.Speed = 0.001 + (rand.NextDouble() * 0.0001 * stage); // ステージが進むごとに少しずつ早く。
                Enemies.Add(enemy);
            }
        }

        public enum GameStatusType { Init, Title, Ready, Game, Over }
        public GameStatusType GameStatus { get; private set; } = GameStatusType.Init;
        private int StatusTimer;

        private void SetGameStatus(GameStatusType status)
        {
            GameStatus = status;
            StatusTimer = 0;
            OnStatusChanged?.Invoke(status);
        }

        public void UpdateStatus()
        {
            switch (GameStatus)
            {
                case GameStatusType.Init:
                    SetGameStatus(GameStatusType.Title);
                    InitStage();
                    break;

                case GameStatusType.Title:
                    break;

                case GameStatusType.Ready:
                    if (StatusTimer == 0)
                    {
                        Stopwatch.Restart();
                    }
                    if (StatusTimer > 30 * 5)
                    {
                        Stopwatch.Restart();
                        SetGameStatus(GameStatusType.Game);
                    }
                    break;

                case GameStatusType.Game:
                    GameMain();
                    break;

                case GameStatusType.Over:
                    if (StatusTimer == 0)
                    {
                        Stopwatch.Stop();
                    }
                    if (StatusTimer > 240) SetGameStatus(GameStatusType.Init);
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