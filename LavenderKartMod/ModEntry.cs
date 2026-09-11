using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace LavenderKartMod
{
    internal sealed class ModEntry : Mod
    {
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            helper.Events.Content.AssetRequested += OnAssetRequested; ;
        }

        private void OnAssetRequested(object? sender, AssetRequestedEventArgs e)
        {
            // skip if not the MineCart spritesheet
            if (!e.NameWithoutLocale.IsEquivalentTo("Minigames/MineCart")) return;

            // replace with our spritesheet
            e.LoadFromModFile<Texture2D>(
                "assets/LavenderKart.png",
                AssetLoadPriority.Exclusive
            );
        }
    }
}
