using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System;

namespace BetterBottomlessBuckets.Items
{
	public class BottomlessLavaBucket : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("BottomlessLavaBucket"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("+2 range\nContains an endless amount of lava");
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
        
        public override bool UseItem(Player player)
		{
            if(Main.tile[Player.tileTargetX, Player.tileTargetY].active()){
                return false;
            }
            if(Math.Abs((player.position.X/16) - Player.tileTargetX) > Player.tileRangeX + 2 || Math.Abs((player.position.Y/16) - Player.tileTargetY) > Player.tileRangeY + 2){
                return false;
            }
            Main.PlaySound(19, (int) player.position.X, (int) player.position.Y, 1, 1f, 0.0f);
            Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType(1);
            Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = byte.MaxValue;
            WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
            if (Main.netMode == 1)
            NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
            return true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "BottomlessBucket", 1);
			recipe.needLava = true;
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}