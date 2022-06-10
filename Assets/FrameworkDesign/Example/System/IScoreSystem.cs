using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Example
{
    public interface IScoreSystem :ISystem
    {
        
    }

    public class ScoreSystem : AbstractSystem, IScoreSystem
    {
        protected override void OnInit()
        {
            var gameModel = this.GetModel<IGameModel>();

            this.RegisterEvent<GamePassEvent>(e => 
            {
                var countDownSystem = this.GetSystem<ICountDownSystem>(); 

                var timeScore = countDownSystem.CurrentRemainSeconds * 10; 

                gameModel.Score.Value += timeScore; 

                if (gameModel.Score.Value > gameModel.BestScore.Value)
                {
                    gameModel.BestScore.Value = gameModel.Score.Value;
                    Debug.Log("�¼�¼");
                }

            });

            this.RegisterEvent<OnKillEnemyEvent>(e=>
            {
                gameModel.Score.Value += 10;
                Debug.Log("�÷֣�10");
                Debug.Log("��ǰ������"+gameModel.Score.Value);
            });

            this.RegisterEvent<OnMissEvent>(e =>
            {
                gameModel.Score.Value -= 5;
                Debug.Log("�÷֣�-5");
                Debug.Log("��ǰ������" + gameModel.Score.Value);
            });
        }
    }
}
