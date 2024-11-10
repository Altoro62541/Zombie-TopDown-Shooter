using PlayerEntity.PlayerStatsSystem.Handlers;
using UniRx;
using Zenject;

public class ThirstSlider : StatsSlider
{
    [Inject] private IPlayerStatsHandler _playerStatsHandler;

    protected override FloatReactiveProperty Stat => _playerStatsHandler.Stats.Thirst;
}
