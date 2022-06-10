using System;
using UnityEngine;
using UnityEngine.UI;

namespace FrameworkDesign.Example
{
    public class GamePassPanel : MonoBehaviour, IController
    {
        private void Start()
        {
            transform.Find("RemainSecondsText").GetComponent<Text>().text =
                "ʣ��ʱ��:" + this.GetSystem<ICountDownSystem>().CurrentRemainSeconds + "s";

            var gameModel = this.GetModel<IGameModel>();

            transform.Find("BestScoreText").GetComponent<Text>().text =
                "��߷���:" + gameModel.BestScore.Value;

            transform.Find("ScoreText").GetComponent<Text>().text =
                "����:" + gameModel.Score.Value;
        }


        public IArchitecture GetArchitecture()
        {
            return PointGame.Interface;
        }
    }
}