using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Example
{
    public interface IGameModel:IModel
    {
        BindableProperty<int> KillCount { get; }
        BindableProperty<int> Gold { get; }
        BindableProperty<int> Score { get;  }
        BindableProperty<int> BestScore { get; }
        BindableProperty<int> Life { get; } 
    }

    public class GameModel:AbstractModel,IGameModel
    {
        public BindableProperty<int> KillCount { get; } = new BindableProperty<int> { Value = 0 };   // 击杀数量
        public BindableProperty<int> Gold { get; } = new BindableProperty<int> { Value = 0 };      // 金币
        public BindableProperty<int> Score { get; } = new BindableProperty<int> { Value = 0 };     // 分数
        public BindableProperty<int> BestScore { get; } = new BindableProperty<int> { Value = 0 }; // 最高分
        public BindableProperty<int> Life { get; } = new BindableProperty<int> { Value = 0 }; // 最高分

        protected override void OnInit()
        {
            var storage = this.GetUtility<IStorage>();
            BestScore.Value = storage.LoadInt(nameof(BestScore),0);
            BestScore.RegisterOnValueChanged( v => storage.SaveInt(nameof(BestScore), v));

            Life.Value = storage.LoadInt(nameof(Life), 3); 
            Life.RegisterOnValueChanged(v => storage.SaveInt(nameof(Life), v));  
            Gold.Value = storage.LoadInt(nameof(Gold), 0); 
            Gold.RegisterOnValueChanged((v) => storage.SaveInt(nameof(Gold), v)); 
        }
    }

}
