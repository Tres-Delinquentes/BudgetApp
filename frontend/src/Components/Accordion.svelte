<script lang="ts">
  import Accordion, { Panel, Header, Content } from "@smui-extra/accordion";
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

  let displayAmount;
  function CalculateTotalAmount(category) {
    let totalAmount = 0;
    category.items.map((item) => {
      totalAmount += item.amount;
      category.totalAmount = totalAmount;
      displayAmount = category.totalAmount;
      console.log(category.totalAmount);
    });
  }
</script>

<main>
  <div class="accordion-container">
    <Accordion>
      {#each budget.expenses as expense}
        <Panel>
          <Header>
            <div class="header-wrapper">
              <input class="category-header" bind:value={expense.name} />
              <div class="category-header-amount">
                {displayAmount} SEK
              </div>
              <button
                class="header-btn"
                on:click={() => {
                  CalculateTotalAmount(expense);
                }}>Calculate total Amount</button
              >
            </div>
          </Header>
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
                  type="digit"
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
            on:click={AddItem(expense.name)}>Add item</button
          >
        </Panel>
      {/each}
    </Accordion>
  </div>
</main>

<div class="post-budget-wrapper">
  <button class="post-budget-btn" on:click={() => PostBudgetToApi(budget)}
    >Post Budget</button
  >
</div>

<style>
  .header-wrapper {
    display: flex;
    flex-direction: row;
    gap: 1rem;
    align-items: center;
    justify-content: center;
    margin-bottom: 1rem;
  }

  .header-btn {
    padding: 0.4rem;
  }
  .accordion-container {
    margin-top: 4rem;
  }

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
  .post-budget-wrapper {
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: center;
    margin-bottom: 1rem;
  }

  .post-budget-btn {
    display: inline-block;
    font-size: 1.5rem;
    padding: 0.5rem 1rem 0.5rem 1rem;
    border-radius: 5px;
    margin: 2rem 0 1rem 0;
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
    width: auto;
  }

  .expence--currency {
  }
</style>
