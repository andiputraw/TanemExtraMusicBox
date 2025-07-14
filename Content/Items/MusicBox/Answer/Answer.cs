/*
    Generated code using the cli with argument
    Answer Answer
*/
using Terraria.ID;
using Terraria.ModLoader;

namespace TanemExtraMusicBox.Content.Items.MusicBox.Answer
{
	public class Answer : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.CanGetPrefixes[Type] = false; 
			ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.MusicBox; 

			MusicLoader.AddMusicBox(Mod, MusicLoader.GetMusicSlot(Mod, "Assets/Music/Answer"), ModContent.ItemType<Answer>(), ModContent.TileType<AnswerTile>());
		}

		public override void SetDefaults() {
			Item.DefaultToMusicBox(ModContent.TileType<AnswerTile>(), 0);
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
