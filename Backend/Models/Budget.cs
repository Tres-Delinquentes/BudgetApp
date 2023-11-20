namespace Backend.Models
{
    public class Budget
    {
        public Budget SmallBudget { get; set; } = new Budget();
        public Budget MediumBudget { get; set; } = new Budget();
        public Budget LargeBudget { get; set; } = new Budget();

        public List<SubCategory> Income { get; set; }

        public string Title { get; set; }
        public List<Category> Expenses { get; set; } = new List<Category>();


        public Budget()
        {
           
        }

        private void FillSmallBudget()
        {

        }
        private void FillMediumBudget()
        {

        }
        private void FillLargeBudget()
        {

        }
    }
}
