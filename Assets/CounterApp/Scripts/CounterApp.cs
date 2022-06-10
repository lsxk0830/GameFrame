using FrameworkDesign;
using FrameworkDesign.Example;

namespace CounterApp
{
    /// <summary>
    /// 获取 CounterModel 只能通过 CounterApp 获取了，增加了一下 CounterModel 获取的限制
    /// </summary>
    public class CounterApp : Architecture<CounterApp>
    {
        protected override void Init()
        {
            RegisterSystem<IAchievementSystem>(new AchievementSystem());
            RegisterModel<ICounterModel>(new CounterModel());
            RegisterUtility<IStorage>(new PlayerPresStorage());
        }
    }
}