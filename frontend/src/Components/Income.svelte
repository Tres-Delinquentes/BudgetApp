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
  <span>
    Inkomst - {budget.income.totalAmount}
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
      <p class="accordion-paragraph">
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
