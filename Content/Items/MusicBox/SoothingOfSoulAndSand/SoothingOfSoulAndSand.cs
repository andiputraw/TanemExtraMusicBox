/*
    Generated code using the cli with argument
    SoothingOfSoulAndSand Soothing of Soul and Sand
*/
using Terraria.ID;
using Terraria.ModLoader;

namespace TanemExtraMusicBox.Content.Items.MusicBox.SoothingOfSoulAndSand
{
	public class SoothingOfSoulAndSand : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.CanGetPrefixes[Type] = false; 
			ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.MusicBox; 

			MusicLoader.AddMusicBox(Mod, MusicLoader.GetMusicSlot(Mod, "Assets/Music/Soothing of Soul and Sand"), ModContent.ItemType<SoothingOfSoulAndSand>(), ModContent.TileType<SoothingOfSoulAndSandTile>());
		}

		public override void SetDefaults() {
			Item.DefaultToMusicBox(ModContent.TileType<SoothingOfSoulAndSandTile>(), 0);
		}

		public override void AddRecipes()
        {
            CreateRecipe(1)
				.AddIngredient<Materials.TanemEssence.TanemEssence>(3)
				.AddTile(TileID.Trees)
			.Register();
        }
	}
}
