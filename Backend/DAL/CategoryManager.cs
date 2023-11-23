namespace Backend.DAL
{
    public class CategoryManager
    {
        
        public CategoryManager()
        {
            
        }


        public Category CreateCategory(string name, float amount)
        {
            var newCategory = new Category(){ Name = name, TotalAmount = amount, Items = new List<Item>()};
            return newCategory;
        }

        public Item FillCategoryWithItem(string name, float totalAmount)
        {
            var itemManager = new ItemManager();
            var item = itemManager.CreateItem(name, totalAmount);

            return item;
        }



        public void DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }



        public void EditCategory()
        {
            throw new NotImplementedException();
        }


    }
}
