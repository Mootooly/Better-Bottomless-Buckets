using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System;

namespace BetterBottomlessBuckets.Items
{
	public class BottomlessBucket : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("BottomlessHoneyBucket"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("+2 range\nContains an endless amount of nothing");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.useTime = 11;
			item.useAnimation = 11;
			item.useStyle = 1;
			item.value = 500000;
			item.rare = 7;
			item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemoniteBar, 20);
			recipe.AddIngredient(ItemID.MeteoriteBar, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}