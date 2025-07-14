/*
    Generated code using the cli with argument
    ChasedBattleTheme Chased Battle Theme
*/
using Terraria.ID;
using Terraria.ModLoader;

namespace TanemExtraMusicBox.Content.Items.MusicBox.ChasedBattleTheme
{
	public class ChasedBattleTheme : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.CanGetPrefixes[Type] = false; 
			ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.MusicBox; 

			MusicLoader.AddMusicBox(Mod, MusicLoader.GetMusicSlot(Mod, "Assets/Music/Chesed Battle Theme"), ModContent.ItemType<ChasedBattleTheme>(), ModContent.TileType<ChasedBattleThemeTile>());
		}

		public override void SetDefaults() {
			Item.DefaultToMusicBox(ModContent.TileType<ChasedBattleThemeTile>(), 0);
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
