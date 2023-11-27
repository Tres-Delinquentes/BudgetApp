<script lang="ts">
  import Accordion, { Panel, Header, Content } from "@smui-extra/accordion";
  let currency = "SEK";
  export let budget;
  let result = null;
  let indexOf;

  let { localBudget } = budget;

  const FindItem = (category) => () => {
    indexOf = budget.expenses.findIndex((cat) => cat.name == category);
  };

  const AddItem = (category) => () => {
    let itemToAdd = { name: "New Item", totalAmount: 0 };
    FindItem(category);
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

  function CalculateTotalAmount(category) {
    let totalAmount = 0;
    category.totalAmount = 0;
    category.items.map((item) => {
      totalAmount += item.amount;
      category.totalAmount = totalAmount;
    });
  }
</script>

<main>
  <div class="accordion-container">
    <Accordion>
      {#each budget.expenses as expense}
        <Panel>
          <Header>
            <input bind:value={expense.name} /> - {expense.totalAmount}
          </Header>
          {CalculateTotalAmount(expense)}
          {#each expense.items as item}
            <Content>
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
            </Content>
          {/each}
          <button style="margin: 20px;" on:click={AddItem(expense.name)}
            >Add item</button
          >
        </Panel>
      {/each}
    </Accordion>
  </div>
</main>

<button on:click={() => PostBudgetToApi(budget)}>Post Budget</button>

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
    width: 50px;
    margin: 0 0.5rem 0 0;
  }

  .expence--currency {
    display: inline-block;
  }
</style>
