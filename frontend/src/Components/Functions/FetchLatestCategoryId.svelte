<script context="module">
  let categoryId = 0;

  export function GetLatestIdOfCategory(budget) {
    budget.expenses.forEach((expense) => {
        if (expense.id > categoryId) {
          categoryId = expense.id;
        }
      });
    categoryId++;
    console.log(categoryId);
    return categoryId;
  }
</script>
