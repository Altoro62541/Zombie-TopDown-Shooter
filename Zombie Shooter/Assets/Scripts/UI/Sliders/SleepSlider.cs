using PlayerEntity.PlayerStatsSystem.Handlers;
using UniRx;
using Zenject;

public class SleepSlider : StatsSlider
{
    [Inject] private IPlayerStatsHandler _playerStatsHandler;

    protected override ReactiveProperty<float> Stat => _playerStatsHandler.Stats.Sleep;
}
