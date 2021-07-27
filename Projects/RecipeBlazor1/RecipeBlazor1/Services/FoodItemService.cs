using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeClassLibrary.Models;
using System.Net.Http.Json;

namespace RecipeBlazor1.Services
{
    public class FoodItemService
    {
        private const string FoodItemTypesEndpoint = "https://localhost:44300/api/FoodItemTypes";
        private const string FoodItemsEndpoint = "https://localhost:44300/api/FoodItems";

        public List<FoodItemType> FoodItemTypes { get; set; }
        public List<FoodItemType> InventoryItemTypes { get; set; }

        public async Task<List<FoodItemType>> GetFoodItemTypes(System.Net.Http.HttpClient http, bool force)
        {
            if (force)
            {
                FoodItemTypes = await http.GetFromJsonAsync<List<FoodItemType>>(FoodItemTypesEndpoint);
            }
            else
            {
                if (FoodItemTypes == null || FoodItemTypes.Count == 0)
                {
                    FoodItemTypes = await http.GetFromJsonAsync<List<FoodItemType>>(FoodItemTypesEndpoint);
                }
            }
            return FoodItemTypes;
        }
        public async Task PostFoodItemTypes(System.Net.Http.HttpClient http, FoodItemType ItemObj)
        {

            await http.PostAsJsonAsync<FoodItemType>(FoodItemTypesEndpoint, ItemObj);

        }
        public async Task PutFoodItemTypes(System.Net.Http.HttpClient http, FoodItemType ItemObj)
        {

            var url = FoodItemTypesEndpoint + "/" + ItemObj.Id;
            await http.PutAsJsonAsync(url, ItemObj);

        }
        public async Task DeleteFoodItemTypes(System.Net.Http.HttpClient http, int Id)
        {
            var url = FoodItemTypesEndpoint + "/" + Id;
            await http.DeleteAsync(url);

        }
        public List<FoodItemType> FilterInvFoodItemTypes()
        {

            List<FoodItemType> fit = FoodItemTypes.Where(f => f.Name != "RECIPES").ToList();

            return fit;

        }




        public List<FoodItem> FoodItems { get; set; }

        public async Task<List<FoodItem>> GetFoodItems(System.Net.Http.HttpClient http, bool force)
        {
            if (force)
            {
                FoodItems = await http.GetFromJsonAsync<List<FoodItem>>(FoodItemsEndpoint);
            }
            else
            {
                if (FoodItems == null || FoodItems.Count == 0)
                {
                    FoodItems = await http.GetFromJsonAsync<List<FoodItem>>(FoodItemsEndpoint);
                }
            }
            return FoodItems;
        }
        public async Task PostFoodItems(System.Net.Http.HttpClient http, FoodItem ItemObj)
        {

            await http.PostAsJsonAsync<FoodItem>(FoodItemsEndpoint, ItemObj);

        }
        public async Task PutFoodItems(System.Net.Http.HttpClient http, FoodItem ItemObj)
        {

            var url = FoodItemsEndpoint + "/" + ItemObj.Id;
            await http.PutAsJsonAsync(url, ItemObj);

        }
        public async Task DeleteFoodItems(System.Net.Http.HttpClient http, int Id)
        {
            var url = FoodItemsEndpoint + "/" + Id;
            await http.DeleteAsync(url);

        }
        public List<FoodItem> FilterFoodItems(int TypeId)
        {
            //IEnumerable<FoodItem> f = FoodItems.Where(f => f.FoodItemType.Id == 2);

            //List<FoodItem> fi = FoodItems.Where(f => f.FoodItemType.Id == TypeId).ToList();

            List<FoodItem> fi = new List<FoodItem>();
            foreach(FoodItem f in FoodItems)
            {
                if (f.FoodItemType.Id == TypeId)
                {
                    fi.Add(f);
                }
            }

            return fi;
        }
        public List<FoodItem> FilterFoodItemsByName(string Name)
        {

            List<FoodItem> fi = FoodItems.Where(f => f.FoodItemType.Name == Name).ToList();
            //Console.WriteLine("2");

            return fi;

        }


    }
}
