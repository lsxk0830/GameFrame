using CounterApp;
using FrameworkDesign;
using UnityEngine;

namespace CounterApp
{
    public interface IAchievementSystem :ISystem
    {
        
    }

    public class AchievementSystem : AbstractSystem, IAchievementSystem
    {
        protected override void OnInit()
        {
            var counterModel = this.GetModel<ICounterModel>();

            var previousCount = counterModel.Count.Value;

            counterModel.Count.RegisterOnValueChanged(newCount =>
            {
                if (previousCount < 10 && newCount >= 10)
                {
                    Debug.Log("解锁点击10此成就");
                }
                else if (previousCount < 20 && newCount >= 20)
                {
                    Debug.Log("解锁点击20此成就");
                }

                previousCount = newCount;
            });
        }
    }
}