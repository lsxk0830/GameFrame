using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FrameworkDesign.Example
{
    public class GameStartPanel : MonoBehaviour, IController
    {
        private IGameModel mGameModel;

        void Start()
        {
            transform.Find("BtnGameStart").GetComponent<Button>()
                .onClick.AddListener(() =>
                {
                    gameObject.SetActive(false);

                    this.SendCommand<StartGameCommand>();
                });

            transform.Find("BtnBuyLife").GetComponent<Button>()
                .onClick.AddListener(() =>
                {

                    this.SendCommand<BuyLifeCommand>();
                });

            mGameModel = this.GetModel<IGameModel>();

            mGameModel.Gold.RegisterOnValueChanged(OnGoldValueChanged);
            mGameModel.Life.RegisterOnValueChanged(OnLifeValueChanged);

            // 第一次需要调用一下
            OnGoldValueChanged(mGameModel.Gold.Value);
            OnLifeValueChanged(mGameModel.Life.Value);

            transform.Find("BestScoreText").GetComponent<Text>().text = "最高分:" + mGameModel.BestScore.Value;
        }

        private void OnLifeValueChanged(int life)
        {
            transform.Find("LifeText").GetComponent<Text>().text = "生命：" + life;
        }

        private void OnGoldValueChanged(int gold)
        {
            if (gold > 0)
            {
                transform.Find("BtnBuyLife").gameObject.SetActive(true);
            }
            else
            {
                transform.Find("BtnBuyLife").gameObject.SetActive(false);
            }

            transform.Find("GoldText").GetComponent<Text>().text = "金币：" + gold;
        }


        private void OnDestroy()
        {
            mGameModel.Gold.UnRegisterOnValueChanged(OnGoldValueChanged);
            mGameModel.Life.UnRegisterOnValueChanged(OnLifeValueChanged);
            mGameModel = null;
        }

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return PointGame.Interface;
        }
    }
}
