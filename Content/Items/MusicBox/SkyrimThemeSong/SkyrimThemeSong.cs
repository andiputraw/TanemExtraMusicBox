/*
    Generated code using the cli with argument
    SkyrimThemeSong Skyrim Theme Song
*/
using Terraria.ID;
using Terraria.ModLoader;

namespace TanemExtraMusicBox.Content.Items.MusicBox.SkyrimThemeSong
{
	public class SkyrimThemeSong : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.CanGetPrefixes[Type] = false; 
			ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.MusicBox; 

			MusicLoader.AddMusicBox(Mod, MusicLoader.GetMusicSlot(Mod, "Assets/Music/Skyrim Theme Song"), ModContent.ItemType<SkyrimThemeSong>(), ModContent.TileType<SkyrimThemeSongTile>());
		}

		public override void SetDefaults() {
			Item.DefaultToMusicBox(ModContent.TileType<SkyrimThemeSongTile>(), 0);
		}
	}
}
