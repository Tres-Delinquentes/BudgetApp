<script>
  export let budget;
  let currency = "SEK";
  let itemToAdd = { name: "New Item", totalAmount: 0 };

  let localBudget = budget;

  const AddItem = (category) => () => {
    console.log(category);
    var indexOf = localBudget.expenses.findIndex((cat) => cat.name == category);
    console.log(indexOf);
    localBudget.expenses[indexOf].items.push(itemToAdd);
    console.log(budget);
  };
</script>

<section>
  {#key localBudget.expenses}
    {#each localBudget.expenses as expense}
      <div class="expense">
        <h3>{expense.name}</h3>
        <div class="items">
          {#each expense.items as item}
            <div class="expence--items">
              <input
                class="expence-items--name"
                type="text"
                bind:value={item.name}
              />
              <input
                class="expence-items--amount"
                type="digit"
                min="0"
                bind:value={item.amount}
              />
              <div class="expence--currency">{currency}</div>
            </div>
          {/each}
          <button on:click={AddItem(expense.name)}>Add item</button>
        </div>
      </div>
    {/each}
  {/key}
</section>

<style>
  .expence--items {
    display: inline-block;
    padding: 1px;
  }

  .expence-items--name {
    display: inline-block;
    width: 10rem;
    margin: 0 1rem 0 0;
  }

  .expence-items--amount {
    display: inline-block;
    width: 30px;
    margin: 0 0.5rem 0 0;
  }

  .expence--currency {
    display: inline-block;
  }
</style>
