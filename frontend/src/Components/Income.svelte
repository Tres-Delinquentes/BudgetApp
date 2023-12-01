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
      name: "New Item",
      amount: 0,
    };
    budget.income.items = [...budget.income.items, itemToAdd];
  };
</script>

<div
  role="button"
  tabindex="0"
  class="accordion-header subdisplay mt-3 {openAccordionIndex === index
    ? 'accordion-header-open'
    : ''}"
  on:click={() => toggleAccordion(index)}
  on:keydown={(e) => e.key === "Enter" && toggleAccordion(index)}
  aria-expanded={openAccordionIndex === index ? "true" : "false"}
>
  <!-- <span>
    Inkomst - {budget.income.totalAmount}
  </span> -->

      <span>
      Inkomst
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
    <div class="accordion-paragraph">
      <p class="">
        Lorem ipsum dolor sit amet consectetur adipisicing elit. Iste veritatis
        inventore repellat recusandae minus itaque, a porro similique soluta
        facilis non omnis laudantium, impedit eum fugit? Vitae veniam sint
        quidem!
      </p>
    </div>
    {#each budget.income.items as item, indexToDelete}
      <div class="accordion-wrapper mt-2">
        <div class="accordion-content-first">
          <button
            class="icon-button"
            on:click={() => DeleteItem(indexToDelete, item.id)}
          >
            <img src={Cross} class="item-icons" alt="delete itemfield" />
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
            on:input={InvalidateNegativeNumbers}
            bind:value={item.amount}
          />
        </div>
      </div>
    {/each}
    <div class="accordion-full-bleed">
      <button class="icon-button mt-4" on:click={AddItem()}>
        <img src={Add} class="item-icons" alt="Add item" />
        <p class="small-p">Add new field</p>
      </button>
    </div>
  </div>
{/if}

<style>

.accordion-paragraph {
  text-align: center;
  display: flex;
  justify-content: center;
  align-items: center;
}
  
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
    width: 100%;
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