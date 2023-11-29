<script lang="ts">
  import Accordion, { Panel, Header, Content } from "@smui-extra/accordion";
  import Expences from "./Expences.svelte";
  import Icon from "../assets/checkmark.svg";
  let currency = "SEK";
  export let budget;
  let result = null;
  let indexOf;
  let resultFromPostBudget;

  $: errorResponse = null;

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
    fetch("https://localhost:7022/api/Budget", {
      method: "POST",
      body: JSON.stringify(budget),
      headers: {
        "content-Type": "application/json",
      },
    })
      .then(async (r) => {
        if (!r.ok) {
          errorResponse = await r.json();
          console.log("Error occurred:", errorResponse.message);
        } else {
          return r.json();
        }
      })
      .then((responseData) => {
        if (responseData) {
          console.log("Success:", responseData);
        }
      })
      .catch((error) => {
        console.error("Fetch error:", error);
      });

    // try {
    //   const json = await res.json().then((response) => {
    //     console.log(response);
    //   });
    // } catch (error) {
    //   console.log(error);
    // }

    // resultFromPostBudget = JSON.stringify(json);
    // console.log(resultFromPostBudget);
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
    0
  );
</script>

<main class="wrapper"></main>

<main class="wrapper">
  <!-- <div class="content-first">
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
                  class="item-name"
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
  </div> -->
  <div class="content-first">
    {#each budget.expenses as expense}
      <!-- if NEWCATEGORY-button pressed => gör om till inputfield 
        <input class="" type="text" bind:value={expense.name}/> -->
      <div class="category-title subdisplay mb-5">
        {expense.name} - {expense.totalAmount}kr
      </div>

      {#each expense.items as item}
        <div class="item-wrapper mb-1 mt-2">
          <div class="item-icons">
            <!-- Lägg till funktionalitet för ikoner (add-item-btn) -->
            <img src={Icon} class="item-icons" alt="delete" />
            <img src={Icon} class="item-icons" alt="edit" />
          </div>
          <input class="item-name p" type="text" bind:value={item.name} />
          <input
            class="item-amount p"
            type="number"
            min="0"
            bind:value={item.amount}
          />
        </div>
      {/each}
      <button
        class="add-item-btn"
        style="margin: 20px;"
        on:click={AddItem(expense.name)}
        >Add item
      </button>
    {/each}
  </div>
  <div class="content-second">
    <div class="wrapper-small">
      <div class="small-left">
        Lorem ipsum dolor, sit amet consectetur adipisicing elit. Necessitatibus
        obcaecati possimus sequi aliquid eveniet labore, deleniti, quas rerum
        sint optio nostrum, minima porro placeat. Minima sunt dignissimos saepe
        iusto aut!
      </div>
      <div class="small-right">
        Lorem ipsum dolor sit amet consectetur, adipisicing elit. Suscipit,
        culpa eum ducimus fugit, modi magnam ipsum, consequuntur officia est
        expedita quasi aliquam? Obcaecati minima sit accusantium atque omnis
        perferendis expedita?
      </div>
    </div>
    <div class="full-bleed subdisplay total-expenses">
      Totala inkomster: {totalAmountExpense}kr<br />
      Totala utgifter: {totalAmountExpense}kr
    </div>
    <div class="full-bleed">
      <button on:click={() => PostBudgetToApi(budget)}>Post Budget</button>
      {#if errorResponse !== null}
        <p>{errorResponse.message}</p>
      {/if}
    </div>
  </div>
</main>

<style>
  .add-item-btn {
    padding: 0.5rem 1rem 0.5rem 1rem;
    border-radius: 5px;
  }
</style>
