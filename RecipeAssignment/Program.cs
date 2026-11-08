using System;
using System.Collections.Generic;

namespace RecipeAssignment
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public List<string> Ingredients { get; set; }

        public Recipe(int id, string name, string category, List<string> ingredients)
        {
            Id = id;
            Name = name;
            Category = category;
            Ingredients = ingredients;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1. List<T>：存放全部食谱
            List<Recipe> allRecipes = new List<Recipe>();

            // 2. Dictionary：按食谱ID快速查找
            Dictionary<int, Recipe> recipeDict = new Dictionary<int, Recipe>();

            // 3. HashSet：存放不重复的菜系分类
            HashSet<string> categorySet = new HashSet<string>();

            // 4. Queue<T>：待审核的食谱队列
            Queue<Recipe> reviewQueue = new Queue<Recipe>();

            // 5. Stack<T>：撤销操作栈（保存上一步删除的食谱）
            Stack<Recipe> undoStack = new Stack<Recipe>();


            // 测试添加一条食谱
            Recipe r1 = new Recipe(1, "番茄炒蛋", "家常菜", new List<string> { "番茄", "鸡蛋", "盐" });
            allRecipes.Add(r1);
            recipeDict.Add(r1.Id, r1);
            categorySet.Add(r1.Category);
            reviewQueue.Enqueue(r1);

            Console.WriteLine("=== 食谱管理系统 ===");
            Console.WriteLine($"总食谱数量(List)：{allRecipes.Count}");
            Console.WriteLine($"不重复分类数量(HashSet)：{categorySet.Count}");
            Console.WriteLine($"待审核队列长度(Queue)：{reviewQueue.Count}");

            // 取出队列里的食谱
            Recipe check = reviewQueue.Dequeue();
            Console.WriteLine($"审核食谱：{check.Name}");

            // 压入撤销栈
            undoStack.Push(check);
            Console.WriteLine($"栈内待撤销数量(Stack)：{undoStack.Count}");

            // 通过ID字典查找
            if (recipeDict.TryGetValue(1, out Recipe findR))
            {
                Console.WriteLine($"字典查询结果：{findR.Name}");
            }

            Console.WriteLine("\n程序运行结束");
        }
    }
}


