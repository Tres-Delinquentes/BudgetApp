namespace Backend.Models
{
    public class Budget
    {
        public Budget SmallBudget { get; set; } = new Budget();
        public Budget MediumBudget { get; set; } = new Budget();
        public Budget LargeBudget { get; set; } = new Budget();

        public string Title { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();


        public Budget()
        {
            Categories = new List<Category>();
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
