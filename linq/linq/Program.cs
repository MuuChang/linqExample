using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace linq
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // メニューリスト
            List<Menu> menuList = new List<Menu>();
            menuList.Add(new Menu { name = "本日のコーヒー", icedOrHot = "hot", price = 350, menuType = "coffee" });
            menuList.Add(new Menu { name = "本日のコーヒー", icedOrHot = "ice", price = 380, menuType = "coffee" });
            menuList.Add(new Menu { name = "ハンドドリップ", icedOrHot = "hot", price = 480, menuType = "coffee" });
            menuList.Add(new Menu { name = "ハンドドリップ", icedOrHot = "ice", price = 520, menuType = "coffee" });
            menuList.Add(new Menu { name = "エスプレッソ", icedOrHot = "hot", price = 380, menuType = "espresso" });
            menuList.Add(new Menu { name = "カフェラテ", icedOrHot = "hot", price = 500, menuType = "espresso" });
            menuList.Add(new Menu { name = "カフェラテ", icedOrHot = "ice", price = 520, menuType = "espresso" });
            menuList.Add(new Menu { name = "モカソフト", icedOrHot = "", price = 450, menuType = "food" });
            menuList.Add(new Menu { name = "ミルクソフト", icedOrHot = "", price = 380, menuType = "food" });


            //-----------------------------------------------------
            // menuType=coffeeのメニューを抽出
            //-----------------------------------------------------

            var whereExam = menuList.Where(x => x.menuType.Equals("coffee"));

            // 出力
            Console.WriteLine("LINQ Whereの例");
            foreach (var where in whereExam)
            {
                Console.WriteLine(where.name + where.icedOrHot);
            } // end foreach

            //-----------------------------------------------------
            // foreachバージョン
            //-----------------------------------------------------

            List<Menu> extractCoffee = new List<Menu>();

            foreach(Menu menu in menuList) {
                if(menu.menuType.Equals("coffee")){
                    extractCoffee.Add(menu);
                } // end if
            } // end foreach

            // 出力
            Console.WriteLine("foreachバージョン");
            foreach (var extract in extractCoffee)
            {
                Console.WriteLine(extract.name + extract.icedOrHot);
            } // end foreach

            //-----------------------------------------------------
            // Selectを使う
            //-----------------------------------------------------

            var selectExam = menuList.Select(x => x.price + "円").ToList<String>();

            Console.WriteLine("Select使用例");
            foreach (String sel in selectExam)
            {
                Console.WriteLine(sel);
            }

            //-----------------------------------------------------
            // SelectとWhereの組み合わせ
            //-----------------------------------------------------

            List<String> selAndWhere = menuList
                .Where(x => x.menuType.Equals("food"))
                .Select(x => x.name + ":" + x.price + "円")
                .ToList<String>();

            Console.WriteLine("Select + Where同時");
            foreach (String selWhere in selAndWhere)
            {
                Console.WriteLine(selWhere);
            }

            //-----------------------------------------------------
            // GroupBy
            //-----------------------------------------------------

            var groupByExam = menuList.GroupBy(x => x.menuType);

            Console.WriteLine("GroupBy使用例");
            foreach (var groupBy in groupByExam)
            {
                Console.WriteLine(groupBy.Key);
                foreach(var menu in groupBy)
                {
                    Console.WriteLine(menu.name + "," + menu.icedOrHot + "," + menu.price);
                }
            }
        }
    }
}
