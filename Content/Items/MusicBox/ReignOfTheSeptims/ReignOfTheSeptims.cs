/*
    Generated code using the cli with argument
    ReignOfTheSeptims Reign of the Septims
*/
using Terraria.ID;
using Terraria.ModLoader;

namespace TanemExtraMusicBox.Content.Items.MusicBox.ReignOfTheSeptims
{
	public class ReignOfTheSeptims : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.CanGetPrefixes[Type] = false; 
			ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.MusicBox; 

			MusicLoader.AddMusicBox(Mod, MusicLoader.GetMusicSlot(Mod, "Assets/Music/Reign of the Septims"), ModContent.ItemType<ReignOfTheSeptims>(), ModContent.TileType<ReignOfTheSeptimsTile>());
		}

		public override void SetDefaults() {
			Item.DefaultToMusicBox(ModContent.TileType<ReignOfTheSeptimsTile>(), 0);
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
