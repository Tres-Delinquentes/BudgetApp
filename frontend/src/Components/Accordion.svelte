<script>
  import Cross from "../assets/circle-x.svg";
  import Add from "../assets/circle-plus.svg";
  import PlusIcon from "../assets/plus.svg";
  import MinusIcon from "../assets/minus.svg";
  import { GetLatestIdOfItem } from "./Functions/FetchLatestId.svelte";
  export let budget;
  let indexOf;
  let openAccordionIndex = null;


  $: errorResponse = null;

  const AddItem = (category) => () => {
    let itemToAdd = {
      id: GetLatestIdOfItem(budget),
      name: "New Item",
      totalAmount: 0,
    };
    indexOf = budget.expenses.findIndex((cat) => cat.name == category);
    budget.expenses[indexOf].items = [
      ...budget.expenses[indexOf].items,
      itemToAdd,
    ];
    console.log(itemToAdd.id);
    console.log(budget);
  };

  const DeleteItem = (categoryIndex, itemId) => {
    var itemIndex = budget.expenses[categoryIndex].items.findIndex(
      (item) => item.id == itemId
    );
    if (itemIndex !== -1) {
      budget.expenses[categoryIndex].items.splice(itemIndex, 1);
      budget = { ...budget };
    }
  };

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
      totalAmount += parseFloat(item.amount || 0);
    });
    expense.totalAmount = totalAmount;
  });


  $: totalAmountExpense = budget.expenses.reduce(
    (total, expense) => total + expense.totalAmount,
    0
  );

  function toggleAccordion(index) {
    if (openAccordionIndex === index) {
      openAccordionIndex = null;
    } else {
      openAccordionIndex = index;
    }
  }
</script>

<style>

.accordion-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  cursor: pointer;
  background-color: #091f20;
  border: 2px solid #091f20;
  border-radius: 4px;
  color: #dff4f6;
  padding: 1rem 1rem;
}

.accordion-header-open {
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

.accordion-wrapper {
  display: grid;
  grid-template-columns: 1fr min(85ch, 100%) 1fr;
  grid-column-gap: 1rem;
}

.accordion-content-first {
  grid-column: 2 / 3;
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
}

.accordion-bg-color {
  background-color: white;
  border: 2px solid #091f20;
  border-radius: 0 0 4px 4px;
}

.accordion-item-name {
  width: 50%;
}

.accordion-item-amount {
  width: 20%;
  text-align: center;
}

.accordion-full-bleed {
  width: 100%;
  text-align: center;
}

.accordion-item-amount::-webkit-outer-spin-button,
.accordion-item-amount::-webkit-inner-spin-button {
  -webkit-appearance: none;
}

</style>


<!-- Markup for Accordion-->

{#each budget.expenses as expense, index}
  <div
    role="button"
    tabindex="0" 
    class="accordion-header subdisplay mt-3 {openAccordionIndex === index ? 'accordion-header-open' : ''}"
    on:click={() => toggleAccordion(index)}
    on:keydown={(e) => e.key === 'Enter' && toggleAccordion(index)}
    aria-expanded={openAccordionIndex === index ? 'true' : 'false'}
  >
    <span>
      {expense.name}
      {#if expense.totalAmount && expense.totalAmount !== 0}
        - {expense.totalAmount}
      {/if}
    </span>

    {#if openAccordionIndex === index}
      <img src={MinusIcon} alt="Collapse" class="accordion-icon" />
    {:else}
      <img src={PlusIcon} alt="Expand" class="accordion-icon" />
    {/if}
  </div>

  {#if openAccordionIndex === index}
    <div class="accordion-bg-color">
      <div class="accordion-content-first">
        <input 
        class="accordion-header-name mt-4 center-text"
        type="text"
        bind:value={expense.name}/>
      </div>
<hr class="custom-hr mt-5 mb-5">
      {#each expense.items as item}
        <div class="accordion-wrapper mt-2">
          <div class="accordion-content-first">
            <button
              class="icon-button"
              on:click={() => DeleteItem(index, item.id)}
            >
              <img
                src={Cross}
                class="item-icons"
                alt="delete itemfield"
              />
            </button>
            <input
              class="accordion-item-name"
              type="text"
              bind:value={item.name}
            />
            <input
              class="accordion-item-amount mx-2"
              type="number"
              min="0"
              bind:value={item.amount}
            />
          </div>
        </div>
    {/each}
      <div class="accordion-full-bleed">
        <button class="icon-button mt-4" on:click={AddItem(expense.name)}>
          <img src={Add} class="item-icons" alt="Add item" />
          <p class="small-p">Add new field</p>
        </button>
      </div>
    </div>
  {/if}
{/each}
<!-- Markup -->