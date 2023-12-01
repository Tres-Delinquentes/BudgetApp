<script>
  import FetchBudget from "./Components/Functions/FetchBudget.svelte";
  import Nav from "./Components/Nav.svelte";
  import Accordion from "./Components/Accordion.svelte";
  import Income from "./Components/Income.svelte";
  // import budgetToDisplay from "./Components/Nav.svelte";

  let budgetToDisplay;
  let budgetTitle;
  let titleForBudget;
  let titleDescription;

  let budgetList = { expenses: [], income: [] };
  $: console.log("budget from app " + budgetList);
</script>

<FetchBudget bind:budgetList />
<main class="wrapper">
  <Nav bind:budgetToDisplay bind:budgetTitle />
  {#if budgetList && budgetList.length > 0}
    <div class="wrapper">
      <div class="content-first">
        <h1 class="subdisplay">Dina uppgifter</h1>
        <input 
          class="budget-name"
          type="text"
          placeholder="Name of budget"
          bind:value={ titleForBudget }
        /><br>
        <textarea 
          class=""
          rows="4"
          placeholder="Description"
          bind:value={ titleDescription }
        />
        <br>
        <Income { budgetList } { budgetToDisplay }/> 
        <div class="button-group">
          <p class="p">Nedan har vi 3st olika mallar för hur en budget kan se ut, välj gärna en eller skapa din egna från en tom mall.</p>
          <button on:click={() => (budgetToDisplay = 0)}>Small</button>
          <button on:click={() => (budgetToDisplay = 1)}>Medium</button>
          <button on:click={() => (budgetToDisplay = 2)}>Large</button>
          <button on:click={() => (budgetToDisplay = 2)}>Empty</button>
        </div>
        <h1 class="subdisplay">Utgifter</h1>
        <Accordion {budgetList} {budgetToDisplay} {budgetTitle} />
      </div>
      <div class="content-second"></div>
    </div>
  {/if}
</main>

<style>

  .budget-name {
    margin-bottom: 0.5rem;
    margin-top: 0.5rem;
  }

  .button-group {
    text-align: center;
    margin-top: 1rem;
    margin-bottom: 1rem;
  }

    .button-group p {
      
    }



  textarea {
    width: 100%; 
    padding: 10px; 
    border: 2px solid #ccc; 
    border-radius: 4px;
    font-family: inherit; 
    font-size: 1em; 
    resize: none; 
  }
</style>
