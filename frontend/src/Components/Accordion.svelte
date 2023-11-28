<script lang="ts">
  import Accordion, { Panel, Header, Content } from "@smui-extra/accordion";
  import Expences from "./Expences.svelte";
  let currency = "SEK";
  export let budget;
  let result = null;
  let indexOf;

  let { localBudget } = budget;

  const AddItem = (category) => () => {
    let itemToAdd = { name: "New Item", totalAmount: 0 };
    indexOf = budget.expenses.findIndex((cat) => cat.name == category);
    budget.expenses[indexOf].items = [
      ...budget.expenses[indexOf].items,
      itemToAdd,
    ];
    console.log(budget);
  };

  async function PostBudgetToApi(budget) {
    const res = await fetch("https://localhost:7022/api/Budget", {
      method: "POST",
      body: JSON.stringify(budget),
      headers: {
        "content-Type": "application/json",
      },
    });

    const json = await res.json();
    result = JSON.stringify(json);
  }

  $: budget.expenses.forEach((expense) => {
    let totalAmount = 0;
    expense.items.forEach((item) => {
      totalAmount += item.amount;
    });
    expense.totalAmount = totalAmount;
  });

  $: budget.expenses.forEach((expense) => {
    let totalAmount = 0;
    expense.items.forEach((item) => {
      totalAmount += parseFloat(item.amount || 0); // Lägg till nollkontroll och konvertering till flyttal
    });
    expense.totalAmount = totalAmount;
  });

  // Reaktivt uttalande för att beräkna det totala beloppet för alla kategorier
  $: totalAmountExpense = budget.expenses.reduce(
    (total, expense) => total + expense.totalAmount,
    0,
  );
</script>

<main class="wrapper">
  <div class="content-first">
      {#each budget.expenses as expense}

      <div>
              <input 
              class="category-header" 
              type="text" 
              bind:value={expense.name} 
              />
              <div class="category-header-amount">
                {expense.totalAmount}
              </div>
            </div>
            
          {#each expense.items as item}
            <Content>
              <div class="items-wrapper">
                <input
                  class="expence-items--name"
                  type="text"
                  bind:value={item.name}
                />
                <input
                  class="expence-items--amount"
                  type="number"
                  min="0"
                  bind:value={item.amount}
                />
                <div class="expence--currency">{currency}</div>
                <div />
              </div></Content
            >
          {/each}
          <button
            class="add-item-btn"
            style="margin: 20px;"
            on:click={AddItem(expense.name)}>Add item
          </button>
      {/each}
  </div>
  <div class="content-second">
    <div class="wrapper-small">
      <div class="small-left">
        Lorem ipsum dolor, sit amet consectetur adipisicing elit. Necessitatibus obcaecati possimus sequi aliquid eveniet labore, deleniti, quas rerum sint optio nostrum, minima porro placeat. Minima sunt dignissimos saepe iusto aut!
      </div>
      <div class="small-right">
        Lorem ipsum dolor sit amet consectetur, adipisicing elit. Suscipit, culpa eum ducimus fugit, modi magnam ipsum, consequuntur officia est expedita quasi aliquam? Obcaecati minima sit accusantium atque omnis perferendis expedita?
      </div>
    </div>
    <div class="full-bleed subdisplay" style="border: 2px solid purple; text-align: start;">
      Totala inkomster: {totalAmountExpense}kr<br>
      Totala utgifter: {totalAmountExpense}kr
    </div>
<div class="full-bleed">
    <button on:click={() => PostBudgetToApi(budget)}>Post Budget</button> 
</div>    
  </div>
</main>


<style>

  .category-header {
    font-size: 1.5rem;
    font-weight: 1.25rem;
  }

  .category-header-amount {
    font-size: 1.5rem;
    background-color: white;
    padding: 2px 1rem 2px 1rem;
    border: 1px solid darkgray;
    width: max-content;
  }

  .add-item-btn {
    padding: 0.5rem 1rem 0.5rem 1rem;
    border-radius: 5px;
  }

  .expence-items--name {
    display: inline-block;
    width: 10rem;
    margin: 0 1rem 0 0;
  }

  .items-wrapper {
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: center;
  }
  
  .expence-items--amount {
    max-width: max-content;
    margin-right: 1rem;
  }

</style>

