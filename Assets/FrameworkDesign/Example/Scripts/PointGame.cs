namespace FrameworkDesign.Example
{
    public class PointGame : Architecture<PointGame>
    {
        // 这里注册模块
        protected override void Init()
        {
            RegisterSystem<IScoreSystem>(new ScoreSystem());
            RegisterSystem<ICountDownSystem>(new CountDownSystem());
            RegisterSystem<IAchievementSystem>(new AchievementSystem());

            RegisterModel<IGameModel>(new GameModel());

            RegisterUtility<IStorage>(new PlayPrefsStorage());
        }
    }
}