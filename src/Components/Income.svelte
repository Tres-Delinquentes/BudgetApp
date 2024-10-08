<script>
  import Cross from "../assets/circle-x.svg";
  import Add from "../assets/circle-plus.svg";
  import PlusIcon from "../assets/plus.svg";
  import MinusIcon from "../assets/minus.svg";
  import { GetLatestIdOfItem } from "./Functions/FetchLatestId.svelte";

  let currency = "SEK";
  let openAccordionIndex = null;
  let totalIncome = 0;
  let index = 0;
  export let budget;
  export let budgetList;
  export let budgetToDisplay;
  console.log("budget from income" + budgetList);
  console.log("budgetToDisplay from income " + budgetToDisplay);

  $: budget = budgetList[budgetToDisplay];

  function toggleAccordion(index) {
    if (openAccordionIndex === index) {
      openAccordionIndex = null;
    } else {
      openAccordionIndex = index;
    }
  }

  $: {
    totalIncome = 0;
    budget.income.items.forEach((item) => {
      totalIncome += item.amount;
      console.log("totalincome from income component: " + totalIncome);
    });
    budget.income.totalAmount = totalIncome;
  }

  const DeleteItem = (incomeItemIndex, itemId) => {
    console.log(incomeItemIndex + " <incomeIndex - id of item ->" + itemId);

    if (incomeItemIndex !== -1) {
      budget.income.items.splice(incomeItemIndex, 1);
      budget = { ...budget };
      console.log("from delete item budget: " + budget);
    }
  };

  function InvalidateNegativeNumbers(event) {
    if (event.target.value < 0) {
      event.target.value = 0;
    }
  }

  const AddItem = () => () => {
    let itemToAdd = {
      id: GetLatestIdOfItem(budget),
      name: "Ny Inkomst",
      amount: 0,
    };
    budget.income.items = [...budget.income.items, itemToAdd];
  };
</script>

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
    Inkomster
    {#if budget.income.totalAmount && budget.income.totalAmount !== 0}
      - {budget.income.totalAmount}
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
    {#each budget.income.items as item, indexToDelete}
      <div class="accordion-content-first">
        <button
          class="icon-button"
          on:click={() => DeleteItem(indexToDelete, item.id)}
        >
          <img src={Cross} class="item-icons" alt="delete itemfield" />
        </button>
        <input class="accordion-item-name" type="text" bind:value={item.name} />
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
      <button class="icon-button" on:click={AddItem()}>
        <img src={Add} class="item-icons" alt="Add item" />
        <p class="small-p">Lägg till nytt fält</p>
      </button>
    </div>
  </div>
{/if}

<style>
  .accordion-header {
    display: flex;
    justify-content: space-between;
    padding: 1rem;
    background-color: #091f20;
    color: #dff4f6;
    border: 2px solid #091f20;
    border-radius: 4px;
    margin-top: 0.75rem;
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
    border: 2px solid #ccc;
    padding: 8px;
    border-radius: 4px;
    font-size: 1rem;
  }

  .item-icons {
    text-align: end;
    margin: auto;
  }

  .accordion-item-amount::-webkit-outer-spin-button,
  .accordion-item-amount::-webkit-inner-spin-button {
    -webkit-appearance: none;
  }
</style>
