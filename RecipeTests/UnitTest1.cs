using Xunit;
using RecipeAssignment;
using System.Collections.Generic;

namespace RecipeTests
{
    public class RecipeTests
    {
        [Fact]
        public void TestListAddRecipe()
        {
            List<Recipe> list = new List<Recipe>();
            Recipe r = new Recipe(1, "番茄炒蛋", "家常菜", new List<string> { "番茄", "鸡蛋" });
            list.Add(r);
            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void TestDictionaryFindRecipe()
        {
            Dictionary<int, Recipe> dict = new Dictionary<int, Recipe>();
            Recipe r = new Recipe(1, "番茄炒蛋", "家常菜", new List<string> { "番茄", "鸡蛋" });
            dict.Add(1, r);
            bool ok = dict.TryGetValue(1, out var res);
            Assert.True(ok);
            Assert.Equal("番茄炒蛋", res.Name);
        }

        [Fact]
        public void TestHashSetNoDuplicate()
        {
            HashSet<string> set = new HashSet<string>();
            set.Add("家常菜");
            set.Add("家常菜");
            Assert.Equal(1, set.Count);
        }

        [Fact]
        public void TestQueueEnqueueDequeue()
        {
            Queue<Recipe> q = new Queue<Recipe>();
            Recipe r = new Recipe(1, "番茄炒蛋", "家常菜", new List<string> { "番茄", "鸡蛋" });
            q.Enqueue(r);
            var outR = q.Dequeue();
            Assert.Equal(r.Name, outR.Name);
        }

        [Fact]
        public void TestStackPushPop()
        {
            Stack<Recipe> s = new Stack<Recipe>();
            Recipe r = new Recipe(1, "番茄炒蛋", "家常菜", new List<string> { "番茄", "鸡蛋" });
            s.Push(r);
            var outR = s.Pop();
            Assert.Equal(r.Id, outR.Id);
        }
    }
}

