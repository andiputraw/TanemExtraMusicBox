using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace TanemExtraMusicBox.Content.Items.Materials.TanemEssence
{
    public class TanemEssence: ModItem
    {
        public override void SetStaticDefaults(){
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;

            Item.maxStack = Item.CommonMaxStack;
            Item.value = Item.buyPrice(silver: 1);
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.DaybloomSeeds, 3)
                .AddIngredient(ItemID.MoonglowSeeds,3)
                .AddIngredient(ItemID.BlinkrootSeeds, 3)
                .AddIngredient(ItemID.WaterleafSeeds, 3)
                .AddIngredient(ItemID.DeathweedSeeds, 3)
                .AddIngredient(ItemID.ShiverthornSeeds, 3)
                .AddIngredient(ItemID.FireblossomSeeds, 3)
                .AddTile(TileID.Trees)
            .Register();
        }
    }  
}