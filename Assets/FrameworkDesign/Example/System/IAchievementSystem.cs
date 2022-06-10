using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace FrameworkDesign.Example
{
    public interface IAchievementSystem : ISystem
    {
    }

    public class AchievementItem
    {
        public string Name { get; set; }

        public Func<bool> CheckComplete { get; set; }

        public bool Unlocked { get; set; }
    }


    public class AchievementSystem : AbstractSystem, IAchievementSystem
    {
        private List<AchievementItem> mItems = new List<AchievementItem>();

        private bool mMissed = false;
        protected override void OnInit()
        {
            this.RegisterEvent<OnMissEvent>(e =>
            {
                mMissed = true;
            });

            this.RegisterEvent<GameStartEvent>(e =>
            {
                mMissed = false;
            });

            mItems.Add(new AchievementItem()
            {
                Name = "�ٷֳɾ�",
                CheckComplete = () => this.GetModel<IGameModel>().BestScore.Value > 100
            });

            mItems.Add(new AchievementItem()
            {
                Name = "�ֲ�",
                CheckComplete = () => this.GetModel<IGameModel>().Score.Value < 0
            });

            mItems.Add(new AchievementItem()
            {
                Name = "��ʧ��ɾ�",
                CheckComplete = () => !mMissed
            });

            mItems.Add(new AchievementItem()
            {
                Name = "��ʧ��ɾ�",
                CheckComplete = () => mItems.Count(item => item.Unlocked) >= 3
            });

            // �ɾ�ϵͳһ���ǳ־û��ģ����������Ҫ�־û�Ҳ�������ʱ�����У������� Unlocked ��� BindableProperty

            this.RegisterEvent<GamePassEvent>(async e =>
            {
                await Task.Delay(TimeSpan.FromSeconds(0.1f));

                foreach (var achievementItem in mItems)
                {
                    if (!achievementItem.Unlocked && achievementItem.CheckComplete())
                    {
                        achievementItem.Unlocked = true;

                        Debug.Log("���� �ɾ�:" + achievementItem.Name);
                    }
                }
            });
        }
    }
}