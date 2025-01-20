/*
    Generated code using the cli with argument
    SpringtimeInAMirror Springtime in a mirror
*/
using Terraria.ID;
using Terraria.ModLoader;

namespace TanemExtraMusicBox.Content.Items.MusicBox.SpringtimeInAMirror
{
	public class SpringtimeInAMirror : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.CanGetPrefixes[Type] = false; 
			ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.MusicBox; 

			MusicLoader.AddMusicBox(Mod, MusicLoader.GetMusicSlot(Mod, "Assets/Music/Springtime in a mirror"), ModContent.ItemType<SpringtimeInAMirror>(), ModContent.TileType<SpringtimeInAMirrorTile>());
		}

		public override void SetDefaults() {
			Item.DefaultToMusicBox(ModContent.TileType<SpringtimeInAMirrorTile>(), 0);
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
