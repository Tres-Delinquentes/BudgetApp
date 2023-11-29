<script lang="ts">
  import Cross from "../assets/circle-x.svg";
  import Edit from "../assets/circle-more-horizontal.svg";
  import Add from "../assets/circle-plus.svg";
  import PlusIcon from "../assets/plus.svg";
  import MinusIcon from "../assets/minus.svg";
  import Expences from "./Expences.svelte";
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

  const DeleteItem = (categoryIndex, itemName) => {
    var itemIndex = budget.expenses[categoryIndex].items.findIndex((item) => item.name == itemName);
    if (itemIndex !== -1) {
      budget.expenses[categoryIndex].items.splice(itemIndex, 1);
      budget = {...budget};
    }
  }
  
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


  //Nya accordion
  let openAccordionIndex = null;

  function toggleAccordion(index) {
    if (openAccordionIndex === index) {
      openAccordionIndex = null;
    } else {
      openAccordionIndex = index;
    }
  }
</script>

<main class="wrapper">
    <div class="content-first"> 
      {#each budget.expenses as expense, index}
        <div class="accordion-header subdisplay mb-3 mt-3" on:click={() => toggleAccordion(index)}>
          <span>{expense.name} - {expense.totalAmount}</span>

          {#if openAccordionIndex === index}
            <img src={MinusIcon} alt="Collapse" class="accordion-icon" />
          {:else}
            <img src={PlusIcon} alt="Expand" class="accordion-icon" />
          {/if}
        </div>

        {#if openAccordionIndex === index}
        <div class="accordion-content-first">
          <p class="accordion-paragraph">Lorem ipsum dolor sit amet consectetur adipisicing elit. Iste veritatis inventore repellat recusandae minus itaque, a porro similique soluta facilis non omnis laudantium, impedit eum fugit? Vitae veniam sint quidem!</p>
        </div>
          {#each expense.items as item}
            <div class="accordion-wrapper mt-2">
              <div class="accordion-content-first">
                <button class="icon-button" on:click={() => DeleteItem(index, item.name)}>
                  <img src={Cross} class="item-icons" alt="delete itemfield" />
                </button>
              <input class="accordion-item-name" type="text" bind:value={item.name}/>
              <input class="accordion-item-amount mx-2" type="number" min="0" bind:value={item.amount}/>
              </div>
            </div>
          {/each}
            <div class="accordion-full-bleed">
              <button class="icon-button mt-4" on:click={AddItem(expense.name)}>
                <img src={Add} class="item-icons" alt="Add item" />
                <p class="small-p">Add new field</p>
              </button>
            </div>  
        {/if}
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
    <div class="full-bleed subdisplay total-expenses">
      Totala inkomster: {totalAmountExpense}kr<br>
      Totala utgifter: {totalAmountExpense}kr
    </div>
    <div class="full-bleed">
        <button on:click={() => PostBudgetToApi(budget)}>Post Budget</button> 
    </div>    
  </div>
</main>


<style>
  
  .accordion-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    cursor: pointer;
    background-color: #091f20;
    color: #dff4f6;
    padding: 1rem 1rem;
  }

  .accordion-content {
    display: none;
  }

  .accordion-content.open {
    display: block;
    text-align: center;
  }

</style>

