using PlayerEntity.PlayerStatsSystem.Handlers;
using UniRx;
using Zenject;

public class WarmSlider : StatsSlider
{
    [Inject] private IPlayerStatsHandler _playerStatsHandler;

    protected override ReactiveProperty<float> Stat => _playerStatsHandler.Stats.Warm;
}
