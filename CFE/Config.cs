using UnityEngine;

namespace CFE
{
    using System.ComponentModel;
    using Exiled.API.Interfaces;

    /// <inheritdoc />
    public class Config : IConfig
    {
        /// <inheritdoc/>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether debug messages should be shown in the console.
        /// </summary>
        [Description("Whether debug logs should be shown in the console.")]
        public bool Debug { get; set; }

        private float explosionPercentage = 20f;
        /// <summary>
        /// Gets or sets the chance that a grenade will explode upon flipping a coin
        /// </summary>
        [Description("The chance that a grenade will explode upon flipping a coin.")]
        public float ExplosionPercentage
        {
            get => explosionPercentage;
            set => explosionPercentage = Mathf.Clamp(value, 0, 100);
        }

        /// <summary>
        /// Gets or sets the multiplier of damage done to SCPs by the grenade.
        /// </summary>
        [Description("Multiplier of damage to SCPs by CoinNade.")]
        public float ScpMultiplier { get; set; } = 0.5f;

        /// <summary>
        /// Gets or sets the amount of grenades that will spawn upon a "successful" coin flip.
        /// </summary>
        [Description("The amount of grenades that will spawn upon a 'successful' coin flip. Higher values scales with volume immensely.")]
        public float Magnitude { get; set; } = 2f;

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets whether coins should explode in the lobby (mainly for WaitAndChill).
        /// </summary>
        [Description("Should coins explode while in lobby (For WaitAndChill)")]
        public bool EnabledInLobby { get; set; } = true;

        /// <summary>
        /// Gets or sets the death reason for the person who flipped the coin and exploded.
        /// </summary>
        [Description("The death reason for the person who flipped the coin and exploded.")]
        public string CoinExplosionDeathReason { get; set; } = "Flipped a coin and exploded";

        /// <summary>
        /// Gets or sets a value indicating whether players should get a hint when they equip the coin.
        /// </summary>
        [Description("Indicates whether players should get a hint when they equip the coin.")]
        public bool ShowHint { get; set; } = true;

        /// <summary>
        /// Gets or sets the hint shown to players once they equip the coin.
        /// </summary>
        [Description("The hint shown to players once they equip the coin.")]
        public string EquipHint { get; set; } = "This coin has a chance of exploding if you flip it!";

        /// <summary>
        /// Gets or sets a value indicating whether coins should always explode in lobby
        /// </summary>
        [Description("Whether or not coins should always explode in lobby.")]
        public bool LobbyExplode { get; set; } = false;
    }
}