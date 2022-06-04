using Exiled.CustomRoles.Events;
using InventorySystem.Items.Usables;
using PlayerHandlers = Exiled.Events.Handlers.Player;

namespace CFE
{
    using System;
    using Exiled.API.Features;

    /// <inheritdoc />
    public class Plugin : Plugin<Config>
    {
        private EventHandlers eventHandlers;

        /// <inheritdoc/>
        public override string Author { get; } = "Music";

        /// <inheritdoc/>
        public override string Name { get; } = "CFE";

        /// <inheritdoc />
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            eventHandlers = new EventHandlers(this);
            PlayerHandlers.FlippingCoin += eventHandlers.OnFlippingCoin;
            PlayerHandlers.ChangingItem += eventHandlers.OnChangingItem;
            base.OnEnabled();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            PlayerHandlers.FlippingCoin -= eventHandlers.OnFlippingCoin;
            PlayerHandlers.ChangingItem -= eventHandlers.OnChangingItem;
            eventHandlers = null;
            base.OnDisabled();
        }
    }
}