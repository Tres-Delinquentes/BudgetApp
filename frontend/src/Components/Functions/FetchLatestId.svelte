<script context="module">
  let itemId = 0;

  export function GetLatestIdOfItem(budget) {
    budget.expenses.forEach((expense) => {
      expense.items.forEach((item) => {
        if (item.id > itemId) {
          itemId = item.id;
        }
      });
    });
    itemId++;
    console.log(itemId);
    return itemId;
  }
</script>
