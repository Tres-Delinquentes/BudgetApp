<script>
  import Cross from "../assets/circle-x.svg";
  import Add from "../assets/circle-plus.svg";
  import PlusIcon from "../assets/plus.svg";
  import MinusIcon from "../assets/minus.svg";
  import { GetLatestIdOfItem } from "./Functions/FetchLatestId.svelte";
  import { GetLatestIdOfCategory } from "./Functions/FetchLatestCategoryId.svelte";

  export let budgetList;
  export let titleForBudget;
  export let budget;
  export let budgetToDisplay;
  let indexOf;
  let openAccordionIndex = null;

  $: budget = budgetList[budgetToDisplay];
  $: budget.title = titleForBudget;
  $: errorResponse = null;

  $: budget.expenses.forEach((expense) => {
    let totalAmount = 0;
    expense.items.forEach((item) => {
      totalAmount += parseFloat(item.amount || 0);
    });
    expense.totalAmount = totalAmount;
  });

  $: totalAmountExpense = budget.expenses.reduce(
    (total, expense) => total + expense.totalAmount,
    0,
  );

  const AddCategory = () => {
    const newCategory = {
      id: GetLatestIdOfCategory(budget),
      name: "New Category",
      totalAmount: 0,
      items: [],
    };
    budget.expenses.push(newCategory);
    budget = { ...budget };
  };

  const DeleteCategory = (categoryId) => {
    budget.expenses = budget.expenses.filter(
      (expense) => expense.id !== categoryId,
    );
    budget = { ...budget };
  };

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

  function InvalidateNegativeNumbers(event) {
    if (event.target.value < 0) {
      event.target.value = 0;
    }
  }

  const DeleteItem = (categoryIndex, itemId) => {
    var itemIndex = budget.expenses[categoryIndex].items.findIndex(
      (item) => item.id == itemId,
    );
    if (itemIndex !== -1) {
      budget.expenses[categoryIndex].items.splice(itemIndex, 1);
      budget = { ...budget };
    }
  };

  function toggleAccordion(index) {
    if (openAccordionIndex === index) {
      openAccordionIndex = null;
    } else {
      openAccordionIndex = index;
    }
  }
</script>

{#each budget.expenses as expense, index}
  <div
    role="button"
    tabindex="0"
    class="accordion-header subdisplay {openAccordionIndex === index
      ? 'accordion-header-open'
      : ''}"
    on:click={() => toggleAccordion(index)}
    on:keydown={(e) => e.key === "Enter" && toggleAccordion(index)}
    aria-expanded={openAccordionIndex === index ? "true" : "false"}
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
          bind:value={expense.name}
        />
      </div>
      <div class="center-text">
        <button
          class="icon-button mt-2"
          on:click|stopPropagation={() => DeleteCategory(expense.id)}
        >
          <p class="small-p">Ta bort kategori</p>
        </button>
      </div>
      <hr class="custom-hr mt-5 mb-5" />
      {#each expense.items as item}        
          <div class="accordion-content">
            <button
              class="icon-button"
              on:click={() => DeleteItem(index, item.id)}
            >
              <img src={Cross} class="item-icons" alt="delete itemfield" />
            </button>
            <input
              class="accordion-item-name"
              type="text"
              bind:value={item.name}
            />
            <input
              class="accordion-item-amount"
              type="number"
              min="0"
              on:input={InvalidateNegativeNumbers}
              bind:value={item.amount}
            />
          </div>
        
      {/each}
      <div class="accordion-content-first">
        <button class="icon-button" on:click={AddItem(expense.name)}>
          <img src={Add} class="item-icons" alt="Add item" />
          <p class="small-p">Lägg till nytt fält</p>
        </button>
      </div>
    </div>
  {/if}
{/each}
<button class="accordion-header-button subdisplay mt-3" on:click={AddCategory}>
  <span>Lägg till ny kategori</span>
  <img src={PlusIcon} alt="Add" class="accordion-icon" />
</button>

<style>

  .accordion-header,
  .accordion-header-button {
    display: flex;
    justify-content: space-between;
    padding: 1rem;
    background-color: #091f20;
    color: #dff4f6;
    border: 2px solid #091f20;
    border-radius: 4px;
    margin-top: 0.75rem;
  }

  .accordion-header-button {
    width: 100%;
  }

  .accordion-header-open {
    border-bottom-left-radius: 0;
    border-bottom-right-radius: 0;
  }

  .accordion-bg-color {
    background-color: white;
    border: 2px solid #091f20;
    border-radius: 0 0 4px 4px;
  }

  .accordion-content-first {
    background-color: #fff;
    display: flex;
    justify-content: center;
    width: auto;
    padding: 0.5rem;
  }

  .accordion-content {
    background-color: #fff;
    display: flex;
    justify-content: center;
    width: auto;
    padding: 0.5rem;
  }

  .accordion-item-name {
    width: 50%;
  }

  .accordion-item-amount {
    width: 20%;
    margin-left: 0.5rem;
    text-align: center;
  }


  @media (min-width: 768px) {
    
    .accordion-item-name,
    .accordion-item-amount {
      width: 100%;
    }
  }

  @media (min-width: 1024px) {

    .accordion-header,
    .accordion-content-first {
      padding: 1rem;
      max-width: 100%;
    }

    .accordion-content {
      max-width: 100%;
      padding: 0.5rem 2rem;
      align-items: center;
      justify-content: center;
    }

    .accordion-header {
      font-size: clamp(16px, 2vw, 20px);
    }
  }

  .accordion-item-amount::-webkit-outer-spin-button,
  .accordion-item-amount::-webkit-inner-spin-button {
    -webkit-appearance: none;
  }

  input[type="text"],
  input[type="number"] {
    border: 2px solid #091f20;
    padding: 8px;
    border-radius: 4px;
    font-size: 1rem;
  }

  .item-icons {
    text-align: end;
    margin: auto;
  }

  .accordion-item-amount {
    width: 50%;
  }

</style>
