using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs;
using Exiled.Loader;
using InventorySystem.Items.Usables.Scp330;
using MEC;
using UnityEngine.Playables;
using Utils.Networking;

namespace CFE
{
    using Exiled.API.Features;

    /// <summary>
    /// General event handlers.
    /// </summary>
    public class EventHandlers
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="plugin">The <see cref="Plugin{TConfig}"/> class reference.</param>
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        public void OnChangingItem(ChangingItemEventArgs ev)
        {
            if (ev.NewItem == null)
            {
                return;
            }
            if (ev.NewItem.Type == ItemType.Coin && plugin.Config.ShowHint)
            {
                ev.Player.ShowHint(plugin.Config.EquipHint);
            }
        }

        public void OnFlippingCoin(FlippingCoinEventArgs ev)
        {
            if (Loader.Random.Next(100) < plugin.Config.ExplosionPercentage || (plugin.Config.LobbyExplode && !Round.IsStarted))
            {
                var OldPlayerRole = ev.Player.Role;
                bool beforeRoundStart = Round.IsStarted;
                ExplosiveGrenade grenade = (ExplosiveGrenade) Item.Create(ItemType.GrenadeHE);
                Timing.CallDelayed(1.83f, () =>
                {
                    if ((Round.IsStarted || plugin.Config.EnabledInLobby) && OldPlayerRole == ev.Player.Role)
                    {
                        if (beforeRoundStart != Round.IsStarted)
                        {
                            return;
                        }
                        var savedPlayerPosition = ev.Player.Position;
                        var savedPlayerTeam = ev.Player;

                        for (int i = 0; i < plugin.Config.Magnitude; i++)
                        {
                            grenade.FuseTime = 0.1f;
                            grenade.ScpMultiplier = plugin.Config.ScpMultiplier;
                            grenade.SpawnActive(savedPlayerPosition, savedPlayerTeam);
                            ev.Player.Hurt(500, plugin.Config.CoinExplosionDeathReason);
                            new CandyPink.CandyExplosionMessage
                            {
                                Origin = ev.Player.Position,
                            }.SendToAuthenticated(0);
                        }
                    }
                });
            }
        }
    }
}